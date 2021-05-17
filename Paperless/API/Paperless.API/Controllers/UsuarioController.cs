using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paperless.API.Utils;
using System.Linq;
using Usuario.Domain.CasosDeUso.AlterarStatusUsuario;
using Usuario.Domain.CasosDeUso.CriarUsuario;
using Usuario.Domain.CasosDeUso.ObterUsuarios;

namespace Paperless.API.Controllers
{
    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ICriarUsuario _criarUsuario;
        private readonly IObterUsuarios _obterUsuarios;
        private readonly IAlterarStatusUsuario _alterarStatusUsuario;

        public UsuarioController(ICriarUsuario criarUsuario, IObterUsuarios obterUsuarios, IAlterarStatusUsuario alterarStatusUsuario)
        {
            _criarUsuario = criarUsuario;
            _obterUsuarios = obterUsuarios;
            _alterarStatusUsuario = alterarStatusUsuario;
        }

        [HttpPost]
        [Authorize(Roles = PerfilRoles.ADMINISTRADOR)]
        public IActionResult Post([FromBody] CriarUsuarioCommand command)
        {
            var resultado = _criarUsuario.Handler(command);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok());
        }

        [HttpGet]
        [Authorize(Roles = PerfilRoles.ADMINISTRADOR)]
        public IActionResult Get()
        {
            var resultado = _obterUsuarios.Handler();

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok(new
                {
                    Usuarios = sucesso.Select(u =>
                    new
                    {
                        u.UsuarioIdentificacao.Codigo,
                        u.UsuarioNome,
                        u.EhUsuarioAtivo,
                        u.UsuarioPerfil.PerfilId,
                        u.UsuarioPerfil.PerfilNome
                    })
                }));
        }

        [HttpPut]
        [Authorize(Roles = PerfilRoles.ADMINISTRADOR)]
        public IActionResult Put(AlterarStatusUsuarioCommand command)
        {
            var resultado = _alterarStatusUsuario.Handler(command);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok());
        }
    }
}
