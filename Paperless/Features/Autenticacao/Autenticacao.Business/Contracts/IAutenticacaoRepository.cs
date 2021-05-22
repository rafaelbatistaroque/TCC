using Autenticacao.Business.Models;

namespace Autenticacao.Business.Contracts
{
    public interface IAutenticacaoRepository
    {
        UsuarioDoSistemaModel ObterUsuario(string usuarioIdentificador);
        bool UsuarioExiste(string codigoIdentificacao);
    }
}
