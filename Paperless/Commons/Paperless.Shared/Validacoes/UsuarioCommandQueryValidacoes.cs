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
                .IsFalse(Regex.IsMatch(usuarioNome ?? string.Empty, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(usuarioNome), UsuarioTextosInformativos.USUARIO_NOME_INVALIDO)
                );
        }

        protected void ValidarUsuarioSenha(string usuarioSenha)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(usuarioSenha, nameof(usuarioSenha), UsuarioTextosInformativos.USUARIO_SENHA_NULO_VAZIO)
                .IsNotNullOrWhiteSpace(usuarioSenha, nameof(usuarioSenha), UsuarioTextosInformativos.USUARIO_SENHA_NULO_ESPACO)
                .IsFalse(Regex.IsMatch(usuarioSenha ?? string.Empty, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(usuarioSenha), UsuarioTextosInformativos.USUARIO_SENHA_INVALIDO)
                );

        }

        protected void ValidarUsuarioPerfil(int usuarioPerfil)
        {
            AddNotifications(new Contract()
                .IsNotNull(usuarioPerfil,nameof(usuarioPerfil), UsuarioTextosInformativos.USUARIO_PERFIL_NULO_VAZIO)
                .IsGreaterThan(usuarioPerfil, 0, nameof(usuarioPerfil), UsuarioTextosInformativos.USUARIO_PERFIL_INVALIDO)
                .HasMinLengthIfNotNullOrEmpty(usuarioPerfil.ToString(), 1, nameof(usuarioPerfil), UsuarioTextosInformativos.USUARIO_PERFIL_INVALIDO)
                );
        }

        protected void ValidarUsuarioCodigo(string usuarioCodigo)
        {
            AddNotifications(new Contract()
            .IsNotNullOrEmpty(usuarioCodigo, nameof(usuarioCodigo), UsuarioTextosInformativos.USUARIO_CODIGO_NULO_VAZIO)
            .IsNotNullOrWhiteSpace(usuarioCodigo, nameof(usuarioCodigo), UsuarioTextosInformativos.USUARIO_CODIGO_NULO_ESPACO)
            .HasLen(usuarioCodigo, 5, nameof(usuarioCodigo), UsuarioTextosInformativos.USUARIO_CODIGO_INVALIDO)
            .IsFalse(Regex.IsMatch(usuarioCodigo ?? string.Empty, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(usuarioCodigo), UsuarioTextosInformativos.USUARIO_CODIGO_INVALIDO)
            );
        }
    }
}
