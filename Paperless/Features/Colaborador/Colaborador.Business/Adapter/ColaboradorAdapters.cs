using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Domain.Entidades;

namespace Colaborador.Business.Adapter
{
    public class ColaboradorAdapters : IColaboradorAdapters
    {
        public ColaboradorModel DeColaboradorParaColaboradorModel(ColaboradorEmpresa c)
        {
            return new ColaboradorModel()
            {
                ColaboradorCPF = c.ColaboradorCPF,
                Nome = c.ColaboradorNome,
                Funcao = c.Funcao
            };
        }
    }
}
