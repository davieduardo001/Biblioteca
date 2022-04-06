using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class LivroController : Controller
    {
        public IActionResult Cadastro()
        {
            if(HttpContext.Session.GetInt32("Id") == null)
                return Redirect("/Home/Login");

            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Livro l)
        {
            LivroService livroService = new LivroService();

            if(l.Id == 0)
            {
                livroService.Inserir(l);
            }
            else
            {
                livroService.Atualizar(l);
            }

            return RedirectToAction("Listagem");
        }

        public IActionResult Listagem(string tipoFiltro, string filtro, string itensPorPagina, int numDaPagina, int paginaAtual)
        {   
            if(HttpContext.Session.GetInt32("Id") == null)
                return Redirect("/Home/Login");

            FiltrosLivros objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosLivros();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }


                ViewData["livrosPorPagina"] = (string.IsNullOrEmpty(itensPorPagina)?10:int.Parse(itensPorPagina));
                ViewData["paginaAtual"] = (paginaAtual!=0 ? paginaAtual :1);

            LivroService livroService = new LivroService();
            return View(livroService.ListarTodos(objFiltro));
        }

        public IActionResult Edicao(int id)
        {
            if(HttpContext.Session.GetInt32("Id") == null)
                return Redirect("/Home/Login");
                
            LivroService ls = new LivroService();
            Livro l = ls.ObterPorId(id);
            return View(l);
        }
    }
}