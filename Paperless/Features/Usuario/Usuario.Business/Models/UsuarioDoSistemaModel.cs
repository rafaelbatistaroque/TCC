using Usuario.Domain.ValueObjects;

namespace Usuario.Business.Models
{
    public class UsuarioDoSistemaModel
    {
        public int Id { get; set; }
        public Identificacao UsuarioIdentificacao { get; set; }
        public string UsuarioNome { get; set; }
        public UsuarioSenha UsuarioSenha { get; set; }
        public bool EhUsuarioAtivo { get; set; }
        public UsuarioPerfil UsuarioPerfil { get; set; }
    }
}
