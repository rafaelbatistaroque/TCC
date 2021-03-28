using Paperless.Shared.Enums;
using System;

namespace Usuario.Domain.Entidades
{
    public sealed class Perfil
    {
        public EUsuarioPerfil PerfilId { get; }
        public string PerfilNome { get; }

        private Perfil(EUsuarioPerfil perfilIdentificacao, string perfilNome)
        {
            PerfilId = perfilIdentificacao;
            PerfilNome = perfilNome;
        }

        public static Perfil CriarPerfilUsuario()
        {
            return new Perfil(EUsuarioPerfil.USUARIO, Enum.GetName(typeof(EUsuarioPerfil), (int)EUsuarioPerfil.USUARIO));
        }

        public static Perfil CriarPerfilAdministrador()
        {
            return new Perfil(EUsuarioPerfil.ADMINISTRADOR, Enum.GetName(typeof(EUsuarioPerfil), (int)EUsuarioPerfil.ADMINISTRADOR));
        }
    }
}
