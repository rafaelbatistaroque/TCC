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

        public ArquivoModel ObterArquivo(int arquivoId, string arquivoCodigo)
        {
            return _context.Arquivos.FirstOrDefault(x => x.Id == arquivoId && x.Anexo.Codigo == arquivoCodigo);
        }
        
        public ArquivoModel ObterArquivo(int arquivoId)
        {
            return _context.Arquivos.FirstOrDefault(x => x.Id == arquivoId);
        }

        public bool DeletarArquivo(ArquivoModel arquivoModel)
        {
            _context.Arquivos.Remove(arquivoModel);
            var linhasAfetadas = _context.SaveChanges();

            return linhasAfetadas > 0;
        }
    }
}
