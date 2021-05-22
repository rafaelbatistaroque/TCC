using Paperless.Shared.Utils;

namespace Arquivo.Domain.ValueObjects
{
    public class Anexo
    {
        public string Codigo { get; }
        public int Tipo { get; }
        public string Nome { get; }
        public string Extensao { get; }
        public string LinkParaDownload { get; }

        private Anexo(int tipo, string extensao)
        {
            Tipo = tipo;
            Extensao = extensao;
        }

        private Anexo(int tipo, string extensao, string codigo)
            : this(tipo, extensao)
        {
            Codigo = codigo;
        }

        private Anexo(int tipo, string extensao, string nome, string linkParaDownload)
            : this(tipo, extensao)
        {
            Nome = nome;
            LinkParaDownload = linkParaDownload;
        }

        public static Anexo Retornar(int tipo, string codigoAnexo, string extensao)
        {
            var tipoValidado = Padronizacoes.ValidarTipoAnexoId(tipo);
            var nome = Padronizacoes.ObterTipoAnexoNome(tipoValidado);
            var linkParaDownload = Padronizacoes.MontarLinkParaDownloadAnexo(tipo, codigoAnexo);

            return new Anexo(tipoValidado, extensao, nome, linkParaDownload);
        }

        public static Anexo Criar(int tipo, string extensao)
        {
            var tipoValidado = Padronizacoes.ValidarTipoAnexoId(tipo);
            var codigo = Padronizacoes.GerarSequenciaIdentificacaoAnexo();

            return new Anexo(tipoValidado, extensao, codigo);
        }
    }
}
