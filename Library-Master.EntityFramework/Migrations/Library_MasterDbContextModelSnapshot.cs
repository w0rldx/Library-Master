﻿// <auto-generated />
using System;
using Library_Master.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Library_Master.EntityFramework.Migrations
{
    [DbContext(typeof(Library_MasterDbContext))]
    partial class Library_MasterDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("Library_Master.Core.Models.Account", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("AccountHolderId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AccountHolderId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Library_Master.Core.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Antolin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Autor")
                        .HasColumnType("TEXT");

                    b.Property<string>("AutorKuerzel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Besonderheit")
                        .HasColumnType("TEXT");

                    b.Property<string>("Bezugsquelle")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Entliehen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ErscheinungsJahr")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fach")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("HinzufuegeDatum")
                        .HasColumnType("TEXT");

                    b.Property<string>("Informationen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Isbn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Kategorie")
                        .HasColumnType("TEXT");

                    b.Property<string>("Klasse")
                        .HasColumnType("TEXT");

                    b.Property<int>("Medium")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nummer")
                        .HasColumnType("TEXT");

                    b.Property<double>("Preis")
                        .HasColumnType("REAL");

                    b.Property<int?>("QrCodeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sparte")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Verlag")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ZuletztEntliehen")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ZuletztEntliehenVonId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("QrCodeId");

                    b.HasIndex("ZuletztEntliehenVonId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Library_Master.Core.Models.QrCode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Author")
                        .HasColumnType("TEXT");

                    b.Property<string>("Info")
                        .HasColumnType("TEXT");

                    b.Property<string>("Isbn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Verlag")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("QrCodes");
                });

            modelBuilder.Entity("Library_Master.Core.Models.Transaktion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("AbgabeAm")
                        .HasColumnType("TEXT");

                    b.Property<int?>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BookId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("EntliehenAm")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("BookId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Library_Master.Core.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Klasse")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Library_Master.Core.Models.Account", b =>
                {
                    b.HasOne("Library_Master.Core.Models.User", "AccountHolder")
                        .WithMany()
                        .HasForeignKey("AccountHolderId");

                    b.Navigation("AccountHolder");
                });

            modelBuilder.Entity("Library_Master.Core.Models.Book", b =>
                {
                    b.HasOne("Library_Master.Core.Models.QrCode", "QrCode")
                        .WithMany()
                        .HasForeignKey("QrCodeId");

                    b.HasOne("Library_Master.Core.Models.Account", "ZuletztEntliehenVon")
                        .WithMany()
                        .HasForeignKey("ZuletztEntliehenVonId");

                    b.Navigation("QrCode");

                    b.Navigation("ZuletztEntliehenVon");
                });

            modelBuilder.Entity("Library_Master.Core.Models.Transaktion", b =>
                {
                    b.HasOne("Library_Master.Core.Models.Account", null)
                        .WithMany("Transaktionen")
                        .HasForeignKey("AccountId");

                    b.HasOne("Library_Master.Core.Models.Book", "Book")
                        .WithMany("Transaktionen")
                        .HasForeignKey("BookId");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Library_Master.Core.Models.Account", b =>
                {
                    b.Navigation("Transaktionen");
                });

            modelBuilder.Entity("Library_Master.Core.Models.Book", b =>
                {
                    b.Navigation("Transaktionen");
                });
#pragma warning restore 612, 618
        }
    }
}
