﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SoftwareControle.Repositorio.Context;

#nullable disable

namespace SoftwareControle.Repositorio.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SoftwareControle.Models.FerramentaModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)")
                        .HasColumnName("Descricao");

                    b.Property<bool>("Disponivel")
                        .HasColumnType("bit");

                    b.Property<byte[]>("Imagem")
                        .HasColumnType("varbinary(max)")
                        .HasColumnName("Imagem");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)")
                        .HasColumnName("Nome");

                    b.Property<Guid>("UsuarioId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ferramentas", null, t =>
                        {
                            t.Property("DataAtualizacao")
                                .HasColumnName("DataAtualizacao1");
                        });
                });

            modelBuilder.Entity("SoftwareControle.Models.OrdemModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataCriacao")
                        .HasMaxLength(50)
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataPrazoMaximo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)")
                        .HasColumnName("Descricao");

                    b.Property<Guid>("FerramentaId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("FerramentaId");

                    b.Property<string>("NivelUrgencia")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("NivelUrgencia");

                    b.Property<string>("Situacao")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Situacao");

                    b.Property<Guid>("UsuarioId")
                        .HasMaxLength(50)
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("FerramentaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Ordens", null, t =>
                        {
                            t.Property("DataAtualizacao")
                                .HasColumnName("DataAtualizacao1");
                        });
                });

            modelBuilder.Entity("SoftwareControle.Models.UsuarioModel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Cargo");

                    b.Property<DateTime?>("DataAtualizacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DataAtualizacao");

                    b.Property<DateTime>("DataCriacao")
                        .HasMaxLength(100)
                        .HasColumnType("datetime2")
                        .HasColumnName("DataCriacao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)")
                        .HasColumnName("Senha");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Usuario");

                    b.HasKey("Id");

                    b.ToTable("Usuarios", (string)null);
                });

            modelBuilder.Entity("SoftwareControle.Models.FerramentaModel", b =>
                {
                    b.HasOne("SoftwareControle.Models.UsuarioModel", "Usuario")
                        .WithMany("Ferramenta")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SoftwareControle.Models.OrdemModel", b =>
                {
                    b.HasOne("SoftwareControle.Models.FerramentaModel", "Ferramenta")
                        .WithMany("Ordem")
                        .HasForeignKey("FerramentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SoftwareControle.Models.UsuarioModel", "Usuario")
                        .WithMany("Ordem")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Ferramenta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("SoftwareControle.Models.FerramentaModel", b =>
                {
                    b.Navigation("Ordem");
                });

            modelBuilder.Entity("SoftwareControle.Models.UsuarioModel", b =>
                {
                    b.Navigation("Ferramenta");

                    b.Navigation("Ordem");
                });
#pragma warning restore 612, 618
        }
    }
}
