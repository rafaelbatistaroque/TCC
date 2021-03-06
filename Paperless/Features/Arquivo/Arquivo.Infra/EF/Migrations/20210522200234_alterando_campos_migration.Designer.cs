// <auto-generated />
using Arquivo.Infra.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Arquivo.Infra.EF.Migrations
{
    [DbContext(typeof(ArquivoContext))]
    [Migration("20210522200234_alterando_campos_migration")]
    partial class alterando_campos_migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Arquivo.Business.Models.ArquivoModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AnoReferencia")
                        .IsRequired()
                        .HasMaxLength(4)
                        .HasColumnType("varchar(4)");

                    b.Property<int>("ColaboradorId")
                        .HasColumnType("int");

                    b.Property<string>("DataCadastro")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<string>("MesReferencia")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.Property<string>("Observacoes")
                        .HasColumnType("varchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Arquivo");
                });

            modelBuilder.Entity("Arquivo.Business.Models.ArquivoModel", b =>
                {
                    b.OwnsOne("Arquivo.Domain.ValueObjects.Anexo", "Anexo", b1 =>
                        {
                            b1.Property<int>("ArquivoModelId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Codigo")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("varchar(10)")
                                .HasColumnName("AnexoCodigo");

                            b1.Property<string>("Extensao")
                                .IsRequired()
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)")
                                .HasColumnName("AnexoExtensao");

                            b1.Property<int>("Tipo")
                                .HasMaxLength(1)
                                .HasColumnType("int")
                                .HasColumnName("AnexoTipo");

                            b1.HasKey("ArquivoModelId");

                            b1.ToTable("Arquivo");

                            b1.WithOwner()
                                .HasForeignKey("ArquivoModelId");
                        });

                    b.Navigation("Anexo");
                });
#pragma warning restore 612, 618
        }
    }
}
