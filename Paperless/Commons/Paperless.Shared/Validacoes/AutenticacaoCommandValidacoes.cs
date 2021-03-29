using Flunt.Notifications;
using Flunt.Validations;
using Paperless.Shared.TextosInformativos;
using System.Text.RegularExpressions;

namespace Paperless.Shared.Validacoes
{
    public abstract class AutenticacaoCommandValidacoes : Notifiable
    {
        protected void ValidarUsuarioIdentificacao(string usuarioIdentificacao)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(usuarioIdentificacao, nameof(usuarioIdentificacao), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_NULA_VAZIA)
                .IsNotNullOrWhiteSpace(usuarioIdentificacao, nameof(usuarioIdentificacao), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_NULA_ESPACOS)
                .HasLen(usuarioIdentificacao, 5, nameof(usuarioIdentificacao), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_MENOR_4_CARACTERES)
                .IsFalse(usuarioIdentificacao != null && Regex.IsMatch(usuarioIdentificacao, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(usuarioIdentificacao), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_INVALIDA)
                );
        }

        protected void ValidarUsuarioSenha(string senha)
        {
            AddNotifications(new Contract()
                .IsNotNullOrEmpty(senha, nameof(senha), AutenticacaoTextosInformativos.SENHA_NULA_VAZIA)
                .IsNotNullOrWhiteSpace(senha, nameof(senha), AutenticacaoTextosInformativos.SENHA_NULA_ESPACOS)
                .IsFalse(senha != null && Regex.IsMatch(senha, @"\w+\s+\d=[<>]?\d", RegexOptions.IgnoreCase), nameof(senha), AutenticacaoTextosInformativos.SENHA_INVALIDA)
                );
        }
    }
}
