using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Arquivo.Domain.CasosDeUso.DownloadArquivo
{
    public class RealizarDownloadArquivoCommand : ArquivoCommandQueryValidacoes, ICommandQueryBase
    {
        public int Id { get; set; }
        public string ArquivoCodigo { get; set; }

        public void Validar()
        {
            ValidarArquivoCodigo(ArquivoCodigo);
        }
    }
}
