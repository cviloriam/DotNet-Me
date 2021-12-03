using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiAutores.Filters
{
    public class MiFiltroExcepcion : ExceptionFilterAttribute
    {
        private readonly ILogger<MiFiltroExcepcion> logger;

        public MiFiltroExcepcion(ILogger<MiFiltroExcepcion> logger)
        {
            this.logger = logger;
        }
        public override void OnException(ExceptionContext context)
        {
            logger.LogError(context.Exception, context.Exception.Message);
            base.OnException(context);  
        }
    }
}