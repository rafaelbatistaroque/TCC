using Colaborador.Business.Models;
using Colaborador.Domain.Entidades;

namespace Colaborador.Business.Contracts.Extensoes
{
    public interface IDeColaboradorParaColaboradorModelAdapter
    {
        ColaboradorModel DeColaboradorParaColaboradorModel(ColaboradorEmpresa c);
    }
}
