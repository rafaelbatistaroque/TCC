using Arquivo.Domain.Entidades;
using Paperless.Shared.Utils;

namespace Arquivo.Domain.CasosDeUso.DownloadArquivo
{
    public interface IRealizarDownloadDeArquivo : IHandler<RealizarDownloadArquivoCommand, ArquivoDownload>
    {
    }
}
