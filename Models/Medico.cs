namespace NewCard.Models;

public class Medico
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public int? EspecialidadeId { get; set; }

    public string Telefone { get; set; }

    public string Email { get; set; }

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Especialidade Especialidade { get; set; }

    public virtual ICollection<HistoricoConsulta> HistoricoConsulta { get; set; } = new List<HistoricoConsulta>();
}
