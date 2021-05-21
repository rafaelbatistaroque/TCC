using Arquivo.Business.Models;
using Arquivo.Infra.EF.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Arquivo.Infra.EF
{
    public class ArquivoContext : DbContext
    {
        public DbSet<ArquivoModel> Arquivos { get; set; }
        public DbSet<ColaboradorModel> Colaborador { get; set; }

        public ArquivoContext(DbContextOptions<ArquivoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Ignore<ColaboradorModel>();
            modelBuilder.ApplyConfiguration(new ArquivoMapping());
        }
    }
}
