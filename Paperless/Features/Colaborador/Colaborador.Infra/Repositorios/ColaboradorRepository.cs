using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Infra.EF;
using System.Collections.Generic;
using System.Linq;

namespace Colaborador.Infra.Repositorios
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly ColaboradorContext _context;

        public ColaboradorRepository(ColaboradorContext context)
        {
            _context = context;
        }

        public bool AlterarColaborador(ColaboradorModel colaborador)
        {
            _context.Colaborador.Update(colaborador);
            var linhasAfetadas = _context.SaveChanges();

            return linhasAfetadas > 0;
        }

        public bool CriarColaborador(ColaboradorModel colaborador)
        {
            _context.Colaborador.Add(colaborador);
            var linhasAfetadas = _context.SaveChanges();

            return linhasAfetadas > 0;
        }

        public bool DeletarColaborador(ColaboradorModel colaborador)
        {
            _context.Colaborador.Remove(colaborador);
            var linhasAfetadas = _context.SaveChanges();

            return linhasAfetadas > 0;
        }

        public bool ExisteColaborador(int id)
        {
            return _context.Colaborador.Any(c => c.Id == id);
        }

        public ColaboradorModel ObterColaborador(int id)
        {
            return _context.Colaborador.FirstOrDefault(c => c.Id == id);
        }

        public IReadOnlyCollection<ColaboradorModel> ObterColaboradores()
        {
            return _context.Colaborador.ToList();
        }
    }
}
