using DesafioPuc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DesafioPucTest
{
    [TestClass]
    public class MatriculaSemDVTest
    {
        private string _RootPath;

        [TestInitialize]
        public void Setup()
        {
            _RootPath = Directory.GetCurrentDirectory();
            Environment.SetEnvironmentVariable("CAMINHO", _RootPath);
        }

        [TestMethod]
        public void TestaExecutarValido()
        {
            string caminho = Path.Combine(_RootPath, "FileHandlerContext", "matriculasSemDV.txt");
            string[] linhas = System.IO.File.ReadAllLines(caminho);

            string caminhoComDV = Matriculas.GerarDigitosVerificadores(caminho);
            string[] linhasComDV = System.IO.File.ReadAllLines(caminhoComDV);

            Assert.AreEqual(linhas.Length, linhasComDV.Length);

            for (int i = 0; i < linhas.Length; i++)
            {
                int dv = DesafioHelper.CalcularLinha(linhas[i]);
                string linha = $"{linhas[i]}-{DesafioHelper.GerarDigitoVerificador(dv)}";
                Assert.AreEqual(linha, linhasComDV[i]);
            }
        }
    }
}
