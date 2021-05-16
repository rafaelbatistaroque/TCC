using Paperless.Shared.Utils;

namespace Colaborador.Domain.ValueObjects
{
    public sealed class CPF
    {
        public string NumeroCPF { get; }

        private CPF(string numeroCPF)
        {
            NumeroCPF = numeroCPF;
        }

        public static CPF Criar(string colaboradorCPF)
        {
            var cpfFormatado = Padronizacoes.RemoverCaracteresEspeciais(colaboradorCPF);

            return new CPF(cpfFormatado);
        }

        public static CPF Retornar(string colaboradorCPF)
        {
            var cpfFormatado = Padronizacoes.AdicionarCaracteresEspeciaisEmCPF(colaboradorCPF);

            return new CPF(cpfFormatado);
        }
    }
}
