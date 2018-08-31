using DesafioPuc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace DesafioPucTest
{
    [TestClass]
    public class MatriculasSemVerificacaoTest
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
            string caminho = Path.Combine(_RootPath, "FileHandlerContext", "matriculasParaVerificar.txt");
            string[] linhas = System.IO.File.ReadAllLines(caminho);

            string caminhoComDV = Matriculas.ValidarDigitosVerificadores(caminho);
            string[] linhasComDV = System.IO.File.ReadAllLines(caminhoComDV);

            Assert.AreEqual(linhas.Length, linhasComDV.Length);

            for (int i = 0; i < linhas.Length; i++)
            {
                if (DesafioHelper.VerificarDV(linhas[i]))
                {
                    Assert.AreEqual(true, linhasComDV[i].Contains("verdadeiro"));
                }
                else
                {
                    Assert.AreEqual(true, linhasComDV[i].Contains("falso"));
                }
            }
        }
    }
}
