using Usuario.Business.Models;

namespace Usuario.Business.Contracts.Extensoes
{
    public interface ICriarUsuarioFacades
    {
        UsuarioDoSistemaModel CriarNovoUsuarioFacades(string usuarioNome, string usuarioSenha, int usuarioPerfil);
    }
}
