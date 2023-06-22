namespace NewCard.Models;

public class Mensagem
{
    public int Id { get; set; }

    public DateTime? DataEnvio { get; set; }

    public TimeSpan? HoraEnvio { get; set; }

    public int? DestinatarioId { get; set; }

    public string Tipo { get; set; }

    public virtual Paciente Destinatario { get; set; }
}
