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
    public class TicketMapping : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnType("NUMERIC(10,2)");

            builder.Property(e => e.BuyerName)
                .IsRequired()
                .HasColumnType("varchar(100)");

            builder.Property(e => e.BuyerCPF)
                    .IsRequired()
                    .HasColumnType("varchar(11)");

            builder.Property(e => e.TicketType)
                  .IsRequired()
                  .HasColumnType("varchar(100)");

            builder.Property(e => e.PaymentMethod)
                  .IsRequired()
                  .HasColumnType("varchar(100)");

            //Relacionamento 1 p/N
            builder.HasOne(t => t.Event)
               .WithMany(e => e.Tickets)
               .HasForeignKey(propa => propa.EventId);


            builder.ToTable("TB_TICKETS");
        }
    }
}
