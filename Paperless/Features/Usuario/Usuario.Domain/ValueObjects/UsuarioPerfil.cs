using Paperless.Shared.Enums;
using System;
using System.Collections.Generic;

namespace Usuario.Domain.ValueObjects
{
    public sealed class UsuarioPerfil
    {
        public int PerfilId { get; }
        public string PerfilNome { get; }

        private UsuarioPerfil(int perfilId, string perfilNome)
        {
            PerfilId = perfilId;
            PerfilNome = perfilNome;
        }

        public static UsuarioPerfil Criar(int perfil)
        {
            var perfis = new Dictionary<int, UsuarioPerfil>()
            {
                {(int)EUsuarioPerfil.ADMINISTRADOR, new UsuarioPerfil((int)EUsuarioPerfil.ADMINISTRADOR, Enum.GetName(typeof(EUsuarioPerfil), (int)EUsuarioPerfil.ADMINISTRADOR))},
                {(int)EUsuarioPerfil.USUARIO, new UsuarioPerfil((int)EUsuarioPerfil.USUARIO, Enum.GetName(typeof(EUsuarioPerfil), (int)EUsuarioPerfil.USUARIO))}
            };

            if(perfis.ContainsKey(perfil) == false)
                return perfis[(int)EUsuarioPerfil.USUARIO];

            return perfis[perfil];
        }
    }
}
