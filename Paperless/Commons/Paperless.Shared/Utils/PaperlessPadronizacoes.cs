using System;
using System.Text;

namespace Paperless.Shared.Utils
{
    public class PaperlessPadronizacoes
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
    }
}
