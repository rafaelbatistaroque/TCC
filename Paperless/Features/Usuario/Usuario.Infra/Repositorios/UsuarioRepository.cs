using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Usuario.Business.Contracts;
using Usuario.Business.Models;
using Usuario.Infra.EF;

namespace Usuario.Infra.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioContext _context;

        public UsuarioRepository(UsuarioContext context)
        {
            _context = context;
        }

        public Either<ErroBase, bool> AtualizarUsuario(UsuarioDoSistemaModel usuario)
        {
            try
            {
                _context.UsuarioDoSistema.Update(usuario);
                var linhasAfetadas = _context.SaveChanges();

                return linhasAfetadas > 0;
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }

        public Either<ErroBase, bool> CriarUsuario(UsuarioDoSistemaModel usuario)
        {
            try
            {
                _context.UsuarioDoSistema.Add(usuario);
                var linhasAfetadas = _context.SaveChanges();

                return linhasAfetadas > 0;
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }

        public Either<ErroBase, UsuarioDoSistemaModel> ObterUsuario(string codigo)
        {
            try
            {
                return _context.UsuarioDoSistema.FirstOrDefault(x => x.UsuarioIdentificacao.Codigo == codigo);
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }

        public Either<ErroBase, IReadOnlyCollection<UsuarioDoSistemaModel>> ObterUsuarios()
        {
            try
            {
                return _context.UsuarioDoSistema.ToList();
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }
    }
}
