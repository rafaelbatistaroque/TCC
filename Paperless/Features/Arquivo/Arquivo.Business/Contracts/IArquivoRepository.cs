using Arquivo.Business.Models;
using System.Collections.Generic;

namespace Arquivo.Business.Contracts
{
    public interface IArquivoRepository
    {
        bool ExisteColaborador(int ColaboradorId);

        bool PersistirArquivo(ArquivoModel arquivoModel);

        IReadOnlyCollection<ArquivoModel> ObterArquivos(int colbaboradorId);
    }
}
