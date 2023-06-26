namespace NewCard.Models;

public class Consulta
{
    public int Id { get; set; }

    public DateTime DataConsulta { get; set; }

    public TimeSpan HoraConsulta { get; set; }

    public string Status { get; set; }

    public int MedicoId { get; set; }
    public Medico MedicoConsultaId { get; set; }
    
    public int PacienteId { get; set; }
    public Paciente PacienteConsultaId { get; set; }
}
