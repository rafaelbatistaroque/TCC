using Colaborador.Business.Contracts;
using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Colaborador.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.TextosInformativos;
using Paperless.Shared.Utils;
using System.Linq;

namespace Colaborador.Business.Services
{
    public class CriarColaboradorHandler : ICriarColaborador
    {
        private readonly IColaboradorAdapters _adapters;
        private readonly IColaboradorRepository _repositorio;
        
        public CriarColaboradorHandler(IColaboradorAdapters adapters, IColaboradorRepository repositorio)
        {
            _adapters = adapters;
            _repositorio = repositorio;
        }

        public Either<ErroBase, bool> Handler(CriarColaboradorCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoCommandQuery(command.Notifications.Select(e => e.Message).ToArray());

            var novoColaborador = ColaboradorEmpresa.Criar(command.PrimeiroNome, command.Sobrenome, command.CPF, command.FuncaoEmpresa);
            var novoColaboradorModel = _adapters.DeColaboradorParaColaboradorModel(novoColaborador);

            var respostaRepositorio = _repositorio.CriarColaborador(novoColaboradorModel);
            if(respostaRepositorio.EhFalha)
                return respostaRepositorio.Falha;

            if(respostaRepositorio.Sucesso == false)
                return new ErroNenhumRegistroModificado(ColaboradorTextosInformativos.NENHUM_REGISTRO_MODIFICADO);

            return respostaRepositorio.Sucesso;
        }
    }
}
