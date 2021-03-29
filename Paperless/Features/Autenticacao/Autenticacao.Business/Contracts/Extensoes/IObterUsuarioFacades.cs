using Autenticacao.Business.Models;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;

namespace Autenticacao.Business.Contracts.Extensoes
{
    public interface IObterUsuarioFacades
    {
        Either<ErroBase, UsuarioDoSistemaModel> ObterUsuarioFacades(string codigoIdentificacao);
    }
}
