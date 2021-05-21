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
            montar.Property(x => x.UsuarioNome).HasMaxLength(120).HasColumnType("varchar(120)");
            montar.Property(x => x.EhUsuarioAtivo).IsRequired();
            
            montar.OwnsOne(x => x.UsuarioIdentificacao,
                i => i.Property(i => i.Codigo).HasMaxLength(5).HasColumnType("varchar(5)").HasColumnName("UsuarioIdentificacao"));
           
            montar.OwnsOne(x => x.UsuarioPerfil,
                p => p.Property(p => p.PerfilId).HasColumnType("int").HasColumnName("UsuarioPerfilId"));

            montar.OwnsOne(s => s.UsuarioSenha,
                s => s.Property(x => x.Senha).HasMaxLength(15).HasColumnType("varchar(15)").HasColumnName("UsuarioSenha"));
        }
    }
}
