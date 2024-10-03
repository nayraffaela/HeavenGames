using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HavenGames.Data.Mappings
{
    public class PersonagemMapping : IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(p => p.Imagem)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder
             .HasOne(j => j.Jogo)
             .WithMany(p => p.Personagens)
             .HasForeignKey(p => p.JogoId)
             .OnDelete(DeleteBehavior.ClientCascade);

            builder.ToTable("TB_PERSONAGENS");
        }
    }

}
