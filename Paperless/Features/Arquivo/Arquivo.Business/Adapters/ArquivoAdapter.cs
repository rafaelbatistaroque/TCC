using Arquivo.Business.Contracts;
using Arquivo.Business.Models;
using Arquivo.Domain.Entidades;

namespace Arquivo.Business.Adapters
{
    public class ArquivoAdapter : IArquivoAdapter
    {
        public ArquivoModel DeArquivoRegistadoParaArquivoModel(ArquivoRegistrado c)
        {
            return new ArquivoModel()
            {
                ColaboradorId = c.ColaboradorId,
                MesReferencia = c.MesReferencia,
                AnoReferencia = c.AnoReferencia,
                DataCadastro = c.DataCadastro,
                Observacoes = c.Observacoes,
                Anexo = c.Anexo,
            };
        }
    }
}
