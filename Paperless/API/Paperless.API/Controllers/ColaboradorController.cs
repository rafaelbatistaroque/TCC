using Colaborador.Domain.CasosDeUso.CriarColaborador;
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

        public ColaboradorController(ICriarColaborador criarColaborador, IObterColaboradores obterColaboradores, IObterColaborador obterColaborador)
        {
            _criarColaborador = criarColaborador;
            _obterColaboradores = obterColaboradores;
            _obterColaborador = obterColaborador;
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
                        sucesso.ColaboradorNome.NomeCompleto,
                        sucesso.ColaboradorCPF.NumeroCPF,
                        sucesso.Funcao.FuncaoId,
                        sucesso.Funcao.FuncaoNome
                    }));
        }
    }
}
