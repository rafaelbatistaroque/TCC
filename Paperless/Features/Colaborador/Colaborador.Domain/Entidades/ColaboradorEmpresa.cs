using Colaborador.Domain.ValueObjects;

namespace Colaborador.Domain.Entidades
{
    public class ColaboradorEmpresa
    {
        public int Id { get; }
        public ColaboradorNome ColaboradorNome { get; }
        public CPF ColaboradorCPF { get; }
        public ColaboradorFuncao Funcao { get; }
        private ColaboradorEmpresa(ColaboradorNome colaboradorNome, CPF colaboradorCPF, ColaboradorFuncao colaboradorFuncaoEmpresa, int id = 0)
            : this(colaboradorNome, colaboradorFuncaoEmpresa)
        {
            ColaboradorCPF = colaboradorCPF;
            Id = id;
        }

        private ColaboradorEmpresa(ColaboradorNome colaboradorNome, ColaboradorFuncao colaboradorFuncaoEmpresa)
        {
            ColaboradorNome = colaboradorNome;
            Funcao = colaboradorFuncaoEmpresa;
        }

        private ColaboradorEmpresa(ColaboradorNome colaboradorNome, ColaboradorFuncao colaboradorFuncaoEmpresa, int id)
            : this(colaboradorNome, colaboradorFuncaoEmpresa)
        {
            Id = id;
        }

        public static ColaboradorEmpresa Criar(string primeiroNome, string sobrenome, string colaboradorCPF, int colaboradorFuncaoEmpresa)
        {
            return new ColaboradorEmpresa(ColaboradorNome.Criar(primeiroNome, sobrenome), CPF.Criar(colaboradorCPF), ColaboradorFuncao.Criar(colaboradorFuncaoEmpresa));
        }

        public static ColaboradorEmpresa Retornar(int id, string nomeCompleto, string colaboradorCPF, int colaboradorFuncaoEmpresa)
        {
            return new ColaboradorEmpresa(ColaboradorNome.Retornar(nomeCompleto), CPF.Retornar(colaboradorCPF), ColaboradorFuncao.Criar(colaboradorFuncaoEmpresa), id);
        }

        public static ColaboradorEmpresa Alterar(int id, string primeiroNome, string sobrenome, int colaboradorFuncaoEmpresa)
        {
            return new ColaboradorEmpresa(ColaboradorNome.Criar(primeiroNome, sobrenome), ColaboradorFuncao.Criar(colaboradorFuncaoEmpresa), id);
        }
    }
}
