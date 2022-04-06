using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {

        //Cadastrar Usuarios
        public IActionResult Cadastro()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
                return Redirect("/Home/Login");

            string Login = HttpContext.Session.GetString("Login");

            if (Login == "Admin")
            {
                return View();
            } else {
                return RedirectToAction("PrivilegiosDeAdm");
            }
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario u)
        {
            UsuarioService usuarioS = new UsuarioService();

            if(u.Id == 0)
            {
                usuarioS.Inserir(u);
            }
            else
            {
                usuarioS.Atualizar(u);
            }

            return RedirectToAction("Listagem");
        }

       //Listar Usuarios 
        public IActionResult Listagem()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
                return Redirect("/Home/Login");

            
            string Login = HttpContext.Session.GetString("Login");

            if (Login == "Admin")
            {
                UsuarioService us = new UsuarioService();
                List<Usuario> u = us.Listar();
                return View(u);
            } else {
                return RedirectToAction("PrivilegiosDeAdm");
            }
        }

        public IActionResult PrivilegiosDeAdm()
        {
            return View();
        }

        //Editar Usuarios
        public IActionResult Edicao(int idU)
        {
            if(HttpContext.Session.GetInt32("Id") == null)
                return Redirect("/Home/Login");

            string Login = HttpContext.Session.GetString("Login");

            if (Login == "Admin")
            {
                UsuarioService us = new UsuarioService();
                Usuario u = us.EncontrarId(idU);
                return View(u);
            } else {
                return RedirectToAction("PrivilegiosDeAdm");
            }           
        }
        [HttpPost]
        public IActionResult Edicao(Usuario u)
        {
            UsuarioService us = new UsuarioService();
            us.Editar(u);
            return RedirectToAction("Listagem");
        }

        //Excluir Usuarios
        public IActionResult Exclusao(Usuario u)
        {
            if(HttpContext.Session.GetInt32("Id") == null)
                return Redirect("/Home/Login");

            string Login = HttpContext.Session.GetString("Login");

            if (Login == "Admin")
            {
                Autenticacao.CheckLogin(this);
                UsuarioService us = new UsuarioService();
                us.Excluir(u);
                return View();
            } else {
                return RedirectToAction("PrivilegiosDeAdm");
            }
        }
    }
}