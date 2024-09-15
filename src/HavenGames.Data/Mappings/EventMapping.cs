using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                .HasColumnType("varchar(500)");

            builder.Property(e => e.Date)
                    .IsRequired();

            //Relacionamento 1 p/N
            builder.HasMany(e => e.Tickets)
               .WithOne(t => t.Event);

            builder.ToTable("TB_EVENTS");
        }
    }
}
    
