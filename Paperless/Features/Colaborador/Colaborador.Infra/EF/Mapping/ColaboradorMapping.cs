using Colaborador.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Colaborador.Infra.EF.Mapping
{
    public class ColaboradorMapping : IEntityTypeConfiguration<ColaboradorModel>
    {
        public void Configure(EntityTypeBuilder<ColaboradorModel> montar)
        {
            montar.ToTable("Colaborador");
            montar.HasKey(x => x.Id);
            montar.OwnsOne(x => x.Nome,
              n =>
              {
                  n.Property(n => n.PrimeiroNome).HasMaxLength(30).HasColumnType("varchar(30)").HasColumnName("PrimeiroNome");
                  n.Property(n => n.Sobrenome).HasMaxLength(100).HasColumnType("varchar(100)").HasColumnName("Sobrenome");
              });

            montar.Property(x => x.FuncaoId).HasColumnName("FuncaoId");

            montar.OwnsOne(x => x.ColaboradorCPF,
                c => c.Property(c => c.NumeroCPF).HasMaxLength(11).HasColumnType("varchar(11)").HasColumnName("NumeroCPF"));
        }
    }
}
