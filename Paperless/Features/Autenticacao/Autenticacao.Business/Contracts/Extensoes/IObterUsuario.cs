using Autenticacao.Business.Models;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;

namespace Autenticacao.Business.Contracts.Extensoes
{
    public interface IObterUsuario
    {
        Either<ErroBase, UsuarioModel> ObterUsuario(int usuarioIdentificador, string senha);
    }
}
