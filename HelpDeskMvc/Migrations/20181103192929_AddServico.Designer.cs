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
    [Migration("20181103192929_AddServico")]
    partial class AddServico
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

                    b.Property<DateTime>("dataAbertura");

                    b.Property<DateTime>("dataEncerramento");

                    b.Property<string>("descricaoChamado");

                    b.Property<int?>("servicosidServico");

                    b.Property<string>("solucaoChamado");

                    b.Property<int>("status");

                    b.Property<int?>("usuariosidUsuario");

                    b.HasKey("idChamado");

                    b.HasIndex("servicosidServico");

                    b.HasIndex("usuariosidUsuario");

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

                    b.Property<string>("criticidadeServico");

                    b.Property<string>("dsServico");

                    b.Property<string>("slaServico");

                    b.HasKey("idServico");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("HelpDeskMvc.Models.Usuario", b =>
                {
                    b.Property<int>("idUsuario")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("departamentoidDpto");

                    b.Property<string>("loginUsuario");

                    b.Property<string>("nomeUsuario");

                    b.Property<string>("nvlAcesso");

                    b.Property<string>("senhaUsuario");

                    b.Property<string>("situacaoUsuario");

                    b.HasKey("idUsuario");

                    b.HasIndex("departamentoidDpto");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("HelpDeskMvc.Models.Chamado", b =>
                {
                    b.HasOne("HelpDeskMvc.Models.Servico", "servicos")
                        .WithMany("ListChamados")
                        .HasForeignKey("servicosidServico");

                    b.HasOne("HelpDeskMvc.Models.Usuario", "usuarios")
                        .WithMany()
                        .HasForeignKey("usuariosidUsuario");
                });

            modelBuilder.Entity("HelpDeskMvc.Models.Usuario", b =>
                {
                    b.HasOne("HelpDeskMvc.Models.Departamento", "departamento")
                        .WithMany("ListUsuarios")
                        .HasForeignKey("departamentoidDpto");
                });
#pragma warning restore 612, 618
        }
    }
}
