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
                return _context.UsuariosDoSistema.FirstOrDefault(Query.UsuarioAtivoComEstaIdentificacao(usuarioIdentificador));
            }
            catch(Exception e)
            {
                var erro =  new ErroComunicacaoBancoDeDados(e.Message);
                //TODO: Enviar e-mail desenvolvedor
                return erro;
            }
        }

        public Either<ErroBase, bool> UsuarioExiste(string codigoIdentificacao)
        {
            try
            {
                return _context.UsuariosDoSistema.Any(Query.UsuarioAtivoComEstaIdentificacao(codigoIdentificacao));
            }
            catch(Exception e)
            {
                var erro = new ErroComunicacaoBancoDeDados(e.Message);
                //TODO: Enviar e-mail desenvolvedor
                return erro;
            }
        }
    }
}
