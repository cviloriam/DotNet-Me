using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApiAutores.Entities;
using WebApiAutores.Filters;
using WebApiAutores.Services;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IService service;
        private readonly ILogger<AutoresController> logger;
        private readonly ServiceTransiet serviceTransiet;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;

        public AutoresController(ApplicationDbContext context,
            IService service, ILogger<AutoresController> logger,
            ServiceTransiet serviceTransiet, ServiceScoped serviceScoped, ServiceSingleton serviceSingleton)
        {
            this.context = context;
            this.service = service;
            this.logger = logger;
            this.serviceTransiet = serviceTransiet;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
        }

        [HttpGet("GUID")]
        [ServiceFilter(typeof(MiFiltroAccion))]
        public ActionResult ObtenerGuids() 
        {
            return Ok(new {
                AutoresController_Transiet = serviceTransiet.Guid,
                ServiceA_Transiet = service.ObtenerTransiet(),
                AutoresController_Scoped = serviceScoped.Guid,
                ServiceA_Scoped = service.ObtenerScoped(),
                AutoresController_Singleton = serviceSingleton.Guid,
                ServiceA_Singleton = service.ObtenerSingleton()
            });
        }

        [HttpGet] // api/autores
        [HttpGet("listado")] // api/autores/listado
        [HttpGet("/listado")] // listado
        [ResponseCache(Duration = 20)] // Guarda en Caché los resultados de este método por 20 segundos
        [ServiceFilter(typeof(MiFiltroAccion))]
        public async Task<ActionResult<List<Autor>>> Get()
        {
            try
            {
                logger.LogInformation("Obteniendo los autores.");
                logger.LogWarning("Listado de autores.");
                logger.LogDebug("Debugeando listado de autores.");
                return await context.Autores.Include(x => x.Libros).ToListAsync();
            }
            catch (Exception)
            {
                throw new NotImplementedException();
            }
        }

        [HttpGet("primero")] // api/autores/primero?nombre=nombre
        public async Task<ActionResult<Autor>> PrimerAutor([FromHeader] int valor, [FromQuery] string nombre)
        {
            return await context.Autores.FirstOrDefaultAsync();
        }
        
        [HttpGet("segundo")] // api/autores/segundo
        public ActionResult<Autor> SegundoAutor() 
        {
            return new Autor() { Id = 1, Name = "Autor en Memoria" };
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
                return NotFound();

            return autor;
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<Autor>> Get(string nombre)
        {
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Name.Contains(nombre));

            if (autor == null)
                return BadRequest();

            return autor;
        }

        [HttpGet("{id:int}/{nombre}")]
        public IActionResult Get(int id, string nombre) 
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);

            if (autor == null)
                return NotFound();

            return Ok(autor);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Autor autor)
        {
            var existeAutorMismoNombre = await context.Autores.AnyAsync(x => x.Name == autor.Name);

            if (existeAutorMismoNombre)
                return BadRequest($"Ya existe un autor con el mismo nombre : {autor.Name}");

            context.Add(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
                return BadRequest("El id del autor no coincide con el id del parámetro en la URL");

            var existe = await context.Autores.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound();
            
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id) 
        {
            var existe = await context.Autores.AnyAsync(x => x.Id == id);
            if (!existe)
                return NotFound();

            context.Remove(new Autor { Id = id });
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}