using Arquivo.Business.Models;
using System.Collections.Generic;

namespace Arquivo.Business.Contracts
{
    public interface IArquivoRepository
    {
        bool ExisteColaborador(int ColaboradorId);

        bool PersistirArquivo(ArquivoModel arquivoModel);

        IReadOnlyCollection<ArquivoModel> ObterArquivos(int colbaboradorId);

        ArquivoModel ObterArquivo(int arquivoId, string arquivoCodigo);

        ArquivoModel ObterArquivo(int arquivoId);

        bool DeletarArquivo(ArquivoModel arquivoModel);
    }
}
