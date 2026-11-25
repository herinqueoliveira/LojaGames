using Microsoft.AspNetCore.Mvc;
using LojaGames.Dao;
using LojaGames.Models;

namespace LojaGames.Controllers
{
    public class AreaRestritaController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("AdmProdutos");
        }

        public IActionResult AdmProdutos()
        {
            ProdutoDao dao = new ProdutoDao();
            ViewBag.Produtos = dao.ListarProdutos();
            return View(new Produto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SalvarModerno(Produto p)
        {
            if (!ModelState.IsValid)
            {
                ProdutoDao dao = new ProdutoDao();
                ViewBag.Produtos = dao.ListarProdutos();
                return View("AdmProdutos", p);
            }

            ProdutoDao produtoDao = new ProdutoDao();
            produtoDao.inserir(p);
            TempData["Mensagem"] = "Produto cadastrado com sucesso!";
            return RedirectToAction("AdmProdutos");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Excluir(int id)
        {
            ProdutoDao dao = new ProdutoDao();
            dao.Excluir(id);
            TempData["Mensagem"] = "Produto removido com sucesso!";
            return RedirectToAction("AdmProdutos");
        }

        public IActionResult AdmVendas()
        {
            return View();
        }
    }
}
