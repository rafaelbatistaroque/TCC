using Colaborador.Business.Contracts;
using Colaborador.Domain.CasosDeUso.AlterarColaborador;
using Colaborador.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System.Linq;

namespace Colaborador.Business.Services
{
    public class AlterarColaboradorHandler : IAlterarColaborador
    {
        public readonly IColaboradorRepository _repositorio;
        public readonly IColaboradorAdapters _adapter;

        public AlterarColaboradorHandler(IColaboradorRepository repositorio, IColaboradorAdapters adapter)
        {
            _repositorio = repositorio;
            _adapter = adapter;
        }

        public Either<ErroBase, bool> Handler(AlterarColaboradorCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoCommandQuery(command.Notifications.Select(e => e.Message).ToArray());

            var respostaColaboradorExiste = _repositorio.ExisteColaborador(command.Id);
            if(respostaColaboradorExiste.EhFalha)
                return respostaColaboradorExiste.Falha;

            if(respostaColaboradorExiste.Sucesso is false)
                return new ErroRegistroNaoEncontrado(ColaboradorTextosInformativos.NENHUM_REGISTRO_ENCONTRADO);

            var colaboradorAlterado = ColaboradorEmpresa.Alterar(
                                                        command.Id,
                                                        command.PrimeiroNome,
                                                        command.Sobrenome,
                                                        command.FuncaoEmpresa);

            var colaboradorModel = _adapter.DeColaboradorParaColaboradorModel(colaboradorAlterado);

            var respostaColaborador = _repositorio.AlterarColaborador(colaboradorModel);
            if(respostaColaborador.EhFalha)
                return respostaColaborador.Falha;

            if(respostaColaborador.Sucesso is false)
                return new ErroNenhumRegistroModificado(ColaboradorTextosInformativos.NENHUM_REGISTRO_MODIFICADO);

            return respostaColaborador.Sucesso;
        }
    }
}
