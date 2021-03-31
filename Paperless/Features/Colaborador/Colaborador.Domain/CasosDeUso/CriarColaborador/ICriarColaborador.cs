using Paperless.Shared.Utils;

namespace Colaborador.Domain.CasosDeUso.CriarColaborador
{
    public interface ICriarColaborador : IHandler<CriarColaboradorCommand, bool>
    {
    }
}
