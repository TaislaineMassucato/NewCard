using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NewCard.Models;

namespace NewCard.Data.Mappings
{
    public class HistoricoConsultaMap : IEntityTypeConfiguration<HistoricoConsulta>
    {
        public void Configure(EntityTypeBuilder<HistoricoConsulta> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("HistoricoConsulta");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DataConsulta)
                .HasColumnType("date")
                .HasColumnName("data_consulta");

            builder.Property(e => e.HoraConsulta)
                .HasColumnName("hora_consulta");

            builder.Property(e => e.Diagnostico)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("diagnostico");

            builder.Property(e => e.Prescricao)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("prescricao");

            builder.HasOne(d => d.MedicoHC)
                .WithMany()
                .HasForeignKey(d => d.MedicoId)
                .HasConstraintName("FK_HistoricoConsulta_Medico")
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(d => d.PacienteHC)
                .WithMany()
                .HasForeignKey(d => d.PacienteId)
                .HasConstraintName("FK_HistoricoConsulta_Paciente")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}