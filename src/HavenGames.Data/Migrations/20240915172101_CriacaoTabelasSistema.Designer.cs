﻿// <auto-generated />
using System;
using HavenGames.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HavenGames.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240915172101_CriacaoTabelasSistema")]
    partial class CriacaoTabelasSistema
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HavenGames.Business.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Alteracao")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("Inclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TB_EVENTS", (string)null);
                });

            modelBuilder.Entity("HavenGames.Business.Models.Jogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Alteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Genero")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("Inclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Plataforma")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.ToTable("TB_JOGOS", (string)null);
                });

            modelBuilder.Entity("HavenGames.Business.Models.Personagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Alteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasColumnType("varchar(500)");

                    b.Property<DateTime>("Inclusao")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("JogoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("JogoId");

                    b.ToTable("TB_PERSONAGENS", (string)null);
                });

            modelBuilder.Entity("HavenGames.Business.Models.Ticket", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Alteracao")
                        .HasColumnType("datetime2");

                    b.Property<string>("BuyerCPF")
                        .IsRequired()
                        .HasColumnType("varchar(11)");

                    b.Property<string>("BuyerName")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.Property<Guid?>("EventId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Inclusao")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentMethod")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("TicketType")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("TB_TICKETS", (string)null);
                });

            modelBuilder.Entity("HavenGames.Business.Models.Personagem", b =>
                {
                    b.HasOne("HavenGames.Business.Models.Jogo", "Jogo")
                        .WithMany("Personagens")
                        .HasForeignKey("JogoId");

                    b.Navigation("Jogo");
                });

            modelBuilder.Entity("HavenGames.Business.Models.Ticket", b =>
                {
                    b.HasOne("HavenGames.Business.Models.Event", "Event")
                        .WithMany("Tickets")
                        .HasForeignKey("EventId");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("HavenGames.Business.Models.Event", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("HavenGames.Business.Models.Jogo", b =>
                {
                    b.Navigation("Personagens");
                });
#pragma warning restore 612, 618
        }
    }
}
