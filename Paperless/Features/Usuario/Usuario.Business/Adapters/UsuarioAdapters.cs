using Usuario.Business.Contracts;
using Usuario.Business.Models;
using Usuario.Domain.Entidades;

namespace Usuario.Business.Adapters
{
    public class UsuarioAdapters : IUsuarioAdapters
    {
        public UsuarioDoSistemaModel DeUsuarioDoSistemaParaUsuarioDoSistemaModel(UsuarioDoSistema u)
        {
            return new UsuarioDoSistemaModel
            {
                EhUsuarioAtivo = u.EhUsuarioAtivo,
                UsuarioIdentificacao = u.UsuarioIdentificacao.Codigo,
                UsuarioNome = u.UsuarioNome,
                UsuarioPerfil = u.UsuarioPerfil.PerfilNome,
                UsuarioSenha = u.UsuarioSenha
            };
        }
    }
}
