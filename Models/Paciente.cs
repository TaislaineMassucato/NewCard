namespace NewCard.Models;

public class Paciente
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public string Telefone { get; set; }

    public string Endereco { get; set; }

    public DateTime DataNascimento { get; set; }

    public ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public ICollection<HistoricoConsulta> HistoricoConsulta { get; set; } = new List<HistoricoConsulta>();

    public ICollection<Mensagem> Mensagems { get; set; } = new List<Mensagem>();
}
