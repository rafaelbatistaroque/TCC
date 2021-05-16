using Flunt.Notifications;
using Flunt.Validations;
using Paperless.Shared.TextosInformativos;
using System.Text.RegularExpressions;

namespace Paperless.Shared.Validacoes
{
    public abstract class UsuarioCommandQueryValidacoes : Notifiable
    {
        protected void ValidarUsuarioNome(string usuarioNome)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(usuarioNome, nameof(usuarioNome), UsuarioTextosInformativos.USUARIO_NOME_NULO_VAZIO)
                .IsNotNullOrWhiteSpace(usuarioNome, nameof(usuarioNome), UsuarioTextosInformativos.USUARIO_NOME_NULO_ESPACO)
                .IsFalse(usuarioNome != null && Regex.IsMatch(usuarioNome, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(usuarioNome), UsuarioTextosInformativos.USUARIO_NOME_INVALIDO)
                );
        }

        protected void ValidarUsuarioSenha(string usuarioSenha)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(usuarioSenha, nameof(usuarioSenha), UsuarioTextosInformativos.USUARIO_SENHA_NULO_VAZIO)
                .IsNotNullOrWhiteSpace(usuarioSenha, nameof(usuarioSenha), UsuarioTextosInformativos.USUARIO_SENHA_NULO_ESPACO)
                .IsFalse(usuarioSenha != null && Regex.IsMatch(usuarioSenha, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(usuarioSenha), UsuarioTextosInformativos.USUARIO_SENHA_INVALIDO)
                );

        }

        protected void ValidarUsuarioPerfil(int usuarioPerfil)
        {
            AddNotifications(new Contract()
                .IsGreaterThan(usuarioPerfil, 0, nameof(usuarioPerfil), "")
                .HasMinLengthIfNotNullOrEmpty(usuarioPerfil.ToString(), 1, nameof(usuarioPerfil), "")
                );
        }
    }
}
