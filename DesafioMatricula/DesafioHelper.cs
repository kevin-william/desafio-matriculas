using System;
using System.Text.RegularExpressions;

namespace DesafioPuc
{
    public class DesafioHelper
    {
        public static int CalcularLinha(String linha)
        {            
            if(!AnalisarLinhaSemDV(linha))
            {
                throw new ArgumentException("linha invalida");
            }
            int multiplicador = 5;
            int somatorio = 0;
            for (int i = 0; i < linha.Length; i++)
            {
                int digito = Int32.Parse(linha.Substring(i, 1));
                somatorio += digito * multiplicador;
                multiplicador--;
            }
            somatorio = somatorio % 16;
            return somatorio;
        }

        public static string GerarDigitoVerificador(int valor)
        {
            return HexaHelper.Base10ToBase16(valor);
        }
        

        private static bool AnalisarLinhaSemDV(string linha)
        {
            return Regex.IsMatch(linha, "^[0-9]{4}$");                      
        }

        private static bool AnalisarLinhaComDV(string linha)
        {
            return Regex.IsMatch(linha, "^[0-9]{4}-[0-9a-fA-F]$");
        }

        private static string GetNumerosLinhaComDV(string linha)
        {
            return linha.Split("-")[0];
        }

        private static string GetDigitoVerificador(string linha)
        {
            return linha.Split("-")[1];
        }

        public static bool VerificarDV(string linha)
        {
            if (AnalisarLinhaComDV(linha))
            {
                string dv = GerarDigitoVerificador(CalcularLinha(GetNumerosLinhaComDV(linha)));
                if (dv == GetDigitoVerificador(linha))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
