using Autenticacao.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Infra.EF
{
    public class AutenticacaoContext : DbContext
    {
        public DbSet<UsuarioDoSistemaModel> UsuariosDoSistema { get; set; }

        public AutenticacaoContext(DbContextOptions<AutenticacaoContext> options) : base(options) { }
    }
}
