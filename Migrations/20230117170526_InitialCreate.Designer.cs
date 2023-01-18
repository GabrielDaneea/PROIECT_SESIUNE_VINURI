﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PROIECT_SESIUNE_VINURI.Data;

#nullable disable

namespace PROIECT_SESIUNE_VINURI.Migrations
{
    [DbContext(typeof(PROIECT_SESIUNE_VINURIContext))]
    [Migration("20230117170526_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Distribuitor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume_Firma")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Distribuitor");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.DistribuitorVinuri", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("DistribuitorID")
                        .HasColumnType("int");

                    b.Property<int>("VinID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("DistribuitorID");

                    b.HasIndex("VinID");

                    b.ToTable("DistribuitorVinuri");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Tara", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Tara");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Vin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("An")
                        .HasColumnType("int");

                    b.Property<string>("Culoare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DistribuitorID")
                        .HasColumnType("int");

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.Property<int>("TaraID")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("ID");

                    b.HasIndex("DistribuitorID");

                    b.HasIndex("TaraID");

                    b.ToTable("Vin");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.DistribuitorVinuri", b =>
                {
                    b.HasOne("PROIECT_SESIUNE_VINURI.Pages.Models.Distribuitor", "Distribuitor")
                        .WithMany("DistribuitorDeVinuri")
                        .HasForeignKey("DistribuitorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PROIECT_SESIUNE_VINURI.Pages.Models.Vin", "Vin")
                        .WithMany("DistribuitoriDeVinuri")
                        .HasForeignKey("VinID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Distribuitor");

                    b.Navigation("Vin");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Vin", b =>
                {
                    b.HasOne("PROIECT_SESIUNE_VINURI.Pages.Models.Distribuitor", null)
                        .WithMany("Vinuri")
                        .HasForeignKey("DistribuitorID");

                    b.HasOne("PROIECT_SESIUNE_VINURI.Pages.Models.Tara", "Tara")
                        .WithMany("Vinuri")
                        .HasForeignKey("TaraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tara");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Distribuitor", b =>
                {
                    b.Navigation("DistribuitorDeVinuri");

                    b.Navigation("Vinuri");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Tara", b =>
                {
                    b.Navigation("Vinuri");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Vin", b =>
                {
                    b.Navigation("DistribuitoriDeVinuri");
                });
#pragma warning restore 612, 618
        }
    }
}
