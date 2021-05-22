using Arquivo.Business.Adapters;
using Arquivo.Business.Contracts;
using Arquivo.Domain.CasosDeUso.ObterArquivos;
using Arquivo.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System.Collections.Generic;

namespace Arquivo.Business.Services
{
    public class ObterArquivosDeColaboradorHandler : IObterArquivosDeColaborador
    {
        private readonly IArquivoRepository _repositorio;
        private readonly IArquivoAdapter _adapter;

        public ObterArquivosDeColaboradorHandler(IArquivoRepository repositorio, IArquivoAdapter adapter)
        {
            _repositorio = repositorio;
            _adapter = adapter;
        }

        public Either<ErroBase, IReadOnlyCollection<ArquivoRegistrado>> Handler(int colaboradorId)
        {
            var ehColaboradorExistente = _repositorio.ExisteColaborador(colaboradorId);
            if(ehColaboradorExistente == false)
                return new ErroRegistroNaoEncontrado(ArquivoTextosInformativos.NENHUM_REGISTRO_ENCONTRADO);

            var arquivosModel = _repositorio.ObterArquivos(colaboradorId);
            var arquivo = _adapter.DeListaArquivoModelParaListaArquivoRegistado(arquivosModel);

            return arquivo as List<ArquivoRegistrado>;
        }
    }
}
