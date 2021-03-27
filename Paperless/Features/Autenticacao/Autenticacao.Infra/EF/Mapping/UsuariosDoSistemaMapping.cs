using Autenticacao.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Autenticacao.Infra.EF.Mapping
{
    public class UsuariosDoSistemaMapping : IEntityTypeConfiguration<UsuarioDoSistemaModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioDoSistemaModel> montar)
        {
            montar.ToTable("UsuarioDoSistema")
                .HasKey(x => x.UsuarioIdentificador);
        }
    }
}
