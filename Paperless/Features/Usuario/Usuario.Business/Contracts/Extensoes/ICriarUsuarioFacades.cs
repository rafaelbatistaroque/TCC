using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Contracts.Extensoes
{
    public interface ICriarUsuarioFacades
    {
        Either<ErroBase, UsuarioDoSistema> CriarNovoUsuarioFacades(string usuarioNome, string usuarioSenha, int usuarioPerfil);
    }
}
