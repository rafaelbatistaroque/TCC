using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Paperless.API.Controllers
{
    [Route("api/v1/colaborador")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly ICriarColaborador _criarColaborador;

        public ColaboradorController(ICriarColaborador criarColaborador)
        {
            _criarColaborador = criarColaborador;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] CriarColaboradorCommand command)
        {
            var resultado = _criarColaborador.Handler(command);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok()
                );
        }
    }
}
