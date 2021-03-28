namespace Usuario.Domain.Entidades
{
    public class UsuarioDoSistema
    {
        public Identificacao UsuarioIdentificacao { get;}
        public string UsuarioNome { get;  }
        public string UsuarioSenha { get;  }
        public bool EhUsuarioAtivo { get;  }
        public Perfil UsuarioPerfil { get; }

        private UsuarioDoSistema(Identificacao usuarioIdentificador, string nomeUsuario, string senha, Perfil perfil)
        {
            UsuarioIdentificacao = usuarioIdentificador;
            UsuarioNome = nomeUsuario;
            UsuarioSenha = senha;
            EhUsuarioAtivo = true;
            UsuarioPerfil = perfil;
        }

        public static UsuarioDoSistema Criar(string usuarioNome, string usuarioSenha, Perfil perfil)
        {
            return new UsuarioDoSistema(Identificacao.Criar(), usuarioNome, usuarioSenha, perfil);
        }
    }
}
