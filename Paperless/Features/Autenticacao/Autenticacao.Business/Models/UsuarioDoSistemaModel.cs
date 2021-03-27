namespace Autenticacao.Business.Models
{
    public class UsuarioDoSistemaModel
    {
        public string UsuarioIdentificador { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public bool EhUsuarioAtivo { get; set; }
        public string Perfil { get; set; }
    }
}
