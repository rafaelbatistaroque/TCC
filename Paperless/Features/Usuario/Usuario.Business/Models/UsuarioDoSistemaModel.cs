namespace Usuario.Business.Models
{
    public class UsuarioDoSistemaModel
    {
        public int Id { get; set; }
        public string UsuarioIdentificacao { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioSenha { get; set; }
        public bool EhUsuarioAtivo { get; set; }
        public string UsuarioPerfil { get; set; }
    }
}
