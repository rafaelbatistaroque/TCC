using Paperless.Shared.Utils;

namespace Usuario.Domain.ValueObjects
{
    public sealed class UsuarioSenha
    {
        public string Senha { get; }

        private UsuarioSenha(string senha)
        {
            Senha = senha;
        }

        public static UsuarioSenha Criar(string senha)
        {
            var senhaCriptografada = Padronizacoes.CriptografarParaBase64(senha);

            return new UsuarioSenha(senhaCriptografada);
        }
    }
}
