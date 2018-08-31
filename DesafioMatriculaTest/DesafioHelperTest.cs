using DesafioPuc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DesafioPucTest.FileHandlerContext
{
    [TestClass]
    public class DesafioHelperTest
    {
        [TestMethod]
        public void CalcularLinhaValida()
        {
            int resultadoEsperado = 14;
            Assert.AreEqual(resultadoEsperado, DesafioHelper.CalcularLinha("9876"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "linha invalida")]
        public void CalcularLinhaInvalida()
        {
            DesafioHelper.CalcularLinha("987654");
        }

        [TestMethod]        
        public void GerarDigitoVerificadorValido()
        {
            Assert.AreEqual("5", DesafioHelper.GerarDigitoVerificador(5));
            Assert.AreEqual("E", DesafioHelper.GerarDigitoVerificador(14));
        }

        [TestMethod]
        public void VerificarDigitoVerificadorValido()
        {
            Assert.AreEqual(true, DesafioHelper.VerificarDV("9876-E"));
            Assert.AreEqual(false, DesafioHelper.VerificarDV("9876-A"));
        }
    }
}
