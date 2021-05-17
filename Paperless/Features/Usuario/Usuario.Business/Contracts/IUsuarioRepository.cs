using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System.Collections.Generic;
using Usuario.Business.Models;

namespace Usuario.Business.Contracts
{
    public interface IUsuarioRepository
    {
        Either<ErroBase, bool> CriarUsuario(UsuarioDoSistemaModel usuario);
        
        Either<ErroBase, IReadOnlyCollection<UsuarioDoSistemaModel>> ObterUsuarios();

        Either<ErroBase, UsuarioDoSistemaModel> ObterUsuario(string codigo);
        
        Either<ErroBase, bool> AtualizarUsuario(UsuarioDoSistemaModel usuario);


    }
}
