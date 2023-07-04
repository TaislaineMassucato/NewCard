using System.ComponentModel.DataAnnotations;

namespace NewCard.ViewModels.Categories
{
    public class EditorFuncionarioViewModel
    {
        [Required(ErrorMessage = "Nome Obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Email Obrigatório")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha Obrigatória")]
        [StringLength(8, MinimumLength = 5, ErrorMessage = "Este campo deve ter máx 8 e min 5 caracteres ")]
        public string Senha { get; set; }
    }
}
