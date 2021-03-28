using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacao.Business.Models
{
    [Table("UsuarioDoSistema")]
    public class UsuarioDoSistemaModel
    {
        public string UsuarioIdentificacao { get; set; }
        public string UsuarioNome { get; set; }
        public string UsuarioSenha { get; set; }
        public bool EhUsuarioAtivo { get; set; }
        public string UsuarioPerfil { get; set; }
    }
}
