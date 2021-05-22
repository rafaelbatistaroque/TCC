using Arquivo.Business.Contracts;
using Arquivo.Business.Models;
using Arquivo.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;

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

        public IReadOnlyCollection<ArquivoRegistrado> DeListaArquivoModelParaListaArquivoRegistado(IReadOnlyCollection<ArquivoModel> listaModel)
        {
            return listaModel.Select(x =>
                ArquivoRegistrado.Retornar(
                    x.Id,
                    x.AnoReferencia,
                    x.MesReferencia,
                    x.Anexo.Tipo,
                    x.Anexo.Codigo,
                    x.Anexo.Extensao,
                    x.Observacoes,
                    x.DataCadastro
                )).ToList();
        }
    }
}
