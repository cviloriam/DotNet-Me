using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiEmpleados.Models;

namespace WebApiEmpleados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public EmpleadosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Empleado>> Get()
        {
            return context.Empleados.ToList();
        }

        [HttpGet("{id}", Name= "GetEmpleado")]
        public ActionResult<Empleado> Get(int id) 
        {
            var empleado = context.Empleados.FirstOrDefault(x => x.Id == id);
            //var empleado = context.Empleados.Include(x => x.TipoDocumento).FirstOrDefault(x => x.Id == id);

            if (empleado == null)
                return NotFound();

            return empleado;
        }


        [HttpPost]
        public ActionResult Post([FromBody] Empleado empleado)
        {
            context.Empleados.Add(empleado);
            context.SaveChanges();
            return new CreatedAtRouteResult("GetEmpleado", new { id = empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Empleado empleado)
        {
            if (id != empleado.Id)
                return BadRequest();

            context.Entry(empleado).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();

        }

        [HttpDelete("{id}")]
        public ActionResult<Empleado> Delete (int id)
        {
            var empleado = context.Empleados.FirstOrDefault(x => x.Id == id);

            if (empleado == null)
                return NotFound();

            context.Empleados.Remove(empleado);
            context.SaveChanges();

            return empleado;
        }
    }
}