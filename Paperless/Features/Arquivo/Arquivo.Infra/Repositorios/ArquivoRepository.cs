using Arquivo.Business.Contracts;
using Arquivo.Business.Models;
using Arquivo.Infra.EF;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public bool PersistirArquivo(ArquivoModel arquivoModel)
        {
            _context.Arquivos.Add(arquivoModel);
            var linhasAfetadas = _context.SaveChanges();

            return linhasAfetadas > 0;
        }

        public bool ExisteColaborador(int ColaboradorId)
        {
            return _context.Colaborador.AsNoTracking().Any(c => c.Id == ColaboradorId);
        }

        public IReadOnlyCollection<ArquivoModel> ObterArquivos(int colbaboradorId)
        {
            return _context.Arquivos.AsNoTracking().Where(x => x.ColaboradorId == colbaboradorId).AsQueryable().ToList();
        }

        public ArquivoModel ObterArquivo(int id, string arquivoCodigo)
        {
            return _context.Arquivos.FirstOrDefault(x => x.Id == id && x.Anexo.Codigo == arquivoCodigo);
        }
    }
}
