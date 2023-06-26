namespace NewCard.Models;

public class Medico
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Telefone { get; set; }

    public string Email { get; set; }

    public ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public int EspecialidadeId { get; set; }
    public Especialidade EspecialidadeMedico { get; set; }

    public ICollection<HistoricoConsulta> HistoricoConsulta { get; set; } = new List<HistoricoConsulta>();
}
