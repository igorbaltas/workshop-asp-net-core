﻿// <auto-generated />
using HelpDeskMvc.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HelpDeskMvc.Migrations
{
    [DbContext(typeof(HelpDeskMvcContext))]
    partial class HelpDeskMvcContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
