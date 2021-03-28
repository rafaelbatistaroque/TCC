using Paperless.Shared.Utils;

namespace Usuario.Domain.CasosDeUso.CriarUsuario
{
    public interface ICriarUsuario : IHandler<CriarUsuarioCommand, bool>
    {
    }
}
