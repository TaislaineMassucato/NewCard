namespace NewCard.Models;

public class HistoricoConsulta
{
    public int Id { get; set; }

    public DateTime DataConsulta { get; set; }

    public TimeSpan HoraConsulta { get; set; }

    public int MedicoId { get; set; }

    public int PacienteId { get; set; }

    public string Diagnostico { get; set; }

    public string Prescricao { get; set; }

    public Medico Medico { get; set; }

    public Paciente Paciente { get; set; }
}
