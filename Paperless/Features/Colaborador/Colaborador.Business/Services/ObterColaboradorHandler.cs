using Colaborador.Business.Contracts;
using Colaborador.Domain.CasosDeUso.ObterColaborador;
using Colaborador.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;

namespace Colaborador.Business.Services
{
    public class ObterColaboradorHandler : IObterColaborador
    {
        private readonly IColaboradorRepository _repositorio;
        private readonly IColaboradorAdapters _adapter;

        public ObterColaboradorHandler(IColaboradorRepository repositorio, IColaboradorAdapters adapter)
        {
            _repositorio = repositorio;
            _adapter = adapter;
        }

        public Either<ErroBase, ColaboradorEmpresa> Handler(int id)
        {
            var colaboradorModel = _repositorio.ObterColaborador(id);
            if(colaboradorModel is null)
                return new ErroRegistroNaoEncontrado(ColaboradorTextosInformativos.NENHUM_REGISTRO_ENCONTRADO);

            var colaborador = _adapter.DeColaboradorModelParaColaborador(colaboradorModel);

            return colaborador;
        }
    }
}
