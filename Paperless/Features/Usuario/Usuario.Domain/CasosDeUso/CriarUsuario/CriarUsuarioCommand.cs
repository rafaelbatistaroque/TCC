using Paperless.Shared.Utils;
using Paperless.Shared.Validacoes;

namespace Usuario.Domain.CasosDeUso.CriarUsuario
{
    public class CriarUsuarioCommand : UsuarioCommandQueryValidacoes, ICommandQueryBase
    {
        public string UsuarioNome { get; set; }
        public string UsuarioSenha { get; set; }
        public int UsuarioPerfil { get; set; }

        public void Validar()
        {
            ValidarUsuarioNome(UsuarioNome);
            ValidarUsuarioSenha(UsuarioSenha);
            ValidarUsuarioPerfil(UsuarioPerfil);
        }
    }
}
