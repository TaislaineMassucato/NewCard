namespace NewCard.Models;

public class Medico
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public int EspecialidadeId { get; set; }

    public string Telefone { get; set; }

    public string Email { get; set; }

    public ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public Especialidade Especialidade { get; set; }

    public ICollection<HistoricoConsulta> HistoricoConsulta { get; set; } = new List<HistoricoConsulta>();

    public ICollection<Especialidade> EspecialidadesAdicionais { get; set; } = new List<Especialidade>();
}
