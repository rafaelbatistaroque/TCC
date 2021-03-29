using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Paperless.API.Controllers
{
    [Route("api/v1/autenticacao")]
    [ApiController]
    public class AutenticacaoController : ControllerBase
    {
        private readonly IAutenticarUsuario _autenticarUsuario;

        public AutenticacaoController(IAutenticarUsuario autenticarUsuario)
        {
            _autenticarUsuario = autenticarUsuario;
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] AutenticarUsuarioCommand command)
        {
            var resultado = _autenticarUsuario.Handler(command);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok(sucesso)
                );
        }
    }
}
