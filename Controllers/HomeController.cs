using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Biblioteca.Models;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
                return Redirect("/Home/Login");
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario u)
        {
            UsuarioService us = new UsuarioService();
            Usuario usuario = us.FazerLogin(u);

            if (usuario != null)
            {
                HttpContext.Session.SetInt32("Id", usuario.Id);
                HttpContext.Session.SetString("Login", usuario.Login);
                return RedirectToAction("Index", "Home");
            }else{
                ViewData["Erro"] = "Senha ou usuario inválidos";
                return View();
            }
        }
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
