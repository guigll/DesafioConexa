﻿// <auto-generated />
using System;
using DesafioHubConexa.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesafioHubConexa.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("DesafioHubConexa.Models.CityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTimeOffset?>("Data")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Temp")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Temperaturas");
                });
#pragma warning restore 612, 618
        }
    }
}
