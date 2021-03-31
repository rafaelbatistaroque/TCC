using Colaborador.Domain.ValueObjects;

namespace Colaborador.Domain.Entidades
{
    public class ColaboradorEmpresa
    {
        public ColaboradorNome ColaboradorNome { get; }
        public ColaboradorCPF ColaboradorCPF { get; }
        public ColaboradorFuncao Funcao { get; }

        private ColaboradorEmpresa(ColaboradorNome colaboradorNome, ColaboradorCPF colaboradorCPF, ColaboradorFuncao colaboradorFuncaoEmpresa)
        {
            ColaboradorNome = colaboradorNome;
            ColaboradorCPF = colaboradorCPF;
            Funcao = colaboradorFuncaoEmpresa;
        }

        public static ColaboradorEmpresa Criar(string primeiroNome, string sobrenome, string colaboradorCPF, int colaboradorFuncaoEmpresa)
        {
            return new ColaboradorEmpresa(ColaboradorNome.Criar(primeiroNome, sobrenome), ColaboradorCPF.Criar(colaboradorCPF), ColaboradorFuncao.Criar(colaboradorFuncaoEmpresa));
        }

    }
}
