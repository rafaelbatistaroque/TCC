using Microsoft.AspNetCore.Http;
using Paperless.Shared.Enums;
using Paperless.Shared.TextosInformativos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Paperless.Shared.Utils
{
    public class Padronizacoes
    {
        private const string HOST_5001 = "https://localhost:5001/api/v1/arquivo";

        private static readonly Dictionary<int, string> PERFIS = new Dictionary<int, string>()
            {
                {(int)EUsuarioPerfil.ADMINISTRADOR, ArquivoTextosInformativos.PERFIL_NOME_ADMINISTRADOR},
                {(int)EUsuarioPerfil.USUARIO, ArquivoTextosInformativos.PERFIL_NOME_USUARIO}
            };

        public static string MontarNomeArquivoComExtensao(string arquivoCodigo, string extensao)
        {
            return $"{arquivoCodigo}.{extensao}";
        }

        private static readonly Dictionary<int, string> TIPOS_ANEXO = new Dictionary<int, string>()
            {
                {(int)ETipoAnexo.ATESTADO, ArquivoTextosInformativos.TIPO_ANEXO_ATESTADO},
                {(int)ETipoAnexo.CARTAO_PONTO, ArquivoTextosInformativos.TIPO_ANEXO_CARTAO_PONTO },
                {(int)ETipoAnexo.HOLERITE, ArquivoTextosInformativos.TIPO_ANEXO_HOLERITE },
            };

        private static readonly Dictionary<int, string> FUNCOES = new Dictionary<int, string>()
            {
                {(int)EColaboradorFuncao.AUXILIAR_ADMINISTRATIVO, ArquivoTextosInformativos.FUNCAO_AUXILIAR_ADMINISTRATIVO},
                {(int)EColaboradorFuncao.AUXILIAR_ESCRITORIO, ArquivoTextosInformativos.FUNCAO_AUXILIAR_ESCRITORIO},
                {(int)EColaboradorFuncao.GERENTE, ArquivoTextosInformativos.FUNCAO_GERENTE},
                {(int)EColaboradorFuncao.PROGRAMADOR, ArquivoTextosInformativos.FUNCAO_PROGRAMADOR},
                {(int)EColaboradorFuncao.SERVICOS_GERAIS, ArquivoTextosInformativos.FUNCAO_SERVICOS_GERAIS},
            };

        public static string DescriptografarDeBase64(string senhaCriptografada)
        {
            var senhaByte = Convert.FromBase64String(senhaCriptografada);
            return Encoding.UTF8.GetString(senhaByte);
        }

        public static string CriptografarParaBase64(string senhaDescriptografada)
        {
            var senhaByte = Encoding.UTF8.GetBytes(senhaDescriptografada);
            return Convert.ToBase64String(senhaByte);
        }

        public static string RemoverCaracteresEspeciais(string item)
        {
            return Regex.Replace(item, @"[.\s-_*+!@#$%&()=/\\[\]{}:;,\|'<>]", "");
        }

        public static string AdicionarCaracteresEspeciaisEmCPF(string item)
        {
            return Regex.Replace(item, @"(\d{3})(\d{3})(\d{3})(\d{2})", "$1.$2.$3-$4");
        }

        public static string GerarSequenciaIdentificacao()
        {
            return Guid.NewGuid().ToString().Replace("-", "")[..5].ToUpper();
        }

        public static string GerarSequenciaIdentificacaoAnexo()
        {
            return Guid.NewGuid().ToString().Replace("-", "")[..10].ToUpper();
        }

        public static string ComTextoBearer(string token)
        {
            return $"Bearer {token}";
        }

        public static string ObterNomePerfil(int usuarioPerfil)
        {
            return PERFIS[usuarioPerfil];
        }

        public static int ValidarPerfilId(int perfilId)
        {
            return PERFIS.ContainsKey(perfilId) == false
                ? (int)EUsuarioPerfil.USUARIO
                : perfilId;
        }

        public static string ObterFuncao(int funcaoId)
        {
            return FUNCOES[funcaoId];
        }

        public static int ValidarFuncao(int funcaoId)
        {
            return FUNCOES.ContainsKey(funcaoId) == false
                ? (int)EColaboradorFuncao.SERVICOS_GERAIS
                : funcaoId;
        }

        public static string ObterTipoAnexoNome(int anexoId)
        {
            return TIPOS_ANEXO[anexoId];
        }

        public static int ValidarTipoAnexoId(int anexoId)
        {
            return TIPOS_ANEXO.ContainsKey(anexoId) == false
                ? (int)ETipoAnexo.NAO_ESPECIFICADO
                : anexoId;
        }

        public static string ExtrairExtensaoAnexo(IFormFile anexo)
        {
            return anexo.FileName.Split(".").Last();
        }

        public static string MontarLinkParaDownloadAnexo(int colaboradorId, string codigoAnexo)
        {
            return new StringBuilder()
                .Append(HOST_5001)
                .AppendFormat("/{0}", colaboradorId)
                .AppendFormat("/{0}", codigoAnexo)
                .ToString();
        }
    }
}
