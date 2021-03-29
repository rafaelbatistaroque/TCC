using Autenticacao.Business.Models;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;

namespace Autenticacao.Business.Contracts.Extensoes
{
    public interface IObterUsuarioRepository
    {
        Either<ErroBase, UsuarioDoSistemaModel> ObterUsuario(string usuarioIdentificador);
    }
}
