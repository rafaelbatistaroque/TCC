using Autenticacao.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Infra.Contracts
{
    public interface IAutenticacaoContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
