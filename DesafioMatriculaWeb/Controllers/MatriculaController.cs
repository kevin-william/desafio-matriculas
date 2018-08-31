using System;
using System.IO;
using DesafioPuc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesafioPucWeb.Controllers
{
    [Produces("application/octet-stream")]
    [Route("api/[controller]")]
    public class MatriculaController : Controller
    {
        [HttpPost("[action]"), DisableRequestSizeLimit]
        public ActionResult GerarDigitoVerificador()
        {
            string arquivoDownload = "";
            string arquivoUpload = "";

            try
            {
                IFormFile arquivo = Request.Form.Files[0];

                arquivoUpload = SalvarArquivo(arquivo);

                arquivoDownload = Matriculas.GerarDigitosVerificadores(arquivoUpload);

                return BaixarArquivo(arquivoDownload);
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
            finally
            {
                RemoverArquivo(arquivoDownload);
                RemoverArquivo(arquivoUpload);
            }
        }

        [HttpPost("[action]"), DisableRequestSizeLimit]
        public ActionResult ValidarDigitosVerificadores()
        {
            string arquivoDownload = "";
            string arquivoUpload = "";
            try
            {
                IFormFile arquivo = Request.Form.Files[0];

                arquivoUpload = SalvarArquivo(arquivo);

                arquivoDownload = Matriculas.ValidarDigitosVerificadores(arquivoUpload);

                return BaixarArquivo(arquivoDownload);
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
            finally
            {
                RemoverArquivo(arquivoDownload);
                RemoverArquivo(arquivoUpload);
            }
        }

        private void RemoverArquivo(string resultado)
        {
            if (System.IO.File.Exists(resultado)) { System.IO.File.Delete(resultado); }
        }

        private static ActionResult BaixarArquivo(string arquivo)
        {
            byte[] byteFile = System.IO.File.ReadAllBytes(arquivo);
            return new FileContentResult(byteFile, "application/octet-stream");
        }

        private string SalvarArquivo(IFormFile arquivo)
        {
            string fullPath = Environment.GetEnvironmentVariable("CAMINHO");

            if (!string.IsNullOrEmpty(fullPath) && !Directory.Exists(fullPath))
            {
                Directory.CreateDirectory(fullPath);
            }

            if (arquivo.Length > 0)
            {
                string fileName = Guid.NewGuid().ToString();
                fullPath = Path.Combine(fullPath, fileName);
                using (var stream = new FileStream(fullPath, FileMode.Create))
                {
                    arquivo.CopyTo(stream);
                }
            }

            return fullPath;
        }

    }
}