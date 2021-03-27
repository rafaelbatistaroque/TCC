using Paperless.Shared.Utils;

namespace Colaborador.Domain.Entidades
{
    public class Colaborador
    {
        public string ColaboradorNome { get; }
        public string ColaboradorCPF { get; }
        public string ColaboradorFuncaoEmpresa { get; }

        private Colaborador(string colaboradorNome, string colaboradorCPF, string colaboradorFuncaoEmpresa)
        {
            ColaboradorNome = colaboradorNome;
            ColaboradorCPF = colaboradorCPF;
            ColaboradorFuncaoEmpresa = colaboradorFuncaoEmpresa;
        }

        public static Colaborador Criar(string colaboradorNome, string colaboradorCPF, string colaboradorFuncaoEmpresa)
        {
            var cpfFormatado = PaperlessPadronizacoes.RemoverCaracteresDeCPF(colaboradorCPF);

            return new Colaborador(colaboradorNome, cpfFormatado, colaboradorFuncaoEmpresa);
        }

    }
}
