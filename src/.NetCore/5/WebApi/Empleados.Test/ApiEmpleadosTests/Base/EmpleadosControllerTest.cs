using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEmpleados.Controllers;
using WebApiEmpleados.Models;

namespace ApiEmpleadosTests.Base
{
    [TestClass]
    public class EmpleadosControllerTest : DBTest
    {
        [TestMethod]
        public void ObtenerTodosLosEmpeados()
        {
            // Preparación
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBD);
            contexto.Empleados.Add(new Empleado() { PrimerNombre = "N1" });
            contexto.Empleados.Add(new Empleado() { PrimerNombre = "N2" });
            contexto.Empleados.Add(new Empleado() { PrimerNombre = "N3" });
            contexto.SaveChanges();
            var contexto2 = ConstruirContexto(nombreBD);

            // Pruebas
            var controlador = new EmpleadosController(contexto2);
            var respuesta = controlador.Get();

            // Verificación
            var resultado = respuesta.Value;
            Assert.AreEqual(3, resultado.Count());
        }

        [TestMethod]
        public void ObtenerEmpleadoPorIdNoExiste()
        {
            // Preparación
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBD);

            // Pruebas
            var controlador = new EmpleadosController(contexto);
            var respuesta = controlador.Get(1);

            // Verificación
            var resultado = respuesta.Result as StatusCodeResult;
            Assert.AreEqual(404, resultado.StatusCode);
        }

        [TestMethod]
        public void ObtenerEmpleadoPorIdExiste()
        {
            // Preparación
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBD);
            contexto.Empleados.Add(new Empleado() { PrimerApellido = "Ap1" });
            contexto.Empleados.Add(new Empleado() { PrimerApellido = "Ap2" });
            contexto.Empleados.Add(new Empleado() { PrimerApellido = "Ap3" });
            contexto.SaveChanges();

            // Prueba
            var controlador = new EmpleadosController(contexto);
            var id = 1;
            var respuesta = controlador.Get(id);

            // Verificación
            var resultado = respuesta.Value;
            Assert.AreEqual(id, resultado.Id);
        }

        [DataRow("123", "Abc1", "Def1")]
        [DataRow("456", "Ghi2", "Jkl2")]
        [DataRow("789", "Lmn3", "Opq3")]
        [TestMethod]
        public void CrearEmpleado(string numeroDocumento, string primerNombre, string primerApellido)
        {
            // Preparación
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBD);

            // Prueba
            var nuevoEmpleado = new Empleado() { NumeroDocumento = numeroDocumento, PrimerNombre = primerNombre, PrimerApellido = primerApellido };
            var controlador = new EmpleadosController(contexto);
            var respuesta = controlador.Post(nuevoEmpleado);

            // Verificación 1
            var resultado = respuesta as CreatedAtRouteResult;
            Assert.IsNotNull(resultado);

            // Verificación 2
            var contexto2 = ConstruirContexto(nombreBD);
            var registros = contexto2.Empleados.Count();
            Assert.AreEqual(1, registros);
        }

        [TestMethod]
        public void ActualizarEmpleado()
        {
            // Preparación
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBD);

            // Prueba 1 - Agregar
            contexto.Empleados.Add(new Empleado() { PrimerApellido = "Ape1" });
            contexto.SaveChanges();

            // Prueba 2 - Actualizar
            var id = 1;
            var contexto2 = ConstruirContexto(nombreBD);
            var controlador = new EmpleadosController(contexto2);
            var actualizarEmpleado = new Empleado() { PrimerApellido = "Apellido1" };            
            var respuesta = controlador.Put(id, actualizarEmpleado);

            // Verificación 1
            var resultado = respuesta as StatusCodeResult;
            Assert.AreEqual(200, resultado.StatusCode);

            // Verificación 2            
            var existe = contexto.Empleados.Any(x => x.PrimerApellido == "Apellido1");
            Assert.IsTrue(existe);
        }

        [TestMethod]
        public void EliminarEmpleadoNoExiste() 
        {
            // Preparación
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBD);
            var controlador = new EmpleadosController(contexto);

            // Prueba
            var respuesta = controlador.Delete(1);

            // Verificación
            var resultado = respuesta as StatusCodeResult;
            Assert.AreEqual(404, resultado.StatusCode);
        }

        [TestMethod]
        public void EliminarEmpleadoExiste()
        {
            // Preparación
            var nombreBD = Guid.NewGuid().ToString();
            var contexto = ConstruirContexto(nombreBD);

            // Prueba 1 - Agregar
            contexto.Empleados.Add(new Empleado() { SegundoApellido = "Ape2" });
            contexto.SaveChanges();

            // Prueba 2 - Eliminar
            var id = 1;
            var contexto2 = ConstruirContexto(nombreBD);
            var controlador = new EmpleadosController(contexto2);
            var respuesta = controlador.Delete(id);

            // Verificación
            var resultado = respuesta as StatusCodeResult;
            Assert.AreEqual(200, resultado.StatusCode);
        }
    }
}