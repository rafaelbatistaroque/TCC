using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Paperless.Shared.Utils
{
    public class Padronizacoes
    {
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

        public static string ComTextoBearer(string token)
        {
            return $"Bearer {token}";
        }
    }
}
