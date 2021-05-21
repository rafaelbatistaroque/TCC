using Arquivo.Business.Models;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;

namespace Arquivo.Business.Contracts
{
    public interface IArquivoRepository
    {
        Either<ErroBase, bool> ExisteColaborador(int ColaboradorId);
        
        Either<ErroBase, bool> PersistirArquivo(ArquivoModel arquivoModel);
    }
}
