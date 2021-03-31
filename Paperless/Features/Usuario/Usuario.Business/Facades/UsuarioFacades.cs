using Usuario.Business.Contracts;
using Usuario.Business.Models;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Facades
{
    public class UsuarioFacades : IUsuarioFacades
    {
        private readonly IUsuarioAdapters _adapters;
        public UsuarioFacades(IUsuarioAdapters adapters)
        {
            _adapters = adapters;
        }

        public UsuarioDoSistemaModel CriarNovoUsuarioFacades(string usuarioNome, string usuarioSenha, int usuarioPerfil)
        {
            var novoUsuario = UsuarioDoSistema.Criar(usuarioNome, usuarioSenha, usuarioPerfil);
            var model = _adapters.DeUsuarioDoSistemaParaUsuarioDoSistemaModel(novoUsuario);
            return model;
        }
    }
}
