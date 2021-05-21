using Arquivo.Business.Contracts;
using Arquivo.Business.Models;
using Arquivo.Infra.EF;
using Paperless.Shared.Erros;
using Paperless.Shared.Utils;
using System;
using System.Linq;

namespace Arquivo.Infra.Repositorios
{
    public class ArquivoRepository : IArquivoRepository
    {

        private readonly ArquivoContext _context;

        public ArquivoRepository(ArquivoContext context)
        {
            _context = context;
        }

        public Either<ErroBase, bool> PersistirArquivo(ArquivoModel arquivoModel)
        {
            try
            {
                _context.Arquivos.Add(arquivoModel);
                var linhasAfetadas = _context.SaveChanges();

                return linhasAfetadas > 0;
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }

        public Either<ErroBase, bool> ExisteColaborador(int ColaboradorId)
        {
            try
            {
                return _context.Colaborador.Any(c => c.Id == ColaboradorId);
            }
            catch(Exception e)
            {
                return new ErroComunicacaoBancoDeDados(e.Message);
            }
        }
    }
}
