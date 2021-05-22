using Arquivo.Domain.CasosDeUso.CriarArquivo;
using Arquivo.Domain.CasosDeUso.ObterArquivos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Paperless.API.Controllers
{
    [Route("api/v1/arquivo")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly ICriarArquivo _criarArquivo;
        private readonly IObterArquivosDeColaborador _obterArquivosDeColaborador;

        public ArquivoController(ICriarArquivo criarArquivo, IObterArquivosDeColaborador obterArquivosDeColaborador)
        {
            _criarArquivo = criarArquivo;
            _obterArquivosDeColaborador = obterArquivosDeColaborador;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] CriarArquivoCommand command)
        {
            try
            {
                var resultado = _criarArquivo.Handler(command);

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro }),
                    sucesso => Ok());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{colaboradorId:int}")]
        [Authorize]
        public IActionResult Get([FromRoute] int colaboradorId)
        {
            try
            {
                var resultado = _obterArquivosDeColaborador.Handler(colaboradorId);

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro }),
                    sucesso => Ok(new
                    {
                        Arquivos = sucesso.Select(x => new
                        {
                            x.Id,
                            x.DataCadastro,
                            x.AnoReferencia,
                            x.MesReferencia,
                            x.Observacoes,
                            Anexo = new
                            {
                                x.Anexo.Tipo,
                                x.Anexo.Nome,
                                x.Anexo.Extensao,
                                x.Anexo.LinkParaDownload
                            }
                        })
                    }));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
