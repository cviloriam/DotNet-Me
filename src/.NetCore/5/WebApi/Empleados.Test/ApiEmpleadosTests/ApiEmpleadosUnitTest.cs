using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiEmpleadosTests
{
    [TestClass]
    public class ApiEmpleadosUnitTest
    {
        [TestMethod]
        public void Go()        
        {
            // Preparaci�n
            var prueba = "Inicio";

            // Prueba
            var resultado = prueba.Equals("Inicio");

            // Verificaci�n
            Assert.IsTrue(resultado);
        }
    }
}