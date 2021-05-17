using Paperless.Shared.Utils;

namespace Autenticacao.Domain.Entidades
{
    public class UsuarioAutenticado
    {
        public string NomeUsuario { get; }
        public int PerfilId { get; }
        public string Token { get; }

        private UsuarioAutenticado(string nomeUsuario, int perfilId, string token)
        {
            NomeUsuario = nomeUsuario;
            Token = token;
            PerfilId = perfilId;
        }

        public static UsuarioAutenticado Criar(string nomeUsuario, int perfilId, string token)
        {
            var tokenBearer = Padronizacoes.ComTextoBearer(token);

            return new UsuarioAutenticado(nomeUsuario, perfilId, tokenBearer);
        }
    }
}
