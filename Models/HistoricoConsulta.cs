namespace NewCard.Models;

public class HistoricoConsulta
{
    public int Id { get; set; }

    public DateTime DataConsulta { get; set; }

    public TimeSpan HoraConsulta { get; set; }

    public string Diagnostico { get; set; }

    public string Prescricao { get; set; }

    public int MedicoId { get; set; }
    public Medico MedicoHC { get; set; }

    public int PacienteId { get; set; }
    public Paciente PacienteHC { get; set; }
}
