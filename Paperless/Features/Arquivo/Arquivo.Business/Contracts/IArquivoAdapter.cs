using Arquivo.Business.Models;
using Arquivo.Domain.Entidades;

namespace Arquivo.Business.Contracts
{
    public interface IArquivoAdapter
    {
        ArquivoModel DeArquivoRegistadoParaArquivoModel(ArquivoRegistrado arquivoRegistrado);
    }
}
