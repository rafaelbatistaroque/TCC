using Colaborador.Domain.Entidades;
using Paperless.Shared.Utils;

namespace Colaborador.Domain.CasosDeUso.ObterColaborador
{
    public interface IObterColaborador : IHandlerPrimitive<int, ColaboradorEmpresa>
    {
    }
}
