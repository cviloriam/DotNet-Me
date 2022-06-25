using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        
        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }
                
        [HttpGet] // api/autores
        public async Task<ActionResult<List<Autor>>> Get()
        {
            return await context.Autores.ToListAsync();            
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
            var autor = await context.Autores.FirstOrDefaultAsync(x => x.Titulo.Contains(nombre));

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
            var existeAutorMismoNombre = await context.Autores.AnyAsync(x => x.Titulo == autor.Titulo);

            if (existeAutorMismoNombre)
                return BadRequest($"Ya existe un autor con el mismo nombre : {autor.Titulo}");

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