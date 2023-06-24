namespace NewCard.Models;

public class Consulta
{
    public int Id { get; set; }

    public DateTime DataConsulta { get; set; }

    public TimeSpan HoraConsulta { get; set; }

    public int MedicoId { get; set; }

    public int PacienteId { get; set; }

    public string Status { get; set; }

    public Medico Medico { get; set; }

    public Paciente Paciente { get; set; }
}
