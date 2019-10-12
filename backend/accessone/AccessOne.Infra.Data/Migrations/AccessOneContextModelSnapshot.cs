﻿// <auto-generated />
using System;
using AccessOne.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AccessOne.Infra.Data.Migrations
{
    [DbContext(typeof(AccessOneContext))]
    partial class AccessOneContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AccessOne.Domain.Entities.Comando", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ComandoStr")
                        .IsRequired()
                        .HasColumnName("ComandoStr");

                    b.Property<int?>("ComputadorId");

                    b.Property<DateTime?>("DataExecucao")
                        .IsRequired()
                        .HasColumnName("DataExecucao");

                    b.Property<DateTime>("DataRegistro")
                        .HasColumnName("DataRegistro");

                    b.Property<string>("Retorno")
                        .HasColumnName("Retorno");

                    b.HasKey("Id");

                    b.HasIndex("ComputadorId");

                    b.ToTable("Comando");
                });

            modelBuilder.Entity("AccessOne.Domain.Entities.Computador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EspacoEmDisco")
                        .HasColumnName("EspacoEmDisco");

                    b.Property<int?>("GrupoId");

                    b.Property<string>("Ip")
                        .IsRequired()
                        .HasColumnName("Ip");

                    b.Property<int>("MemoriaDisponivel")
                        .HasColumnName("Memoria");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Computador");
                });

            modelBuilder.Entity("AccessOne.Domain.Entities.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.ToTable("Grupo");
                });

            modelBuilder.Entity("AccessOne.Domain.Entities.Comando", b =>
                {
                    b.HasOne("AccessOne.Domain.Entities.Computador", "Computador")
                        .WithMany("Comandos")
                        .HasForeignKey("ComputadorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AccessOne.Domain.Entities.Computador", b =>
                {
                    b.HasOne("AccessOne.Domain.Entities.Grupo", "Grupo")
                        .WithMany()
                        .HasForeignKey("GrupoId");
                });
#pragma warning restore 612, 618
        }
    }
}
