using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System.Linq;
using Usuario.Business.Contracts;
using Usuario.Domain.CasosDeUso.CriarUsuario;

namespace Usuario.Business.Services
{
    public class CriarUsuarioHandler : ICriarUsuario
    {
        private readonly IUsuarioRepository _repositorio;
        private readonly IUsuarioFacades _facades;

        public CriarUsuarioHandler(IUsuarioRepository repositorio, IUsuarioFacades facades)
        {
            _repositorio = repositorio;
            _facades = facades;
        }

        public Either<ErroBase, bool> Handler(CriarUsuarioCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoParametrosCommand(command.Notifications.Select(e => e.Message).ToArray());

            var novoUsuario = _facades.CriarNovoUsuarioFacades(command.UsuarioNome, command.UsuarioSenha, command.UsuarioPerfil);

            var usuarioPersistido = _repositorio.CriarUsuario(novoUsuario);
            if(usuarioPersistido.EhFalha)
                return usuarioPersistido.Falha;

            return usuarioPersistido.Sucesso;
        }
    }
}
