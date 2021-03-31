using Usuario.Domain.ValueObjects;

namespace Usuario.Domain.Entidades
{
    public class UsuarioDoSistema
    {
        public Identificacao UsuarioIdentificacao { get;}
        public string UsuarioNome { get;  }
        public UsuarioSenha UsuarioSenha { get;  }
        public bool EhUsuarioAtivo { get;  }
        public UsuarioPerfil UsuarioPerfil { get; }

        private UsuarioDoSistema(Identificacao usuarioIdentificador, string nomeUsuario, UsuarioSenha senha, UsuarioPerfil perfil)
        {
            UsuarioIdentificacao = usuarioIdentificador;
            UsuarioNome = nomeUsuario;
            UsuarioSenha = senha;
            EhUsuarioAtivo = true;
            UsuarioPerfil = perfil;
        }

        public static UsuarioDoSistema Criar(string usuarioNome, string usuarioSenha, int perfil)
        {
            return new UsuarioDoSistema(Identificacao.Criar(), usuarioNome, UsuarioSenha.Criar(usuarioSenha), UsuarioPerfil.Criar(perfil));
        }
    }
}
