using Colaborador.Domain.CasosDeUso.AlterarColaborador;
using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Colaborador.Domain.CasosDeUso.DeletarColaborador;
using Colaborador.Domain.CasosDeUso.ObterColaborador;
using Colaborador.Domain.CasosDeUso.ObterColaboradores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paperless.API.Utils;
using System;
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
        private readonly IAlterarColaborador _alterarColaborador;

        public ColaboradorController(
            ICriarColaborador criarColaborador,
            IObterColaboradores obterColaboradores,
            IObterColaborador obterColaborador,
            IDeletarColaborador deletarColaborador,
            IAlterarColaborador alterarColaborador)
        {
            _criarColaborador = criarColaborador;
            _obterColaboradores = obterColaboradores;
            _obterColaborador = obterColaborador;
            _deletarColaborador = deletarColaborador;
            _alterarColaborador = alterarColaborador;
        }

        [HttpPost]
        [Authorize(Roles = PerfilRoles.ADMINISTRADOR)]
        public IActionResult Post([FromBody] CriarColaboradorCommand command)
        {
            try
            {
                var resultado = _criarColaborador.Handler(command);

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro.MensagensErro }),
                    sucesso => Ok());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                var resultado = _obterColaboradores.Handler();

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro.MensagensErro }),
                    sucesso => Ok(new
                    {
                        Colaboradores = sucesso.Select(c => new
                        {
                            c.Id,
                            c.ColaboradorNome.PrimeiroNome,
                            c.ColaboradorNome.Sobrenome,
                            c.ColaboradorCPF.NumeroCPF,
                            c.Funcao.FuncaoId,
                            c.Funcao.FuncaoNome
                        })
                    }));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id:int}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                var resultado = _obterColaborador.Handler(id);

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro.MensagensErro }),
                    sucesso => Ok(new
                    {
                        sucesso.Id,
                        sucesso.ColaboradorNome.PrimeiroNome,
                        sucesso.ColaboradorNome.Sobrenome,
                        sucesso.ColaboradorCPF.NumeroCPF,
                        sucesso.Funcao.FuncaoId,
                        sucesso.Funcao.FuncaoNome
                    }));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = PerfilRoles.ADMINISTRADOR)]
        public IActionResult Delete(int id)
        {
            try
            {
                var resultado = _deletarColaborador.Handler(id);

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro.MensagensErro }),
                    sucesso => Ok());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Put(AlterarColaboradorCommand commad)
        {
            try
            {
                var resultado = _alterarColaborador.Handler(commad);

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro.MensagensErro }),
                    sucesso => Ok());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
