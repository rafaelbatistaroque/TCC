using Flunt.Notifications;
using Flunt.Validations;
using Paperless.Shared.TextosInformativos;
using System.Text.RegularExpressions;

namespace Paperless.Shared.Validacoes
{
    public abstract class AutenticacaoCommandValidacoes : Notifiable
    {
        protected void ValidarUsuarioIdentificador(int usuarioIdentificador)
        {
            AddNotifications(new Contract()
                .AreNotEquals(usuarioIdentificador, 0, nameof(usuarioIdentificador), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_NULA_VAZIA)
                .HasLen(usuarioIdentificador.ToString(), 4, nameof(usuarioIdentificador), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_MENOR_4_CARACTERES)
                .IsGreaterThan(usuarioIdentificador, 0, nameof(usuarioIdentificador), AutenticacaoTextosInformativos.USUARIO_IDENTIFICACAO_VALOR_NEGATIVO)
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
