using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace HavenGames.Data.Mappings
{
    public class JogoMapping: IEntityTypeConfiguration<Jogo>
    {
        public void Configure(EntityTypeBuilder<Jogo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Plataforma)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Genero)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Imagem)
                .IsRequired()
                .HasColumnType("varchar(255)");

            // Configuração para relação muitos-para-muitos, se necessário
            builder
                 .HasMany(j => j.Personagens)
                 .WithOne(p => p.Jogo)
                     .HasForeignKey(p => p.JogoId);

          
            builder.ToTable("TB_JOGOS");

        }
    }
}
