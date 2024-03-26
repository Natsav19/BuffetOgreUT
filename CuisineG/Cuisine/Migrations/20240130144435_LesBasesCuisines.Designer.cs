﻿// <auto-generated />
using Cuisine.Modeles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cuisine.Migrations
{
    [DbContext(typeof(CuisineContext))]
    [Migration("20240130144435_LesBasesCuisines")]
    partial class LesBasesCuisines
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.26")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Cuisine.Modeles.Plats", b =>
                {
                    b.Property<int>("PlatsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PlatsID"), 1L, 1);

                    b.Property<int>("Taille_Plat_Moyen")
                        .HasColumnType("int");

                    b.Property<int>("Temps_Moyen_Preparation_Plat")
                        .HasColumnType("int");

                    b.Property<bool>("Vide")
                        .HasColumnType("bit");

                    b.HasKey("PlatsID");

                    b.ToTable("Plat");
                });
#pragma warning restore 612, 618
        }
    }
}