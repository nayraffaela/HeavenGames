using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavenGames.Data.Mappings
{
    public class TicketsMapping : IEntityTypeConfiguration<Tickets>
    {
        public void Configure(EntityTypeBuilder<Tickets> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Valor)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.Desconto)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.ToTable("TB_TICKETS");
        }
    }
}
