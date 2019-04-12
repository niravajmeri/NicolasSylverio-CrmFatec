using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CadastroUsuario()
        {
            return View();
        }
    }
}