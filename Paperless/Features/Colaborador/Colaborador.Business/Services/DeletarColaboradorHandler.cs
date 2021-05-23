using Colaborador.Business.Contracts;
using Colaborador.Domain.CasosDeUso.DeletarColaborador;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;

namespace Colaborador.Business.Services
{
    public class DeletarColaboradorHandler : IDeletarColaborador
    {
        private readonly IColaboradorRepository _repositorio;

        public DeletarColaboradorHandler(IColaboradorRepository repositorio)
        {
            _repositorio = repositorio;
        }

        public Either<ErroBase, bool> Handler(int id)
        {
            var respostaColaboradorModel = _repositorio.ObterColaborador(id);
            if(respostaColaboradorModel is null)
                return new ErroRegistroNaoEncontrado(ColaboradorTextosInformativos.NENHUM_REGISTRO_ENCONTRADO);

            var respostaColaboradorDeletado = _repositorio.DeletarColaborador(respostaColaboradorModel);
            if(respostaColaboradorDeletado is false)
                return new ErroNenhumRegistroModificado(ColaboradorTextosInformativos.NENHUM_REGISTRO_MODIFICADO);

            return respostaColaboradorDeletado;
        }
    }
}
