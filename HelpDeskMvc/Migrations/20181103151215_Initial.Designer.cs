﻿// <auto-generated />
using HelpDeskMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelpDeskMvc.Migrations
{
    [DbContext(typeof(HelpDeskMvcContext))]
    [Migration("20181103151215_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HelpDeskMvc.Models.Departamento", b =>
                {
                    b.Property<int>("idDpto")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("dsDpto");

                    b.HasKey("idDpto");

                    b.ToTable("Departamento");
                });
#pragma warning restore 612, 618
        }
    }
}
