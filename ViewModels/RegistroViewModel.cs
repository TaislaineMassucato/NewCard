using System.ComponentModel.DataAnnotations;

namespace NewCard.ViewModels
{
    public class RegistroViewModel
    {
        [Required(ErrorMessage ="Nome obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email obrigatório")]
        [EmailAddress(ErrorMessage ="Email inválido")]
        public string Email { get; set; }
    }
}
