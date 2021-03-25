using Autenticacao.Domain.Entidades;
using Paperless.Shared.Utils;

namespace Autenticacao.Domain.CasosDeUso.AutenticarUsuario
{
    public interface IAutenticarUsuario : IHandler<AutenticarUsuarioCommand, UsuarioAutenticado>
    {
    }
}
