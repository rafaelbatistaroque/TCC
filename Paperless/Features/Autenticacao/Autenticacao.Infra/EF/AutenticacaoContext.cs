using Autenticacao.Business.Models;
using Autenticacao.Infra.EF.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Infra.EF
{
    public class AutenticacaoContext : DbContext
    {
        public DbSet<UsuarioDoSistemaModel> UsuariosDoSistema { get; set; }

        public AutenticacaoContext(DbContextOptions<AutenticacaoContext> options) : base(options){}

        protected override void OnModelCreating(ModelBuilder montarModel)
        {
            montarModel.ApplyConfiguration(new UsuariosDoSistemaMapping());
        }
    }
}
