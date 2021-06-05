using Paperless.Shared.Utils;

namespace Colaborador.Domain.ValueObjects
{
    public sealed class ColaboradorFuncao
    {
        public int FuncaoId { get; }
        public string FuncaoNome { get; }

        private ColaboradorFuncao(int funcaoId, string funcaoNome)
        {
            FuncaoId = funcaoId;
            FuncaoNome = funcaoNome;
        }

        public static ColaboradorFuncao Criar(int funcaoId)
        {
            var funcaoIdValidada = Padronizacoes.ValidarFuncao(funcaoId);
            var nomeFuncao = Padronizacoes.ObterFuncao(funcaoIdValidada);

            return new ColaboradorFuncao(funcaoId, nomeFuncao);
        }
    }
}
