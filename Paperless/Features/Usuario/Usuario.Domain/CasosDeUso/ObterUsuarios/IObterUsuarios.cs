using Paperless.Shared.Utils;
using System.Collections.Generic;
using Usuario.Domain.Entidades;

namespace Usuario.Domain.CasosDeUso.ObterUsuarios
{
    public interface IObterUsuarios : IHandler<IReadOnlyCollection<UsuarioDoSistema>>
    {
    }
}
