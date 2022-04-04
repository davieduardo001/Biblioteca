using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
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

    }
}