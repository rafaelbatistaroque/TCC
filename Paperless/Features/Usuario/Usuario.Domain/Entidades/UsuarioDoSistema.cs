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

        private UsuarioDoSistema(Identificacao usuarioIdentificador, string nomeUsuario, bool ehUsuarioAtivo, UsuarioPerfil perfil)
        {
            UsuarioIdentificacao = usuarioIdentificador;
            UsuarioNome = nomeUsuario;
            EhUsuarioAtivo = ehUsuarioAtivo;
            UsuarioPerfil = perfil;
        }

        private UsuarioDoSistema(Identificacao usuarioIdentificador, string nomeUsuario, bool ehUsuarioAtivo, UsuarioPerfil perfil, UsuarioSenha senha) : this(usuarioIdentificador, nomeUsuario, ehUsuarioAtivo, perfil)
        {
            UsuarioSenha = senha;
        }

        public static UsuarioDoSistema Criar(string usuarioNome, string usuarioSenha, int perfilId)
        {
            return new UsuarioDoSistema(Identificacao.Criar(), usuarioNome,true, UsuarioPerfil.Criar(perfilId), UsuarioSenha.Criar(usuarioSenha));
        }

        public static UsuarioDoSistema Retornar(Identificacao usuarioIdentificador, string usuarioNome, bool ehUsuarioAtivo, UsuarioPerfil perfil)
        {
            return new UsuarioDoSistema(usuarioIdentificador, usuarioNome, ehUsuarioAtivo, UsuarioPerfil.Retornar(perfil.PerfilId));
        }
    }
}
