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
                    model.Nome.PrimeiroNome,
                    model.Nome.Sobrenome,
                    model.ColaboradorCPF.NumeroCPF,
                    model.FuncaoId);
        }

        public ColaboradorModel DeColaboradorParaColaboradorModel(ColaboradorEmpresa c)
        {
            return new ColaboradorModel()
            {
                Id = c.Id,
                ColaboradorCPF = c.ColaboradorCPF,
                Nome = c.ColaboradorNome,
                FuncaoId = c.Funcao.FuncaoId
            };
        }

        public IReadOnlyCollection<ColaboradorEmpresa> DeListaColaboradorModelParaListaColaboradorEmpresa(IReadOnlyCollection<ColaboradorModel> listaModel)
        {
            return listaModel.Select(l =>
                ColaboradorEmpresa.Retornar(
                    l.Id,
                    l.Nome.PrimeiroNome,
                    l.Nome.Sobrenome,
                    l.ColaboradorCPF.NumeroCPF,
                    l.FuncaoId)).ToList();
        }
    }
}
