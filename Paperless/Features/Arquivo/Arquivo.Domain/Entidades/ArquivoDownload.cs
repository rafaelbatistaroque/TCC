using Paperless.Shared.Utils;

namespace Arquivo.Domain.Entidades
{
    public class ArquivoDownload
    {
        private const string APPLICATIO_DOWNLOAD = "application/force-download";

        public byte[] DadosByte { get; }
        public string Nome { get; }
        public string ApplicationForceDownload { get; }

        private ArquivoDownload(byte[] dadosByte, string nome)
        {
            DadosByte = dadosByte;
            Nome = nome;
            ApplicationForceDownload = APPLICATIO_DOWNLOAD;
        }

        public static ArquivoDownload Criar(byte[] dadosByte, string arquivoCodigo, string extensao)
        {
            var arquivoNome = Padronizacoes.MontarNomeArquivoComExtensao(arquivoCodigo, extensao);

            return new ArquivoDownload(dadosByte, arquivoNome);
        }
    }
}
