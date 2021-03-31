using Colaborador.Business.Contracts;
using Colaborador.Domain.CasosDeUso.CriarColaborador;
using Colaborador.Domain.Entidades;
using Paperless.Shared.Erros;
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
                return new ErroValidacaoParametrosCommand(command.Notifications.Select(e => e.Message).ToArray());

            var novoColaborador = ColaboradorEmpresa.Criar(command.ColaboradorPrimeiroNome, command.ColaboradorSobrenome, command.ColaboradorCPF, command.ColaboradorFuncaoEmpresa);
            var novoColaboradorModel = _adapters.DeColaboradorParaColaboradorModel(novoColaborador);

            var respostaRepositorio = _repositorio.CriarColaborado(novoColaboradorModel);
            if(respostaRepositorio.EhFalha)
                return respostaRepositorio.Falha;

            return respostaRepositorio.Sucesso;
        }
    }
}
