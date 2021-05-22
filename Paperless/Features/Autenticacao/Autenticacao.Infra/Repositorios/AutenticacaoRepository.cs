using Autenticacao.Business.Contracts;
using Autenticacao.Business.Models;
using Autenticacao.Infra.EF;
using Autenticacao.Infra.Queries;
using System.Linq;

namespace Autenticacao.Infra.Repositorios
{
    public class AutenticacaoRepository : IAutenticacaoRepository
    {
        private readonly AutenticacaoContext _context;

        public AutenticacaoRepository(AutenticacaoContext context)
        {
            _context = context;
        }

        public UsuarioDoSistemaModel ObterUsuario(string usuarioIdentificador)
        {
            return _context.UsuariosDoSistema.FirstOrDefault(Query.UsuarioAtivoComIdentificacao(usuarioIdentificador));
        }

        public bool UsuarioExiste(string codigoIdentificacao)
        {
            return _context.UsuariosDoSistema.Any(Query.UsuarioAtivoComIdentificacao(codigoIdentificacao));
        }
    }
}
