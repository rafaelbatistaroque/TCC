using Paperless.Shared.Enums;
using System.Collections.Generic;
using Usuario.Business.Contracts;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Factories
{
    public class UsuarioFactories : IUsuarioFactories
    {
        public Perfil ObterPerfilUsuarioFactory(int perfil)
        {
            var perfis = new Dictionary<int, Perfil>()
            {
                {(int)EUsuarioPerfil.ADMINISTRADOR, Perfil.CriarPerfilAdministrador() },
                {(int)EUsuarioPerfil.USUARIO, Perfil.CriarPerfilUsuario() }
            };

            if(perfis.ContainsKey(perfil) == false)
                return perfis[(int)EUsuarioPerfil.USUARIO];

            return perfis[perfil];
        }
    }
}
