using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HavenGames.Data.Mappings
{
    internal class EventMapping : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Name)
               .IsRequired()
               .HasColumnType("varchar(200)");

            builder.Property(e => e.Description)
                .IsRequired()
                .HasColumnType("varchar(max)");

            builder.Property(e => e.Localization)
               .IsRequired()
               .HasColumnType("varchar(500)");

            builder.Property(e => e.Imagem)
             .IsRequired()
             .HasColumnType("varchar(500)");

            builder.Property(e => e.Date)
                    .IsRequired();



            builder.ToTable("TB_EVENTS");
        }
    }
}

