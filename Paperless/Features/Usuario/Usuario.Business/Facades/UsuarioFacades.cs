using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Either<ErroBase, UsuarioDoSistema> CriarNovoUsuarioFacades(string usuarioNome, string usuarioSenha, int usuarioPerfil)
        {
            throw new NotImplementedException();
            ////var usuarioPerfil = _factories.ObterPerfilUsuarioFactory(command.UsuarioPerfil);
            //var usuario = UsuarioDoSistema.Criar(command.UsuarioNome, command.UsuarioSenha, usuarioPerfil);
        }
    }
}
