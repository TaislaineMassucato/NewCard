using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NewCard.Models;

namespace NewCard.Data.Mappings
{
    public class MensagemMap : IEntityTypeConfiguration<Mensagem>
    {
        public void Configure(EntityTypeBuilder<Mensagem> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("Mensagem");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.DataEnvio)
                .HasColumnType("date")
                .HasColumnName("data_envio");

            builder.Property(e => e.HoraEnvio)
                .HasColumnName("hora_envio");

            builder.HasOne(d => d.Destinatario)
                .WithMany()
                .HasForeignKey(d => d.DestinatarioId)
                .HasConstraintName("FK_Mensagem_Paciente");

            builder.Property(e => e.Tipo)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("tipo");
        }
    }
}