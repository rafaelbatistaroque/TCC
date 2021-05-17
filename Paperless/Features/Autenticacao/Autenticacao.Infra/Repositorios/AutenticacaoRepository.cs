using Autenticacao.Business.Contracts;
using Autenticacao.Business.Models;
using Autenticacao.Infra.EF;
using Autenticacao.Infra.Queries;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System;
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

        public Either<ErroBase, UsuarioDoSistemaModel> ObterUsuario(string usuarioIdentificador)
        {
            try
            {
                return _context.UsuariosDoSistema.FirstOrDefault(Query.UsuarioAtivoComIdentificacao(usuarioIdentificador));
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }

        public Either<ErroBase, bool> UsuarioExiste(string codigoIdentificacao)
        {
            try
            {
                return _context.UsuariosDoSistema.Any(Query.UsuarioAtivoComIdentificacao(codigoIdentificacao));
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }
    }
}
