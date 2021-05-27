using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

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
            try
            {
                var resultado = _autenticarUsuario.Handler(command);

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro.MensagensErro }),
                    sucesso => Ok(sucesso));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
