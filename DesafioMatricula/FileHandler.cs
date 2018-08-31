using System;
using System.IO;

namespace DesafioPuc
{
    public class FileHandler
    {
        public static String[] LerArquivo(string path)
        {
            if (System.IO.File.Exists(path))
            {
                return System.IO.File.ReadAllLines(path);
            }
            else throw new ArgumentException("não foi possível encontrar o arquivo no caminho especificado");
            
        }

        public static string EscreverArquivo(string[] content)
        {
            string fileName = Guid.NewGuid().ToString();
            string fullPath = Path.Combine(Environment.GetEnvironmentVariable("CAMINHO"), fileName);
            System.IO.File.WriteAllLines(fullPath, content);
            return fullPath;
        }                    
    }
}
