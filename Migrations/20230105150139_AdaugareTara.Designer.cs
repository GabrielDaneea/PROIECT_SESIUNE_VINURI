// <auto-generated />
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
    [Migration("20230105150139_AdaugareTara")]
    partial class AdaugareTara
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Tara", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Nume")
                        .IsRequired()
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

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.Property<int>("TaraID")
                        .HasColumnType("int");

                    b.Property<string>("Tip")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("TaraID");

                    b.ToTable("Vin");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Vin", b =>
                {
                    b.HasOne("PROIECT_SESIUNE_VINURI.Pages.Models.Tara", "Tara")
                        .WithMany("Vinuri")
                        .HasForeignKey("TaraID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tara");
                });

            modelBuilder.Entity("PROIECT_SESIUNE_VINURI.Pages.Models.Tara", b =>
                {
                    b.Navigation("Vinuri");
                });
#pragma warning restore 612, 618
        }
    }
}
