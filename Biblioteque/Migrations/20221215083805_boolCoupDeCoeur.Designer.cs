﻿// <auto-generated />
using System;
using Biblioteque.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Biblioteque.Migrations
{
    [DbContext(typeof(BiblioContext))]
    [Migration("20221215083805_boolCoupDeCoeur")]
    partial class boolCoupDeCoeur
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuteurLivre", b =>
                {
                    b.Property<long>("AuteursId")
                        .HasColumnType("bigint");

                    b.Property<long>("LivresId")
                        .HasColumnType("bigint");

                    b.HasKey("AuteursId", "LivresId");

                    b.HasIndex("LivresId");

                    b.ToTable("Auteur_Livre", (string)null);
                });

            modelBuilder.Entity("Biblioteque.Models.Auteur", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("Date_Mort")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date_Naissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Auteurs");
                });

            modelBuilder.Entity("Biblioteque.Models.Genre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Biblioteque.Models.Livre", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CheminImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("CoupDeCoeur")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Date_Parution")
                        .HasColumnType("datetime2");

                    b.Property<string>("Synopsis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Titre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Livres");
                });

            modelBuilder.Entity("GenreLivre", b =>
                {
                    b.Property<long>("GenresId")
                        .HasColumnType("bigint");

                    b.Property<long>("LivresId")
                        .HasColumnType("bigint");

                    b.HasKey("GenresId", "LivresId");

                    b.HasIndex("LivresId");

                    b.ToTable("Genre_Livre", (string)null);
                });

            modelBuilder.Entity("AuteurLivre", b =>
                {
                    b.HasOne("Biblioteque.Models.Auteur", null)
                        .WithMany()
                        .HasForeignKey("AuteursId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteque.Models.Livre", null)
                        .WithMany()
                        .HasForeignKey("LivresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GenreLivre", b =>
                {
                    b.HasOne("Biblioteque.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Biblioteque.Models.Livre", null)
                        .WithMany()
                        .HasForeignKey("LivresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}