using Flunt.Notifications;
using Flunt.Validations;
using Microsoft.AspNetCore.Http;
using Paperless.Shared.TextosInformativos;
using System.Text.RegularExpressions;

namespace Paperless.Shared.Validacoes
{
    public abstract class ArquivoCommandQueryValidacoes : Notifiable
    {
        protected void ValidarReferenciaMes(string referenciaMes)
        {
            AddNotifications(new Contract()
                .IsTrue(Regex.IsMatch(referenciaMes ?? string.Empty, @"^(0[1-9]|1[0-2]){1}$", RegexOptions.IgnoreCase), nameof(referenciaMes), ArquivoTextosInformativos.REFERENCIA_MES_INVALIDA)
                );
        }

        protected void ValidarReferenciaAno(string referenciaAno)
        {
            AddNotifications(new Contract()
                .IsTrue(Regex.IsMatch(referenciaAno ?? string.Empty, @"^(19|20)\d{2}$", RegexOptions.IgnoreCase), nameof(referenciaAno), ArquivoTextosInformativos.REFERENCIA_ANO_INVALIDA)
                );
        }

        protected void ValidarTipoArquivo(int tipoArquivo)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(tipoArquivo, 0, nameof(tipoArquivo), ArquivoTextosInformativos.TIPO_ARQUIVO_INVALIDO)
                .HasMinLengthIfNotNullOrEmpty(tipoArquivo.ToString(), 1, nameof(tipoArquivo), ArquivoTextosInformativos.TIPO_ARQUIVO_INVALIDO)
                );
        }

        protected void ValidarAnexo(IFormFile arquivoSubmetido)
        {
            AddNotifications(new Contract()
                .IsGreaterOrEqualsThan(arquivoSubmetido is null ? 0 : arquivoSubmetido.Length, 0, nameof(arquivoSubmetido), ArquivoTextosInformativos.ANEXO_VAZIO)
                );
        }

        protected void ValidarArquivoObservacoes(string observacoes)
        {
            AddNotifications(new Contract()
                .IsFalse(Regex.IsMatch(observacoes ?? string.Empty, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(observacoes), ArquivoTextosInformativos.OBSERVACOES_INVALIDAS)
                );
        }
    }
}
