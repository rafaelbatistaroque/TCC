using Paperless.Shared.Utils;

namespace Usuario.Domain.Entidades
{
    public sealed class Identificacao
    {
        public string Codigo { get; }

        private Identificacao(string codigo)
        {
            Codigo = codigo;
        }

        public static Identificacao Criar()
        {
            var sequencia = PaperlessPadronizacoes.GerarSequenciaIdentificacao();
            return new Identificacao(sequencia);
        }
    }
}
