using Usuario.Business.Models;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Contracts.Extensoes
{
    public interface IDeUsuarioDoSistemaParaUsuarioDoSistemaModel
    {
        UsuarioDoSistemaModel DeUsuarioDoSistemaParaUsuarioDoSistemaModel(UsuarioDoSistema entidadeUsuarioDoSitema);
    }
}
