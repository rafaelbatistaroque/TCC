using Paperless.Shared.Utils;

namespace Colaborador.Domain.CasosDeUso.AdicionarColaborador
{
    public interface IAdicionarColaborador : IHandler<AdicionarColaboradorCommand, bool>
    {
    }
}
