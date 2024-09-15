using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HavenGames.Data.Mappings
{
    public class TicketMapping : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {

            builder.Property(e => e.Value)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.BuyerName)
                .IsRequired()
                .HasColumnType("varchar(200)");

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
               .WithMany(e => e.Tickets);


            builder.ToTable("TB_TICKETS");
        }
    }
}
