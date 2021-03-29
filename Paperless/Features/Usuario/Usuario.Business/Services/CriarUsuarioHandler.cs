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
        private readonly IUsuarioAdapters _adapters;

        public CriarUsuarioHandler(IUsuarioRepository repositorio, IUsuarioFacades facades, IUsuarioAdapters adapters)
        {
            _repositorio = repositorio;
            _facades = facades;
            _adapters = adapters;
        }

        public Either<ErroBase, bool> Handler(CriarUsuarioCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoParametrosCommand(command.Notifications.Select(e => e.Message).ToArray());

            var novoUsuario = _facades.CriarNovoUsuarioFacades(command.UsuarioNome, command.UsuarioSenha, command.UsuarioPerfil);
            
            var model = _adapters.DeUsuarioDoSistemaParaUsuarioDoSistemaModel(novoUsuario);
            
            var usuarioPersistido = _repositorio.CriarUsuario(model);
            if(usuarioPersistido.EhFalha)
                return usuarioPersistido.Falha;

            return usuarioPersistido.Sucesso;
        }
    }
}
