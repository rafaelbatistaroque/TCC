using Usuario.Domain.Entidades;

namespace Usuario.Business.Contracts.Extensoes
{
    public interface ICriarUsuarioFacades
    {
        UsuarioDoSistema CriarNovoUsuarioFacades(string usuarioNome, string usuarioSenha, int usuarioPerfil);
    }
}
