using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CaraCracha.Controllers
{
    public class CaptureImgController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromBody] string imagem)
        {
            //gerando um nome de arquivo através de um GUID
            //dessa forma não sobrescrevemos arquivos e não criamos cache de imagens no front
            var fileName = $"{Guid.NewGuid().ToString()}.png";

            //dependendo a lib,a  imagem sempre vem com algumas informações a mais que
            //precisamos remover, então usamos a expressão abaixo
            var data = new Regex(@"^data:image\/[a-z]+;base64,").Replace(imagem, "");

            //transformando em bytes
            var bytes = Convert.FromBase64String(data);

            //salvando imagem no disco
            try
            {
                //methodo WriteallBytes que escreve tudo no disco
                await System.IO.File.WriteAllBytesAsync($"wwwroot/files/photos/{fileName}", bytes);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Falha interna no servidor da aplicação");
            }

        }
    }
}
