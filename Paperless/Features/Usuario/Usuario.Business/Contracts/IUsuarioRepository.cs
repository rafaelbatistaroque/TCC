using System.Collections.Generic;
using Usuario.Business.Models;

namespace Usuario.Business.Contracts
{
    public interface IUsuarioRepository
    {
        bool CriarUsuario(UsuarioDoSistemaModel usuario);

        IReadOnlyCollection<UsuarioDoSistemaModel> ObterUsuarios();

        UsuarioDoSistemaModel ObterUsuario(string codigo);

        bool AtualizarUsuario(UsuarioDoSistemaModel usuario);


    }
}
