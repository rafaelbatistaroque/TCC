﻿namespace Colaborador.Domain.Entidades
{
    public class Usuario
    {
        public int UsuarioIdentificador { get; set; }
        public string Senha { get; set; }
        public bool EhUsuarioAtivo { get; set; }
        public string Perfil { get; set; }
    }
}
