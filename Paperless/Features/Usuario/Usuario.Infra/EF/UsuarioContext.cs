using Microsoft.EntityFrameworkCore;
using Usuario.Business.Models;
using Usuario.Infra.EF.Mapping;

namespace Usuario.Infra.EF
{
    public class UsuarioContext : DbContext
    {
        public DbSet<UsuarioDoSistemaModel> UsuarioDoSistema { get; set; }

        public UsuarioContext(DbContextOptions<UsuarioContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuariosDoSistemaMapping());
        }
    }
}
