﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Models;
using WebApplication1.Data; // ApplicationDbContext'in bulunduğu namespace

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241220155458_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication1.Models.Hizmet", b =>
                {
                    b.Property<int>("HizmetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HizmetID"));

                    b.Property<string>("HizmetAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sure")
                        .HasColumnType("int");

                    b.Property<decimal>("Ucret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("HizmetID");

                    b.ToTable("Hizmetler");
                });

            modelBuilder.Entity("WebApplication1.Models.Personel", b =>
                {
                    b.Property<int>("PersonelID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonelID"));

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("MusaitlikDurumu")
                        .HasColumnType("bit");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UzmanlikAlani")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PersonelID");

                    b.ToTable("Personeller");
                });

            modelBuilder.Entity("WebApplication1.Models.Randevu", b =>
                {
                    b.Property<int>("RandevuID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RandevuID"));

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HizmetID")
                        .HasColumnType("int");

                    b.Property<int>("PersonelID")
                        .HasColumnType("int");

                    b.Property<DateTime>("RandevuTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelNo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RandevuID");

                    b.HasIndex("HizmetID");

                    b.HasIndex("PersonelID");

                    b.ToTable("Randevular");
                });

            modelBuilder.Entity("WebApplication1.Models.Randevu", b =>
                {
                    b.HasOne("WebApplication1.Models.Hizmet", "Hizmet")
                        .WithMany()
                        .HasForeignKey("HizmetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApplication1.Models.Personel", "Personel")
                        .WithMany()
                        .HasForeignKey("PersonelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hizmet");

                    b.Navigation("Personel");
                });
#pragma warning restore 612, 618
        }
    }
}
