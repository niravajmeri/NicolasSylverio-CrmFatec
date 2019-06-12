using Crm.Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Crm.Mvc.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("welcome")]
        [Route("")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [Route("error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("access-denied")]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}