using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Infra.EF;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System;
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

        public Either<ErroBase, bool> CriarColaborador(ColaboradorModel colaborador)
        {
            try
            {
                _context.Colaborador.Add(colaborador);
                var linhasAfetadas = _context.SaveChanges();

                return linhasAfetadas > 0;
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }

        public Either<ErroBase, bool> ExisteColaborador(int id)
        {
            try
            {
                return _context.Colaborador.Any(c => c.Id == id);
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }

        public Either<ErroBase, ColaboradorModel> ObterColaborador(int id)
        {
            try
            {
                return _context.Colaborador.FirstOrDefault(c => c.Id == id);
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }

        public Either<ErroBase, IReadOnlyCollection<ColaboradorModel>> ObterColaboradores()
        {
            try
            {
                return _context.Colaborador.ToList();
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }
    }
}
