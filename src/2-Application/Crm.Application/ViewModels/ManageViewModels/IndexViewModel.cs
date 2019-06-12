using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels.ManageViewModels
{
    public class IndexViewModel
    {
        public string Username { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Numero Telefone")]
        public string NumeroTelefone { get; set; }

        public string StatusMessage { get; set; }
    }
}
