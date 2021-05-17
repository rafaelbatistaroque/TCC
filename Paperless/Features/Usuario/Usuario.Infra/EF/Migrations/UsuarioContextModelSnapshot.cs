﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Usuario.Infra.EF;

namespace Usuario.Infra.EF.Migrations
{
    [DbContext(typeof(UsuarioContext))]
    partial class UsuarioContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Usuario.Business.Models.UsuarioDoSistemaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("EhUsuarioAtivo")
                        .HasColumnType("bit");

                    b.Property<string>("UsuarioNome")
                        .HasMaxLength(120)
                        .HasColumnType("varchar(120)");

                    b.HasKey("Id");

                    b.ToTable("UsuarioDoSistema");
                });

            modelBuilder.Entity("Usuario.Business.Models.UsuarioDoSistemaModel", b =>
                {
                    b.OwnsOne("Usuario.Domain.ValueObjects.Identificacao", "UsuarioIdentificacao", b1 =>
                        {
                            b1.Property<int>("UsuarioDoSistemaModelId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Codigo")
                                .HasMaxLength(5)
                                .HasColumnType("varchar(5)")
                                .HasColumnName("UsuarioIdentificacao");

                            b1.HasKey("UsuarioDoSistemaModelId");

                            b1.ToTable("UsuarioDoSistema");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioDoSistemaModelId");
                        });

                    b.OwnsOne("Usuario.Domain.ValueObjects.UsuarioPerfil", "UsuarioPerfil", b1 =>
                        {
                            b1.Property<int>("UsuarioDoSistemaModelId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<int>("PerfilId")
                                .HasColumnType("int")
                                .HasColumnName("UsuarioPerfilId");

                            b1.HasKey("UsuarioDoSistemaModelId");

                            b1.ToTable("UsuarioDoSistema");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioDoSistemaModelId");
                        });

                    b.OwnsOne("Usuario.Domain.ValueObjects.UsuarioSenha", "UsuarioSenha", b1 =>
                        {
                            b1.Property<int>("UsuarioDoSistemaModelId")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("int")
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("Senha")
                                .HasMaxLength(15)
                                .HasColumnType("varchar(15)")
                                .HasColumnName("UsuarioSenha");

                            b1.HasKey("UsuarioDoSistemaModelId");

                            b1.ToTable("UsuarioDoSistema");

                            b1.WithOwner()
                                .HasForeignKey("UsuarioDoSistemaModelId");
                        });

                    b.Navigation("UsuarioIdentificacao");

                    b.Navigation("UsuarioPerfil");

                    b.Navigation("UsuarioSenha");
                });
#pragma warning restore 612, 618
        }
    }
}
