using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using Usuario.Business.Models;

namespace Usuario.Business.Contracts.Extensoes
{
    public interface ICriarUsuarioRepository
    {
        Either<ErroBase, bool> CriarUsuario(UsuarioDoSistemaModel usuario);
    }
}
