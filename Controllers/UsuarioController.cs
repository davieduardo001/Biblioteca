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
            return View();
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
            UsuarioService us = new UsuarioService();
            List<Usuario> u = us.Listar();
            return View(u);
        }

        //Editar Usuarios
        public IActionResult Edicao(int idU)
        {
            UsuarioService us = new UsuarioService();
            Usuario u = us.EncontrarId(idU);
            return View(u);
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
            Autenticacao.CheckLogin(this);
            UsuarioService us = new UsuarioService();
            us.Excluir(u);
            return View();
        }
    }
}