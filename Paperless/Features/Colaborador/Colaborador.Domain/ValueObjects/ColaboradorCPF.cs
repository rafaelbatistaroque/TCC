using Paperless.Shared.Utils;

namespace Colaborador.Domain.ValueObjects
{
    public sealed class ColaboradorCPF
    {
        public string NumeroCPF { get; }

        private ColaboradorCPF(string numeroCPF)
        {
            NumeroCPF = numeroCPF;
        }

        public static ColaboradorCPF Criar(string colaboradorCPF)
        {
            var cpfFormatado = PaperlessPadronizacoes.RemoverCaracteresDeCPF(colaboradorCPF);

            return new ColaboradorCPF(cpfFormatado);
        }
    }
}
