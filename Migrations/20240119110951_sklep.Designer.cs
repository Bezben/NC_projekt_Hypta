﻿// <auto-generated />
using System;
using Hypta_Projekt.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Hypta_Projekt.Migrations
{
    [DbContext(typeof(Hypta_ProjektContext))]
    [Migration("20240119110951_sklep")]
    partial class sklep
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Hypta_Projekt.Models.Kategoria", b =>
                {
                    b.Property<int>("KategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KategoriaID"));

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KategoriaID");

                    b.ToTable("Kategorie");
                });

            modelBuilder.Entity("Hypta_Projekt.Models.Klient", b =>
                {
                    b.Property<int>("KlientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("KlientID"));

                    b.Property<string>("Imie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nazwisko")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("KlientID");

                    b.ToTable("Klienci");
                });

            modelBuilder.Entity("Hypta_Projekt.Models.Produkt", b =>
                {
                    b.Property<int>("ProduktID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduktID"));

                    b.Property<decimal>("Cena")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Nazwa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProduktID");

                    b.ToTable("Produkty");
                });

            modelBuilder.Entity("Hypta_Projekt.Models.ProduktKategoria", b =>
                {
                    b.Property<int>("ProduktKategoriaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProduktKategoriaID"));

                    b.Property<int>("KategoriaID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktID")
                        .HasColumnType("int");

                    b.HasKey("ProduktKategoriaID");

                    b.HasIndex("KategoriaID");

                    b.HasIndex("ProduktID");

                    b.ToTable("ProduktKategorie");
                });

            modelBuilder.Entity("Hypta_Projekt.Models.Zamowienie", b =>
                {
                    b.Property<int>("ZamowienieID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ZamowienieID"));

                    b.Property<DateTime>("DataZamowienia")
                        .HasColumnType("datetime2");

                    b.Property<int>("KlientID")
                        .HasColumnType("int");

                    b.Property<int>("ProduktID")
                        .HasColumnType("int");

                    b.Property<string>("StatusZamowienia")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ZamowienieID");

                    b.HasIndex("KlientID");

                    b.HasIndex("ProduktID");

                    b.ToTable("Zamowienia");
                });

            modelBuilder.Entity("Hypta_Projekt.Models.ProduktKategoria", b =>
                {
                    b.HasOne("Hypta_Projekt.Models.Kategoria", "Kategoria")
                        .WithMany("ProduktKategorie")
                        .HasForeignKey("KategoriaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hypta_Projekt.Models.Produkt", "Produkt")
                        .WithMany("ProduktKategorie")
                        .HasForeignKey("ProduktID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kategoria");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("Hypta_Projekt.Models.Zamowienie", b =>
                {
                    b.HasOne("Hypta_Projekt.Models.Klient", "Klient")
                        .WithMany("Zamowienia")
                        .HasForeignKey("KlientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Hypta_Projekt.Models.Produkt", "Produkt")
                        .WithMany()
                        .HasForeignKey("ProduktID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klient");

                    b.Navigation("Produkt");
                });

            modelBuilder.Entity("Hypta_Projekt.Models.Kategoria", b =>
                {
                    b.Navigation("ProduktKategorie");
                });

            modelBuilder.Entity("Hypta_Projekt.Models.Klient", b =>
                {
                    b.Navigation("Zamowienia");
                });

            modelBuilder.Entity("Hypta_Projekt.Models.Produkt", b =>
                {
                    b.Navigation("ProduktKategorie");
                });
#pragma warning restore 612, 618
        }
    }
}
