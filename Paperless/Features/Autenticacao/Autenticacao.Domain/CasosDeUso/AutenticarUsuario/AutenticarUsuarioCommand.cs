using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;
using System;

namespace Autenticacao.Domain.CasosDeUso.AutenticarUsuario
{
    public class AutenticarUsuarioCommand : AutenticacaoCommandValidacoes, ICommandBase
    {
        public string UsuarioIdentificador { get; set; }
        public string Senha { get; set; }

        public void Validar()
        {
            ValidarUsuarioIdentificador(UsuarioIdentificador);
            ValidarSenha(Senha);
        }
    }
}
