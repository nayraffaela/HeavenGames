using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HavenGames.Data.Mappings
{
    public class PersonagemMapping: IEntityTypeConfiguration<Personagem>
    {
        public void Configure(EntityTypeBuilder<Personagem> builder)
        {
            builder.HasKey(p => p.JogoId);

            builder.Property(p => p.NomePersonagem)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(p => p.DescricaoPersonagem)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.ImagemPersonagem)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("TB_PERSONAGENS");
               
        }
    }
        
}
