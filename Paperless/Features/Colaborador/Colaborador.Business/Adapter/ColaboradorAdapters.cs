using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Domain.Entidades;
using System.Collections.Generic;
using System.Linq;

namespace Colaborador.Business.Adapter
{
    public class ColaboradorAdapters : IColaboradorAdapters
    {
        public ColaboradorEmpresa DeColaboradorModelParaColaborador(ColaboradorModel model)
        {
            return ColaboradorEmpresa.Retornar(
                    model.Id,
                    model.Nome.NomeCompleto,
                    model.ColaboradorCPF.NumeroCPF,
                    model.Funcao.FuncaoId);
        }

        public ColaboradorModel DeColaboradorParaColaboradorModel(ColaboradorEmpresa c)
        {
            return new ColaboradorModel()
            {
                Id = c.Id,
                ColaboradorCPF = c.ColaboradorCPF,
                Nome = c.ColaboradorNome,
                Funcao = c.Funcao
            };
        }

        public IReadOnlyCollection<ColaboradorEmpresa> DeListaColaboradorModelParaListaColaboradorEmpresa(IReadOnlyCollection<ColaboradorModel> listaModel)
        {
            return listaModel.Select(l =>
                ColaboradorEmpresa.Retornar(
                    l.Id,
                    l.Nome.NomeCompleto,
                    l.ColaboradorCPF.NumeroCPF,
                    l.Funcao.FuncaoId)).ToList();
        }
    }
}
