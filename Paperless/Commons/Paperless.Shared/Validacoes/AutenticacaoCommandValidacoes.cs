using Flunt.Notifications;
using Flunt.Validations;
using Paperless.Shared.TextosInformativos;
using System.Text.RegularExpressions;

namespace Paperless.Shared.Validacoes
{
    public abstract class AutenticacaoCommandValidacoes : Notifiable
    {
        protected void ValidarUsuarioIdentificador(string usuarioIdentificador)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(usuarioIdentificador, nameof(usuarioIdentificador), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_NULA_VAZIA)
                .IsNotNullOrWhiteSpace(usuarioIdentificador, nameof(usuarioIdentificador), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_NULA_ESPACOS)
                .HasLen(usuarioIdentificador, 5, nameof(usuarioIdentificador), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_MENOR_4_CARACTERES)
                .IsFalse(usuarioIdentificador != null && Regex.IsMatch(usuarioIdentificador, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(usuarioIdentificador), AutenticacaoTextosInformativos.SUARIO_IDENTIFICACAO_INVALIDA)
                );
        }

        protected void ValidarSenha(string senha)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(senha, nameof(senha), AutenticacaoTextosInformativos.SENHA_NULA_VAZIA)
                .IsNotNullOrWhiteSpace(senha, nameof(senha), AutenticacaoTextosInformativos.SENHA_NULA_ESPACOS)
                .IsFalse(senha != null && Regex.IsMatch(senha, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(senha), AutenticacaoTextosInformativos.SENHA_INVALIDA)
                );
        }
    }
}
