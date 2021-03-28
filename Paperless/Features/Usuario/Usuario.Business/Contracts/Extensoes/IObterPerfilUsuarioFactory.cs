using Usuario.Domain.Entidades;

namespace Usuario.Business.Contracts.Extensoes
{
    public interface IObterPerfilUsuarioFactory
    {
        Perfil ObterPerfilUsuarioFactory(int perfil);
    }
}
