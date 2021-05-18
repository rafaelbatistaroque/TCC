using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Colaborador.Domain.CasosDeUso.DeletarColaborador;
using Colaborador.Domain.CasosDeUso.ObterColaborador;
using Colaborador.Domain.CasosDeUso.ObterColaboradores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paperless.API.Utils;
using System.Linq;

namespace Paperless.API.Controllers
{
    [Route("api/v1/colaborador")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly ICriarColaborador _criarColaborador;
        private readonly IObterColaboradores _obterColaboradores;
        private readonly IObterColaborador _obterColaborador;
        private readonly IDeletarColaborador _deletarColaborador;

        public ColaboradorController(ICriarColaborador criarColaborador, IObterColaboradores obterColaboradores, IObterColaborador obterColaborador, IDeletarColaborador deletarColaborador)
        {
            _criarColaborador = criarColaborador;
            _obterColaboradores = obterColaboradores;
            _obterColaborador = obterColaborador;
            _deletarColaborador = deletarColaborador;
        }

        [HttpPost]
        [Authorize(Roles = PerfilRoles.ADMINISTRADOR)]
        public IActionResult Post([FromBody] CriarColaboradorCommand command)
        {
            var resultado = _criarColaborador.Handler(command);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok());
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            var resultado = _obterColaboradores.Handler();

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok(new
                {
                    Colaboradores = sucesso.Select(c => new
                    {
                        c.Id,
                        c.ColaboradorNome.NomeCompleto,
                        c.ColaboradorCPF.NumeroCPF,
                        c.Funcao.FuncaoId,
                        c.Funcao.FuncaoNome
                    })
                }));
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            var resultado = _obterColaborador.Handler(id);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok(new
                    {
                        sucesso.Id,
                        sucesso.ColaboradorNome.NomeCompleto,
                        sucesso.ColaboradorCPF.NumeroCPF,
                        sucesso.Funcao.FuncaoId,
                        sucesso.Funcao.FuncaoNome
                    }));
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = PerfilRoles.ADMINISTRADOR)]
        public IActionResult Delete(int id)
        {
            var resultado = _deletarColaborador.Handler(id);

            return resultado.RetornarCaso<IActionResult>(
                erro => BadRequest(new { Erros = erro }),
                sucesso => Ok());
        }
    }
}
