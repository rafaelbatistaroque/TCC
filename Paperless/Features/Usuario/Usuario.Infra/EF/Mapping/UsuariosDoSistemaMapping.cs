using Usuario.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Usuario.Infra.EF.Mapping
{
    public class UsuariosDoSistemaMapping : IEntityTypeConfiguration<UsuarioDoSistemaModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioDoSistemaModel> montar)
        {
            montar.ToTable("UsuarioDoSistema");
            montar.HasKey(x => x.Id);
            montar.Property(x => x.UsuarioIdentificacao).HasMaxLength(5).HasColumnType("varchar(5)");
            montar.Property(x => x.UsuarioNome).HasMaxLength(120).HasColumnType("varchar(120)");
            montar.Property(x => x.UsuarioPerfil).HasMaxLength(30).HasColumnType("varchar(30)");
            montar.Property(x => x.UsuarioSenha).HasMaxLength(15).HasColumnType("varchar(15)");
            montar.Property(x => x.EhUsuarioAtivo).IsRequired();
        }
    }
}
