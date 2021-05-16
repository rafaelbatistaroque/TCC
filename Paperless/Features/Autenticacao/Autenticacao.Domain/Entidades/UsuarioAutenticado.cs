using Paperless.Shared.Utils;

namespace Autenticacao.Domain.Entidades
{
    public class UsuarioAutenticado
    {
        public string NomeUsuario { get; }
        public string Token { get; }

        private UsuarioAutenticado(string nomeUsuario, string token)
        {
            NomeUsuario = nomeUsuario;
            Token = token;
        }

        public static UsuarioAutenticado Criar(string nomeUsuario, string token)
        {
            var tokenBearer = Padronizacoes.ComTextoBearer(token);

            return new UsuarioAutenticado(nomeUsuario, tokenBearer);
        }
    }
}
