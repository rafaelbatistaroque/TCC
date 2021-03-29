using Paperless.Shared.Utils;
using Usuario.Business.Contracts;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Facades
{
    public class UsuarioFacades : IUsuarioFacades
    {
        private readonly IUsuarioFactories _factories;

        public UsuarioFacades(IUsuarioFactories factories)
        {
            _factories = factories;
        }

        public UsuarioDoSistema CriarNovoUsuarioFacades(string usuarioNome, string usuarioSenha, int usuarioPerfil)
        {
            var usuarioComPerfil = _factories.ObterPerfilUsuarioFactory(usuarioPerfil);
            var senhaCriptografada = PaperlessPadronizacoes.CriptografarParaBase64(usuarioSenha);

            return UsuarioDoSistema.Criar(usuarioNome, senhaCriptografada, usuarioComPerfil);
        }
    }
}
