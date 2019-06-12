using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels.AccountViewModels
{
    public class LoginWithRecoveryCodeViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Codigo Recuperação")]
        public string RecoveryCode { get; set; }
    }
}
