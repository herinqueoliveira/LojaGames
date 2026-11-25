using Microsoft.AspNetCore.Mvc;
using LojaGames.Dao;

namespace LojaGames.Controllers
{
    public class AreaPublicaController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Produtos");
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Produtos()
        {
            ProdutoDao dao = new ProdutoDao();
            return View(dao.ListarProdutos());
        }

        public IActionResult Consoles()
        {
            ProdutoDao dao = new ProdutoDao();
            var lista = dao.ListarProdutos().FindAll(p => p.Categoria == "Console");
            return View("Produtos", lista);
        }

        public IActionResult Jogos()
        {
            ProdutoDao dao = new ProdutoDao();
            var lista = dao.ListarProdutos().FindAll(p => p.Categoria == "Jogo");
            return View("Produtos", lista);
        }

        public IActionResult Acessorios()
        {
            ProdutoDao dao = new ProdutoDao();
            var lista = dao.ListarProdutos().FindAll(p => p.Categoria == "Acessório");
            return View("Produtos", lista);
        }
    }
}
