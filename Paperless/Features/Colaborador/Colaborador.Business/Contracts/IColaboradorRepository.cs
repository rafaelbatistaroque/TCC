using Colaborador.Business.Models;
using System.Collections.Generic;

namespace Colaborador.Business.Contracts
{
    public interface IColaboradorRepository
    {
        bool CriarColaborador(ColaboradorModel colaborador);
        IReadOnlyCollection<ColaboradorModel> ObterColaboradores();
        ColaboradorModel ObterColaborador(int id);
        bool ExisteColaborador(int id);
        bool DeletarColaborador(ColaboradorModel colaborador);
        bool AlterarColaborador(ColaboradorModel colaborador);
    }
}
