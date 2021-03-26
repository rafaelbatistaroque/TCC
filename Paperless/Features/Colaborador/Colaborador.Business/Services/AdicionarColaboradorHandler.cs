using Colaborador.Domain.CasosDeUso.AdicionarColaborador;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System.Linq;

namespace Colaborador.Business.Services
{
    public class AdicionarColaboradorHandler : IAdicionarColaborador
    {
        public Either<ErroBase, bool> Handler(AdicionarColaboradorCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoParametrosCommand(command.Notifications.Select(e => e.Message).ToArray());

            return null;
        }
    }
}
