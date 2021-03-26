namespace Autenticacao.Business.Models
{
    public class UsuarioModel
    {
        public int UsuarioIdentificador { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public bool EhUsuarioAtivo { get; set; }
        public string Perfil { get; set; }
    }
}
