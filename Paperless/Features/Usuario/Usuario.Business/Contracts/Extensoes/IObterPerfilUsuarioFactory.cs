using Usuario.Domain.ValueObjects;

namespace Usuario.Business.Contracts.Extensoes
{
    public interface IObterPerfilUsuarioFactory
    {
        UsuarioPerfil ObterPerfilUsuarioFactory(int perfil);
    }
}
