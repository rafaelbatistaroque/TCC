using Arquivo.Business.Contracts;
using Arquivo.Domain.CasosDeUso.DownloadArquivo;
using Arquivo.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System.Linq;

namespace Arquivo.Business.Services
{
    public class RealizarDownloadDeArquivoHandler : IRealizarDownloadDeArquivo
    {
        private readonly IArquivoRepository _repositorio;
        private readonly IDiretorioServico _diretorio;

        public RealizarDownloadDeArquivoHandler(IArquivoRepository repositorio, IDiretorioServico anexoFacade)
        {
            _repositorio = repositorio;
            _diretorio = anexoFacade;
        }

        public Either<ErroBase, ArquivoDownload> Handler(RealizarDownloadArquivoCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoCommandQuery(command.Notifications.Select(e => e.Message).ToArray());

            var arquivoBanco = _repositorio.ObterArquivo(command.Id, command.ArquivoCodigo);
            if(arquivoBanco is null)
                return new ErroRegistroNaoEncontrado(ArquivoTextosInformativos.NENHUM_REGISTRO_ENCONTRADO);

            var arquivo = _diretorio.ObterArquivoEmDiretorio(command.ArquivoCodigo, arquivoBanco.Anexo.Extensao);
            if(arquivo.EhFalha)
                return arquivo.Falha;

            return ArquivoDownload.Criar(arquivo.Sucesso, arquivoBanco.Anexo.Codigo, arquivoBanco.Anexo.Extensao);
        }
    }
}
