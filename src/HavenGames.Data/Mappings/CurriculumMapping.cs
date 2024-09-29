using HavenGames.Business.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HavenGames.Data.Mappings
{
    internal class CurriculumMapping
    {
        public void Configure(EntityTypeBuilder<Curriculum> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nome)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.NomeSocial)
              .IsRequired()
              .HasColumnType("varchar(max)");

            builder.Property(e => e.DataNascimento)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.Sexo)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(e => e.CPF)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(e => e.Email)
               .IsRequired()
               .HasColumnType("varchar(500)");

            builder.Property(e => e.Telefone)
               .IsRequired()
               .HasColumnType("varchar(500)");

            builder.Property(e => e.Escolaridade)
               .IsRequired()
               .HasColumnType("varchar(500)");

            builder.Property(e => e.Status)
               .IsRequired()
               .HasColumnType("varchar(500)");

            builder.Property(e => e.Vaga)
               .IsRequired()
               .HasColumnType("varchar(500)");

            builder.ToTable("TB_TRABALHECONOSCO");

        }
    }
}

