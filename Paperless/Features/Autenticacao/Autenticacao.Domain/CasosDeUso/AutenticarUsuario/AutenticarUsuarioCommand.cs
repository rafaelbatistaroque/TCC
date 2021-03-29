using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Autenticacao.Domain.CasosDeUso.AutenticarUsuario
{
    public class AutenticarUsuarioCommand : AutenticacaoCommandValidacoes, ICommandBase
    {
        public string UsuarioIdentificacao { get; set; }
        public string UsuarioSenha { get; set; }

        public void Validar()
        {
            ValidarUsuarioIdentificacao(UsuarioIdentificacao);
            ValidarUsuarioSenha(UsuarioSenha);
        }
    }
}
