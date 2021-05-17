using Paperless.Shared.Utils;

namespace Usuario.Domain.CasosDeUso.AlterarStatusUsuario
{
    public interface IAlterarStatusUsuario : IHandler<AlterarStatusUsuarioCommand, bool>
    {
    }
}
