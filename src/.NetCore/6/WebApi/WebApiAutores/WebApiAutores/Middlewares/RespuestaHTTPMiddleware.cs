namespace WebApiAutores.Middlewares
{
    public static class RespuestaHTTPMiddlewareExtensions
    {
        public static IApplicationBuilder UseRespuestaHTTPLog(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<RespuestaHTTPMiddleware>();
        }
    }

    //Guardar en un log el cuerpo de las las respuestas que se envían
    //hacia los clientes que hacen las peticiones.
    public class RespuestaHTTPMiddleware
    {
        private readonly RequestDelegate siguiente;
        private readonly ILogger<RespuestaHTTPMiddleware> logger;

        public RespuestaHTTPMiddleware(RequestDelegate siguiente,
                ILogger<RespuestaHTTPMiddleware> logger)
        {
            this.siguiente = siguiente;
            this.logger = logger;
        }

        //Invoke o InvokeAsync
        public async Task InvokeAsync(HttpContext contexto) 
        {
            using (var ms = new MemoryStream())
            {
                var cuerpoOriginalRespuesta = contexto.Response.Body;
                contexto.Response.Body = ms;

                await siguiente(contexto);

                ms.Seek(0, SeekOrigin.Begin);
                string respuesta = new StreamReader(ms).ReadToEnd();
                ms.Seek(0, SeekOrigin.Begin);

                await ms.CopyToAsync(cuerpoOriginalRespuesta);
                contexto.Response.Body = cuerpoOriginalRespuesta;

                logger.LogDebug(respuesta);
            }
        }
        
    }
}