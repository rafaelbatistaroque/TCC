using Arquivo.Domain.CasosDeUso.CriarArquivo;
using Arquivo.Domain.CasosDeUso.DeletarArquivo;
using Arquivo.Domain.CasosDeUso.DownloadArquivo;
using Arquivo.Domain.CasosDeUso.ObterArquivos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;

namespace Paperless.API.Controllers
{
    [Route("api/v1/arquivo")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly ICriarArquivo _criarArquivo;
        private readonly IObterArquivosDeColaborador _obterArquivosDeColaborador;
        private readonly IRealizarDownloadDeArquivo _realizarDownloadDeArquivo;
        private readonly IDeletarArquivo _deletarArquivo;

        public ArquivoController(
            ICriarArquivo criarArquivo,
            IObterArquivosDeColaborador obterArquivosDeColaborador,
            IRealizarDownloadDeArquivo realizarDownloadDeArquivo,
            IDeletarArquivo deletarArquivo)
        {
            _criarArquivo = criarArquivo;
            _obterArquivosDeColaborador = obterArquivosDeColaborador;
            _realizarDownloadDeArquivo = realizarDownloadDeArquivo;
            _deletarArquivo = deletarArquivo;
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromForm] CriarArquivoCommand command)
        {
            try
            {
                var resultado = _criarArquivo.Handler(command);

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
        [Route("{colaboradorId:int}")]
        [Authorize]
        public IActionResult Get([FromRoute] int colaboradorId)
        {
            try
            {
                var resultado = _obterArquivosDeColaborador.Handler(colaboradorId);

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro.MensagensErro }),
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

        [HttpGet]
        [Route("{id}/{arquivoCodigo}")]
        public IActionResult Get([FromRoute] int id, string arquivoCodigo)
        {
            try
            {
                var command = new RealizarDownloadArquivoCommand() { Id = id, ArquivoCodigo = arquivoCodigo };
                var resultado = _realizarDownloadDeArquivo.Handler(command);

                return resultado.RetornarCaso<IActionResult>(
                    erro => BadRequest(new { Erros = erro.MensagensErro }),
                    sucesso => File(new MemoryStream(sucesso.DadosByte), sucesso.ApplicationForceDownload, sucesso.Nome));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{arquivoId:int}")]
        [Authorize]
        public IActionResult Delete([FromRoute] int arquivoId)
        {
            try
            {
                var resultado = _deletarArquivo.Handler(arquivoId);

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
