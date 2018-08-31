using DesafioPuc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DesafioPucTest
{
    [TestClass]
    public class FileHandlerTest
    {
        private string _RootPath;
            
        [TestInitialize]
        public void Setup()
        {
            _RootPath = Directory.GetCurrentDirectory();
        }

        [TestMethod]
        public void LerArquivoValido()
        {
            string rootPath = Path.Combine(_RootPath, "FileHandlerContext", "matriculasSemDV.txt");
            string[] arquivo = System.IO.File.ReadAllLines(rootPath);
            string[] resultadoFileHandler = FileHandler.LerArquivo(rootPath);
            Assert.AreEqual(arquivo.Length, resultadoFileHandler.Length);
            for (int i = 0; i < arquivo.Length; i++)
            {
                Assert.AreEqual(arquivo[i], resultadoFileHandler[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),"não foi possível encontrar o arquivo no caminho especificado")]
        public void LerArquivoInvalido()
        {
            FileHandler.LerArquivo("test");
        }
    }
}
