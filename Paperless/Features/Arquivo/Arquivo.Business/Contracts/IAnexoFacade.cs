using Microsoft.AspNetCore.Http;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;

namespace Arquivo.Business.Contracts
{
    public interface IAnexoFacade
    {
        Either<ErroBase, bool> SalvarAnexoEmDiretorio(IFormFile anexo, string arquivoCodigo);
    }
}
