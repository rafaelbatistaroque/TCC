using Colaborador.Domain.ValueObjects;

namespace Colaborador.Domain.Entidades
{
    public class ColaboradorEmpresa
    {
        public ColaboradorNome ColaboradorNome { get; }
        public CPF ColaboradorCPF { get; }
        public ColaboradorFuncao Funcao { get; }

        private ColaboradorEmpresa(ColaboradorNome colaboradorNome, CPF colaboradorCPF, ColaboradorFuncao colaboradorFuncaoEmpresa)
        {
            ColaboradorNome = colaboradorNome;
            ColaboradorCPF = colaboradorCPF;
            Funcao = colaboradorFuncaoEmpresa;
        }

        public static ColaboradorEmpresa Criar(string primeiroNome, string sobrenome, string colaboradorCPF, int colaboradorFuncaoEmpresa)
        {
            return new ColaboradorEmpresa(ColaboradorNome.Criar(primeiroNome, sobrenome), CPF.Criar(colaboradorCPF), ColaboradorFuncao.Criar(colaboradorFuncaoEmpresa));
        }

        public static ColaboradorEmpresa Retornar(string nomeCompleto, string colaboradorCPF, int colaboradorFuncaoEmpresa)
        {
            return new ColaboradorEmpresa(ColaboradorNome.Retornar(nomeCompleto), CPF.Retornar(colaboradorCPF), ColaboradorFuncao.Criar(colaboradorFuncaoEmpresa));
        }
    }
}
