using Autenticacao.Business.Models;
using Autenticacao.Infra.Contracts;
using Microsoft.EntityFrameworkCore;
using Paperless.Shared.Utils;

namespace Autenticacao.Infra.EF
{
    public class AutenticacaoContext : DbContext, IAutenticacaoContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }

        public AutenticacaoContext(DbContextOptions options) : base(options) { }

        //protected override void OnModelCreating(ModelBuilder montarModel)
        //{
        //    montarModel.ApplyConfiguration();
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder opcao)
        //{
        //    opcao.UseSqlServer(@"Data Source=.\SQLEXPRESS;Database=DbTCC;trusted_connection=true;");
        //}
    }
}
