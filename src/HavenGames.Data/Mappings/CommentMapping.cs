using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;




namespace HavenGames.Data.Mappings
{
    class CommentMapping: IEntityTypeConfiguration<CommentForm>
    {
        public void Configure(EntityTypeBuilder<CommentForm> builder)
        {

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(p => p.Descricao)
                    .IsRequired()
                    .HasColumnType("varchar(max)");

            
            builder.ToTable("TB_COMENTARIOS");
        }
    }
}
