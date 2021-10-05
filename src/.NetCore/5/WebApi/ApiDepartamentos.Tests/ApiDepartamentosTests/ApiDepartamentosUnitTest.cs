using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApiDepartamentos.Configs;
using WebApiDepartamentos.Controllers;
using WebApiDepartamentos.Models;
using Moq;

namespace ApiDepartamentosTests
{
    [TestClass]
    public class ApiDepartamentosUnitTest
    {
        private DepartamentoRepositorio departamentoRepositorio;
        private readonly ApplicationDbContext context;
        Mock<IOptions<UrlApi>> cfg_urlapi = new Mock<IOptions<UrlApi>>();

        [TestMethod]
        public void Pru1_GetDepartamentos()
        {
            //Preparación
            cfg_urlapi.Setup(x => x.Value).Returns(new UrlApi());
            departamentoRepositorio = new DepartamentoRepositorio(context);

            //Prueba
            var controlador = new DepartamentosController(departamentoRepositorio, cfg_urlapi.Object);
            var respuesta = controlador.Get();

            //Verificación
            var verificarResp = respuesta.Result as BadRequestObjectResult;
            Assert.AreEqual(400, verificarResp.StatusCode);
        }
    }
}