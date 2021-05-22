using Arquivo.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Arquivo.Infra.EF.Mapping
{
    public class ArquivoMapping : IEntityTypeConfiguration<ArquivoModel>
    {
        public void Configure(EntityTypeBuilder<ArquivoModel> construir)
        {
            construir.ToTable("Arquivo");
            construir.HasKey(x => x.Id);
            construir.Property(x => x.ColaboradorId).HasColumnType("int").IsRequired();
            construir.Property(x => x.MesReferencia).HasMaxLength(2).HasColumnType("varchar(2)").IsRequired();
            construir.Property(x => x.AnoReferencia).HasMaxLength(4).HasColumnType("varchar(4)").IsRequired();
            construir.Property(x => x.DataCadastro).HasColumnType("varchar(10)").IsRequired();
            construir.Property(x => x.Observacoes).HasColumnType("varchar(max)");

            construir.OwnsOne(x => x.Anexo,
                a => a.Property(a => a.Codigo).HasMaxLength(10).HasColumnType("varchar(10)").HasColumnName("AnexoCodigo"));
            construir.OwnsOne(x => x.Anexo,
                a => a.Property(a => a.Tipo).HasMaxLength(1).HasColumnType("int").HasColumnName("AnexoTipo").IsRequired());
            construir.OwnsOne(x => x.Anexo,
                a => a.Property(a => a.Extensao).HasMaxLength(5).HasColumnType("varchar(5)").HasColumnName("AnexoExtensao").IsRequired());
        }
    }
}
