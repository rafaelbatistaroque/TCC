using Microsoft.AspNetCore.Http;
using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Arquivo.Domain.CasosDeUso.CriarArquivo
{
    public class CriarArquivoCommand : ArquivoCommandQueryValidacoes, ICommandQueryBase
    {
        public int ColaboradorId { get; set; }
        public string ReferenciaMes { get; set; }
        public string ReferenciaAno { get; set; }
        public int TipoArquivo { get; set; }
        public IFormFile Anexo { get; set; }
        public string Observacoes { get; set; }

        public void Validar()
        {
            ValidarReferenciaMes(ReferenciaMes);
            ValidarReferenciaAno(ReferenciaAno);
            ValidarTipoArquivo(TipoArquivo);
            ValidarAnexo(Anexo);
            ValidarArquivoObservacoes(Observacoes);
        }
    }
}
