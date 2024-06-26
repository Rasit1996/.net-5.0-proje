﻿// <auto-generated />
using System;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccessLayer.Migrations
{
    [DbContext(typeof(BContext))]
    [Migration("20240514134258_kur")]
    partial class kur
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EntityLayer.Entity.Bildirim", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ClassTip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Icerik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Konu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("YazarID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("YazarID");

                    b.ToTable("bildirims");
                });

            modelBuilder.Entity("EntityLayer.Entity.BlogPuan", b =>
                {
                    b.Property<int>("BlogID")
                        .HasColumnType("int");

                    b.Property<int>("BlogPuanlamaAdet")
                        .HasColumnType("int");

                    b.Property<int>("BlogTopPuan")
                        .HasColumnType("int");

                    b.ToTable("blogPuans");
                });

            modelBuilder.Entity("EntityLayer.Entity.Blok", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Baslik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Durum")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<string>("KucukGorsel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OlusturmaTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("YazarID")
                        .HasColumnType("int");

                    b.Property<string>("İcerik")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("KategoriID");

                    b.HasIndex("YazarID");

                    b.ToTable("bloks");
                });

            modelBuilder.Entity("EntityLayer.Entity.HaberBulteni", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("haberBultenis");
                });

            modelBuilder.Entity("EntityLayer.Entity.Hakkinda", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Detaylar1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Detaylar2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Image1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MapLocation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("hakkindas");
                });

            modelBuilder.Entity("EntityLayer.Entity.Kategori", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Yorum")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("kategoris");
                });

            modelBuilder.Entity("EntityLayer.Entity.KategoriPuan", b =>
                {
                    b.Property<int>("KatPuanlamaAdet")
                        .HasColumnType("int");

                    b.Property<int>("KatTopPuan")
                        .HasColumnType("int");

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.ToTable("kategoriPuans");
                });

            modelBuilder.Entity("EntityLayer.Entity.Mesaj", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Alici")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Gonderen")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icerik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Konu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("mesajs");
                });

            modelBuilder.Entity("EntityLayer.Entity.Mesaj2", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("AliciID")
                        .HasColumnType("int");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<int>("GonderenID")
                        .HasColumnType("int");

                    b.Property<string>("Icerik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Konu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("AliciID");

                    b.HasIndex("GonderenID");

                    b.ToTable("mesaj2s");
                });

            modelBuilder.Entity("EntityLayer.Entity.Yazar", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Hakkinda")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sifre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("yazars");
                });

            modelBuilder.Entity("EntityLayer.Entity.Yorumcu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Baslik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("BlogPuan")
                        .HasColumnType("float");

                    b.Property<int>("BlokID")
                        .HasColumnType("int");

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Icerik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("YorumTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("BlokID");

                    b.ToTable("yorumcus");
                });

            modelBuilder.Entity("EntityLayer.Entity.İletisim", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Durum")
                        .HasColumnType("bit");

                    b.Property<string>("Konu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mesaj")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MyProperty")
                        .HasColumnType("int");

                    b.Property<DateTime>("Tarih")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("iletisims");
                });

            modelBuilder.Entity("EntityLayer.Entity.Bildirim", b =>
                {
                    b.HasOne("EntityLayer.Entity.Yazar", "yazar")
                        .WithMany("bildirims")
                        .HasForeignKey("YazarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("yazar");
                });

            modelBuilder.Entity("EntityLayer.Entity.Blok", b =>
                {
                    b.HasOne("EntityLayer.Entity.Kategori", "kategori")
                        .WithMany("bloks")
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entity.Yazar", "yazar")
                        .WithMany("bloks")
                        .HasForeignKey("YazarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("kategori");

                    b.Navigation("yazar");
                });

            modelBuilder.Entity("EntityLayer.Entity.Mesaj2", b =>
                {
                    b.HasOne("EntityLayer.Entity.Yazar", "Alici")
                        .WithMany("Alinanlar")
                        .HasForeignKey("AliciID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EntityLayer.Entity.Yazar", "Gonderen")
                        .WithMany("Gonderilenler")
                        .HasForeignKey("GonderenID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Alici");

                    b.Navigation("Gonderen");
                });

            modelBuilder.Entity("EntityLayer.Entity.Yorumcu", b =>
                {
                    b.HasOne("EntityLayer.Entity.Blok", "blok")
                        .WithMany("yorumcus")
                        .HasForeignKey("BlokID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("blok");
                });

            modelBuilder.Entity("EntityLayer.Entity.Blok", b =>
                {
                    b.Navigation("yorumcus");
                });

            modelBuilder.Entity("EntityLayer.Entity.Kategori", b =>
                {
                    b.Navigation("bloks");
                });

            modelBuilder.Entity("EntityLayer.Entity.Yazar", b =>
                {
                    b.Navigation("Alinanlar");

                    b.Navigation("bildirims");

                    b.Navigation("bloks");

                    b.Navigation("Gonderilenler");
                });
#pragma warning restore 612, 618
        }
    }
}
