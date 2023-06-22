using Microsoft.EntityFrameworkCore;
using NewCard.Models;
using NewCard.Data.Mappings;

namespace NewCard.Data;

public class NewCardContext : DbContext
{
    public DbSet<Consulta> Consulta { get; set; }

     public DbSet<Especialidade> Especialidades { get; set; }
     public DbSet<Funcionario> Funcionarios { get; set; }
     public DbSet<HistoricoConsulta> HistoricoConsulta { get; set; }
     public DbSet<Medico> Medicos { get; set; }
     public DbSet<Mensagem> Mensagems { get; set; }
     public DbSet<Paciente> Pacientes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsEntity)
        => optionsEntity.UseSqlServer("Server=localhost,1433;Database=NewCard2;User ID=sa;Password=1q2w3e4r@#$;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ConsultaMap());
        modelBuilder.ApplyConfiguration(new EspecialidadeMap());
        modelBuilder.ApplyConfiguration(new HistoricoConsultaMap());
        modelBuilder.ApplyConfiguration(new MedicoMap());
        modelBuilder.ApplyConfiguration(new MensagemMap());
        modelBuilder.ApplyConfiguration(new PacienteMap());

    }    
}
