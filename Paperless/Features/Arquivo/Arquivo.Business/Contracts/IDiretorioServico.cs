using Microsoft.AspNetCore.Http;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;

namespace Arquivo.Business.Contracts
{
    public interface IDiretorioServico
    {
        Either<ErroBase, bool> SalvarAnexoEmDiretorio(IFormFile anexo, int colaboradorId, string arquivoCodigo);
        void DeletarArquivoEmDiretorio(int colaboradorId, string arquivoCodigo, string extensao);
        Either<ErroBase, byte[]> ObterArquivoEmDiretorio(int colaboradorId, string arquivoCodigo, string extensao);
    }
}
