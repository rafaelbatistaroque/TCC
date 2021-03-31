using Paperless.Shared.Enums;
using System;
using System.Collections.Generic;

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
            var funcoes = new Dictionary<int, string>()
            {
                {(int)EColaboradorFuncao.GERENTE, Enum.GetName(typeof(EColaboradorFuncao), (int)EColaboradorFuncao.GERENTE) },
                {(int)EColaboradorFuncao.AUXILIAR_ADMINISTRATIVO, Enum.GetName(typeof(EColaboradorFuncao), (int)EColaboradorFuncao.AUXILIAR_ADMINISTRATIVO) },
                {(int)EColaboradorFuncao.AUXILIAR_ESCRITORIO, Enum.GetName(typeof(EColaboradorFuncao), (int)EColaboradorFuncao.AUXILIAR_ESCRITORIO) },
                {(int)EColaboradorFuncao.PROGRAMADOR, Enum.GetName(typeof(EColaboradorFuncao), (int)EColaboradorFuncao.PROGRAMADOR) },
                {(int)EColaboradorFuncao.SERVICOS_GERAIS, Enum.GetName(typeof(EColaboradorFuncao), (int)EColaboradorFuncao.SERVICOS_GERAIS) },
            };

            if(funcoes.ContainsKey(funcaoId) == false)
                return new ColaboradorFuncao(funcaoId, funcoes[(int)EColaboradorFuncao.SERVICOS_GERAIS]);

            return new ColaboradorFuncao(funcaoId, funcoes[funcaoId]);
        }
    }
}
