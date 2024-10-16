﻿using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HavenGames.Data.Mappings
{
    public class GameMapping: IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Descricao)
              .IsRequired()
              .HasColumnType("varchar(max)");

            builder.Property(e => e.Plataforma)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Genero)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Imagem)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder
                 .HasMany(j => j.Personagens)
                 .WithOne(p => p.Jogo);
          
            builder.ToTable("TB_JOGOS");

        }
    }
}
