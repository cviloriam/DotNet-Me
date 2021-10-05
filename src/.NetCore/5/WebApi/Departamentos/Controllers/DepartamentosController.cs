using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiDepartamentos.Models;
using Newtonsoft.Json;
using System.Net;
using WebApiDepartamentos.Configs;
using Microsoft.Extensions.Options;

namespace WebApiDepartamentos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentosController : ControllerBase
    {
        private readonly DepartamentoRepositorio departamentoRepositorio;
        private readonly UrlApi cfg_urlapi;

        public DepartamentosController(DepartamentoRepositorio departamentoRepositorio, IOptions<UrlApi> cfg_urlapi)
        {
            this.departamentoRepositorio = departamentoRepositorio;
            this.cfg_urlapi = cfg_urlapi.Value;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Departamento>> Get()
        {
            return departamentoRepositorio.ConsultarTodos().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Departamento> Get(int id) 
        {
            var departamento = departamentoRepositorio.ConsultarXId(id);

            if (departamento == null)
                return NotFound();

            string url = cfg_urlapi.Empleados;
            var _json = new WebClient().DownloadString(url);
            dynamic jsonDes = JsonConvert.DeserializeObject(_json);
            Console.WriteLine(_json);
            foreach (var i in jsonDes)
            {
                Console.WriteLine(i.primerNombre + "" + i.primerApellido);
            }

            return departamento;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Departamento departamento)
        {
            departamentoRepositorio.Crear(departamento);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Departamento departamento)
        {
            if (id != departamento.Id)
                return BadRequest();

            departamentoRepositorio.Actualizar(departamento);
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            departamentoRepositorio.Eliminar(id);
            return Ok();
        }
    }
}