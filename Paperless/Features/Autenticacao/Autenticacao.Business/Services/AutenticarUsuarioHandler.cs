using Autenticacao.Business.Contracts;
using Autenticacao.Domain.CasosDeUso.AutenticarUsuario;
using Autenticacao.Domain.Entidades;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System.Linq;

namespace Autenticacao.Business.Services
{
    public class AutenticarUsuarioHandler : IAutenticarUsuario
    {
        private readonly IAutenticacaoRepository _repositorio;
        private readonly IJWT _tokenServico;

        public AutenticarUsuarioHandler(IAutenticacaoRepository repositorio, IJWT tokenServico)
        {
            _repositorio = repositorio;
            _tokenServico = tokenServico;
        }

        public Either<ErroBase, UsuarioAutenticado> Handler(AutenticarUsuarioCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoParametrosCommand(command.Notifications.Select(e => e.Message).ToArray());

            var usuario = _repositorio.ObterUsuario(command.UsuarioIdentificador, command.Senha);
            if(usuario.EhFalha)
                return usuario.Falha;

            var token = _tokenServico.GerarToken(usuario.Sucesso.UsuarioIdentificador, usuario.Sucesso.Perfil);
            var usuarioAutenticado = UsuarioAutenticado.Criar(usuario.Sucesso.NomeUsuario, token);

            return usuarioAutenticado;
        }
    }
}
