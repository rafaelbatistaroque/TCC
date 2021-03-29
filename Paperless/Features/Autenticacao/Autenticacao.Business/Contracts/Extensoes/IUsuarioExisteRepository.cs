using Paperless.Shared.Erros;
using Paperless.Shared.Utils;

namespace Autenticacao.Business.Contracts.Extensoes
{
    public interface IUsuarioExisteRepository
    {
        Either<ErroBase, bool> UsuarioExiste(string codigoIdentificacao);
    }
}
