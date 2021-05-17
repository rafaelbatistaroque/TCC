using System.Collections.Generic;
using Usuario.Business.Models;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Contracts
{
    public interface IUsuarioAdapters
    {
        UsuarioDoSistemaModel DeUsuarioDoSistemaParaUsuarioDoSistemaModel(UsuarioDoSistema entidadeUsuarioDoSitema);
        
        IReadOnlyCollection<UsuarioDoSistema> DeListaUsuarioDoSistemaModelParaListaUsuarioDoSistema(IReadOnlyCollection<UsuarioDoSistemaModel> listaModel);
    }
}
