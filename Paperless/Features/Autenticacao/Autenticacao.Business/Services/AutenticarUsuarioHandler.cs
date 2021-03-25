using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Autenticacao.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System;
using System.Linq;

namespace Autenticacao.Business.Services
{
    public class AutenticarUsuarioHandler : IAutenticarUsuario
    {
        public Either<ErroBase, UsuarioAutenticado> Handler(AutenticarUsuarioCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoParametrosCommand(command.Notifications.Select(e => e.Message).ToArray());

            return null;
        }
    }
}
