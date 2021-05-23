using Microsoft.EntityFrameworkCore;
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

        public bool AtualizarUsuario(UsuarioDoSistemaModel usuario)
        {
            _context.UsuarioDoSistema.Update(usuario);
            var linhasAfetadas = _context.SaveChanges();

            return linhasAfetadas > 0;
        }

        public bool CriarUsuario(UsuarioDoSistemaModel usuario)
        {
            _context.UsuarioDoSistema.Add(usuario);
            var linhasAfetadas = _context.SaveChanges();

            return linhasAfetadas > 0;
        }

        public UsuarioDoSistemaModel ObterUsuario(string codigo)
        {
            return _context.UsuarioDoSistema.FirstOrDefault(x => x.UsuarioIdentificacao.Codigo == codigo);
        }

        public IReadOnlyCollection<UsuarioDoSistemaModel> ObterUsuarios()
        {
            return _context.UsuarioDoSistema.AsNoTracking().AsQueryable().ToList();
        }
    }
}
