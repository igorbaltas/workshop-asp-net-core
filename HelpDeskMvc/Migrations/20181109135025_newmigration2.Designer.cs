﻿// <auto-generated />
using System;
using HelpDeskMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelpDeskMvc.Migrations
{
    [DbContext(typeof(HelpDeskMvcContext))]
    [Migration("20181109135025_newmigration2")]
    partial class newmigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HelpDeskMvc.Models.Chamado", b =>
                {
                    b.Property<int>("idChamado")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartamentoId");

                    b.Property<int>("UsuarioId");

                    b.Property<DateTime>("dataAbertura");

                    b.Property<DateTime>("dataEncerramento");

                    b.Property<string>("descricaoChamado");

                    b.Property<int>("servicoId");

                    b.Property<string>("solucaoChamado");

                    b.Property<int>("status");

                    b.Property<int>("tecnicoId");

                    b.HasKey("idChamado");

                    b.HasIndex("DepartamentoId");

                    b.HasIndex("UsuarioId");

                    b.HasIndex("servicoId");

                    b.ToTable("Chamado");
                });

            modelBuilder.Entity("HelpDeskMvc.Models.Departamento", b =>
                {
                    b.Property<int>("idDpto")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("dsDpto");

                    b.HasKey("idDpto");

                    b.ToTable("Departamento");
                });

            modelBuilder.Entity("HelpDeskMvc.Models.Servico", b =>
                {
                    b.Property<int>("idServico")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ServicoidServico");

                    b.Property<string>("criticidadeServico");

                    b.Property<string>("dsServico");

                    b.Property<string>("slaServico");

                    b.HasKey("idServico");

                    b.HasIndex("ServicoidServico");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("HelpDeskMvc.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DepartamentoId");

                    b.Property<string>("loginUsuario")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("nomeUsuario")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("nvlAcesso")
                        .IsRequired();

                    b.Property<string>("senhaUsuario")
                        .IsRequired()
                        .HasMaxLength(20);

                    b.Property<string>("situacaoUsuario");

                    b.HasKey("idUsuario");

                    b.HasIndex("DepartamentoId");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("HelpDeskMvc.Models.Chamado", b =>
                {
                    b.HasOne("HelpDeskMvc.Models.Departamento", "departamento")
                        .WithMany("ListChamados")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDeskMvc.Models.Usuario", "usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HelpDeskMvc.Models.Servico", "servico")
                        .WithMany("ListChamados")
                        .HasForeignKey("servicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HelpDeskMvc.Models.Servico", b =>
                {
                    b.HasOne("HelpDeskMvc.Models.Servico")
                        .WithMany("ListCriticidade")
                        .HasForeignKey("ServicoidServico");
                });

            modelBuilder.Entity("HelpDeskMvc.Models.Usuario", b =>
                {
                    b.HasOne("HelpDeskMvc.Models.Departamento", "departamento")
                        .WithMany("ListUsuarios")
                        .HasForeignKey("DepartamentoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
