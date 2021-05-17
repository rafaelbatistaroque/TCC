using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System.Linq;
using Usuario.Business.Contracts;
using Usuario.Domain.CasosDeUso.CriarUsuario;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Services
{
    public class CriarUsuarioHandler : ICriarUsuario
    {
        private readonly IUsuarioRepository _repositorio;
        private readonly IUsuarioAdapters _adapter;

        public CriarUsuarioHandler(IUsuarioRepository repositorio, IUsuarioAdapters adapter)
        {
            _repositorio = repositorio;
            _adapter = adapter;
        }

        public Either<ErroBase, bool> Handler(CriarUsuarioCommand command)
        {
            command.Validar();
            if(command.Invalid)
                return new ErroValidacaoCommandQuery(command.Notifications.Select(e => e.Message).ToArray());

            var novoUsuario = UsuarioDoSistema.Criar(command.UsuarioNome, command.UsuarioSenha, command.UsuarioPerfil);
            var novoUsuarioModel = _adapter.DeUsuarioDoSistemaParaUsuarioDoSistemaModel(novoUsuario);

            var usuarioPersistido = _repositorio.CriarUsuario(novoUsuarioModel);
            if(usuarioPersistido.EhFalha)
                return usuarioPersistido.Falha;

            return usuarioPersistido.Sucesso;
        }
    }
}
