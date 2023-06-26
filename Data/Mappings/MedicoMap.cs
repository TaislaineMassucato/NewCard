using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NewCard.Models;

namespace NewCard.Data.Mappings
{
    public class MedicoMap : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.HasKey(e => e.Id);
            builder.ToTable("Medico");

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Nome)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nome");

            builder.Property(e => e.Telefone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefone");

            builder.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");

            builder.HasOne(d => d.Especialidade)
                .WithMany()
                .HasForeignKey(d => d.EspecialidadeId)
                .HasConstraintName("FK_Medico_Especialidade");

            builder.HasMany(m => m.EspecialidadesAdicionais)
                    .WithMany(e => e.Medicos)
                    .UsingEntity<Dictionary<string, object>>(
                        "MedicoEspecialidade",
                        j => j.HasOne<Especialidade>()
                        .WithMany()
                        .HasForeignKey("EspecialidadeId"),
                        j => j.HasOne<Medico>()
                        .WithMany()
                        .HasForeignKey("MedicoId")
    );

        }
    }
}