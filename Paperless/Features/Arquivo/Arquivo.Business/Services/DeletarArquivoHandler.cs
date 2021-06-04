using Arquivo.Business.Contracts;
using Arquivo.Domain.CasosDeUso.DeletarArquivo;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;

namespace Arquivo.Business.Services
{
    public class DeletarArquivoHandler : IDeletarArquivo
    {
        private readonly IArquivoRepository _repositorio;
        private readonly IDiretorioServico _diretorio;

        public DeletarArquivoHandler(IArquivoRepository repositorio, IDiretorioServico diretorio)
        {
            _repositorio = repositorio;
            _diretorio = diretorio;
        }

        public Either<ErroBase, bool> Handler(int arquivoId)
        {
            var respostaArquivoModel = _repositorio.ObterArquivo(arquivoId);
            if(respostaArquivoModel is null)
                return new ErroRegistroNaoEncontrado(ArquivoTextosInformativos.NENHUM_REGISTRO_ARQUIVO_ENCONTRADO);

            var respostaArquivoDeletado = _repositorio.DeletarArquivo(respostaArquivoModel);
            if(respostaArquivoDeletado is false)
                return new ErroNenhumRegistroModificado(ColaboradorTextosInformativos.NENHUM_REGISTRO_MODIFICADO);

            _diretorio.DeletarArquivoEmDiretorio(respostaArquivoModel.ColaboradorId, respostaArquivoModel.Anexo.Codigo, respostaArquivoModel.Anexo.Extensao);

            return respostaArquivoDeletado;
        }
    }
}
