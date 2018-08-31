using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioPuc
{
    public class Matriculas
    {

        //gerarDigitoVerificador(executa-matriculasSemDv
        //validarDigitosVerificadores(executa-MatriculasSemVerificacao
        public static string GerarDigitosVerificadores(string caminho)
        {
            var matriculaComDV = AdicionarDigitoVerificador(LerMatriculasSemDV(caminho));
            return SalvarMatriculasComDV(matriculaComDV);
        }
        public static string ValidarDigitosVerificadores(string caminho)
        {
            var matriculasVerificadas = VerificarMatriculas(LerMatriculasNaoVerificadas(caminho));
            return SalvarMatriculasVerificadas(matriculasVerificadas);
        }

        private static string[] LerMatriculasNaoVerificadas(string path)
        {
            return FileHandler.LerArquivo(path);
        }

        private static string[] VerificarMatriculas(string[] linhas)
        {
            for (int i = 0; i < linhas.Length; i++)
            {
                if (DesafioHelper.VerificarDV(linhas[i]))
                {
                    linhas[i] += " verdadeiro";
                }
                else
                {
                    linhas[i] += " falso";
                }
            }
            return linhas;
        }

        private static string SalvarMatriculasVerificadas(string[] linhas)
        {
            return FileHandler.EscreverArquivo(linhas);
        }
        private static string[] LerMatriculasSemDV(string path)
        {
            return FileHandler.LerArquivo(path);
        }

        private static string[] AdicionarDigitoVerificador(string[] linhas)
        {
            for (int i = 0; i < linhas.Length; i++)
            {
                var dv = DesafioHelper.GerarDigitoVerificador(DesafioHelper.CalcularLinha(linhas[i]));
                linhas[i] = $"{linhas[i]}-{dv}";
            }
            return linhas;
        }

        private static string SalvarMatriculasComDV(string[] linhas)
        {
            return FileHandler.EscreverArquivo(linhas);
        }
    }
}
