using Colaborador.Business.Models;
using Colaborador.Infra.EF.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Colaborador.Infra.EF
{
    public class ColaboradorContext : DbContext
    {
        public DbSet<ColaboradorModel> Colaborador { get; set; }

        public ColaboradorContext(DbContextOptions<ColaboradorContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ColaboradorMapping());
        }
    }
}
