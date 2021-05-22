using Arquivo.Business.Models;
using Arquivo.Domain.Entidades;
using System.Collections.Generic;

namespace Arquivo.Business.Contracts
{
    public interface IArquivoAdapter
    {
        ArquivoModel DeArquivoRegistadoParaArquivoModel(ArquivoRegistrado arquivoRegistrado);
        IReadOnlyCollection<ArquivoRegistrado> DeListaArquivoModelParaListaArquivoRegistado(IReadOnlyCollection<ArquivoModel> listaModel);
    }
}
