using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paperless.API.Utils;
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
        [Authorize(Roles = PerfilRoles.ADMINISTRADOR)]
        public IActionResult Post([FromBody] CriarUsuarioCommand command)
        {
            var resultado = _criarUsuario.Handler(command);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok()
                );
        }
    }
}
