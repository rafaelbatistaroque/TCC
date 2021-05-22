using Arquivo.Domain.Entidades;
using Paperless.Shared.Utils;
using System.Collections.Generic;

namespace Arquivo.Domain.CasosDeUso.ObterArquivos
{
    public interface IObterArquivosDeColaborador : IHandlerPrimitive<int, IReadOnlyCollection<ArquivoRegistrado>>
    {
    }
}
