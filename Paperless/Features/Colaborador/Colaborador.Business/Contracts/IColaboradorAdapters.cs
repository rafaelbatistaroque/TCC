using Colaborador.Business.Models;
using Colaborador.Domain.Entidades;
using System.Collections.Generic;

namespace Colaborador.Business.Contracts
{
    public interface IColaboradorAdapters
    {
        ColaboradorModel DeColaboradorParaColaboradorModel(ColaboradorEmpresa colaborador);
        ColaboradorEmpresa DeColaboradorModelParaColaborador(ColaboradorModel model);
        IReadOnlyCollection<ColaboradorEmpresa> DeListaColaboradorModelParaListaColaboradorEmpresa(IReadOnlyCollection<ColaboradorModel> listaModel);
    }
}

