using Crm.Domain.Models.Permission;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Crm.Application.ViewModels.PermissionViewModels
{
    public class ConsultaUsuarioViewModel
    {
        [Required(ErrorMessage = "Preencha o campo pesquisa.")]
        [DisplayName("Consulta")]
        [StringLength(maximumLength: 20, MinimumLength = 3, ErrorMessage = "A campo pesquisa deve ter no minimo 3 e no maximo 20 caracteres")]
        public string Consulta { get; set; }
        
        public IEnumerable<ApplicationUser> ListaUsuarios { get; set; }
    }
}