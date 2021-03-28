using Microsoft.AspNetCore.Mvc;
using Usuario.Domain.CasosDeUso.CriarUsuario;

namespace Paperless.API.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ICriarUsuario _criarUsuario;

        public UsuarioController(ICriarUsuario criarUsuario)
        {
            _criarUsuario = criarUsuario;
        }

        [HttpPost]
        public IActionResult Post([FromBody]CriarUsuarioCommand command)
        {
            var resultado = _criarUsuario.Handler(command);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new {Erro= erro }),
                sucesso => Ok()
                );
        }
    }
}
