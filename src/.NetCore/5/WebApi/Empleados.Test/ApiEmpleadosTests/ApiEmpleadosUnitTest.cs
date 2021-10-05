using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApiEmpleadosTests
{
    [TestClass]
    public class ApiEmpleadosUnitTest
    {
        [TestMethod]
        public void Go()        
        {
            // Preparación
            var prueba = "Inicio";

            // Prueba
            var resultado = prueba.Equals("Inicio");

            // Verificación
            Assert.IsTrue(resultado);
        }
    }
}