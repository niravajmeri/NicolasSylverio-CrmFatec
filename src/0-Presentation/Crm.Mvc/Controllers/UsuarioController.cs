using Crm.Application.Interface;
using Crm.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Crm.Mvc.Controllers
{
    [Authorize]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            try
            {
                var listaUsuario = _usuarioAppService.GetAllUsuarioViewModel();

                return View(listaUsuario);
            }
            catch (Exception)
            {
                return View(new List<UsuarioViewModel>());
            }
        }

        [HttpGet]
        [AllowAnonymous]
        [Authorize(Policy = "RemoverUsuario")]
        public IActionResult CadastroUsuario()
        {
            try
            {
                return View();
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Policy = "RemoverUsuario")]
        public IActionResult CadastroUsuario(UsuarioViewModel usuarioViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(usuarioViewModel);

                _usuarioAppService.Cadastrar(usuarioViewModel);

                return View(new UsuarioViewModel());
            }
            catch (Exception)
            {
                return View(usuarioViewModel);
            }
        }
    }
}