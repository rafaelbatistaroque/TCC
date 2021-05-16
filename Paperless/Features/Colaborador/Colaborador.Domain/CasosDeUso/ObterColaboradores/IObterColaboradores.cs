using Colaborador.Domain.Entidades;
using Paperless.Shared.Utils;
using System.Collections.Generic;

namespace Colaborador.Domain.CasosDeUso.ObterColaboradores
{
    public interface IObterColaboradores : IHandler<IReadOnlyCollection<ColaboradorEmpresa>>
    {
    }
}
