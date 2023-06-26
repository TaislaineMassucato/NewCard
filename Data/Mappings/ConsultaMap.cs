using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NewCard.Models;

namespace NewCard.Data.Mappings
{
    public class ConsultaMap : IEntityTypeConfiguration<Consulta>
    {
        public void Configure(EntityTypeBuilder<Consulta> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("Consulta");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DataConsulta)
                .HasColumnType("date")
                .HasColumnName("data_consulta");

            builder.Property(e => e.HoraConsulta)
                .HasColumnName("hora_consulta");

            builder.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");

            builder.HasOne(d => d.MedicoConsultaId)
                .WithMany()
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK_Consulta_Medico")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.PacienteConsultaId)
                .WithMany()
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK_Consulta_Paciente")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
