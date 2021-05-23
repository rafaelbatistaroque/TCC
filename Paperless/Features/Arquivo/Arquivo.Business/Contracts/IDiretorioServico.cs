using Microsoft.AspNetCore.Http;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;

namespace Arquivo.Business.Contracts
{
    public interface IDiretorioServico
    {
        Either<ErroBase, bool> SalvarAnexoEmDiretorio(IFormFile anexo, string arquivoCodigo);
        Either<ErroBase, byte[]> ObterArquivoEmDiretorio(string arquivoCodigo, string extensao);
    }
}
