namespace NewCard.Models;

public class Especialidade
{
    public int Id { get; set; }

    public string Nome { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
