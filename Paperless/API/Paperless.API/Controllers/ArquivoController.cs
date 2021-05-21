using Arquivo.Domain.CasosDeUso.CriarArquivo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Paperless.API.Controllers
{
    [Route("api/v1/arquivo")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly ICriarArquivo _criarArquivo;

        public ArquivoController(ICriarArquivo criarArquivo)
        {
            _criarArquivo = criarArquivo;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] CriarArquivoCommand command)
        {
            var resultado = _criarArquivo.Handler(command);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok());
        }
    }
}
