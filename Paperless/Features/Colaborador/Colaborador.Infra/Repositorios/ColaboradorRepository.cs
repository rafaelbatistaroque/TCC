using Colaborador.Business.Contracts;
using Colaborador.Business.Models;
using Colaborador.Infra.EF;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colaborador.Infra.Repositorios
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly ColaboradorContext _context;

        public ColaboradorRepository(ColaboradorContext context)
        {
            _context = context;
        }

        public Either<ErroBase, bool> CriarColaborado(ColaboradorModel colaborador)
        {
            try
            {
                _context.Add(colaborador);
                var linhasAfetadas = _context.SaveChanges();

                return linhasAfetadas > 0;
            }
            catch(Exception e)
            {
                //TODO: Enviar e-mail
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }
    }
}
