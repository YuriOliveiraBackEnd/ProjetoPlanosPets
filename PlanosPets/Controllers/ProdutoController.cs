using bibliotecaDAO;
using bibliotecaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanosPets.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            var metodoProduto = new ProdutoDAO();
            var listaProduto = metodoProduto.Listar();
            return View(listaProduto);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ModelProduto produto)
        {
            if (ModelState.IsValid)
            {
                var metodoProduto = new ProdutoDAO();
                metodoProduto.InsertProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Atualizar(int id)
        {
            var metodoProduto = new ProdutoDAO();
            var produto = metodoProduto.ListarId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public ActionResult Atualizar(ModelProduto produto)
        {
            if (ModelState.IsValid)
            {
                var metodoProduto = new ProdutoDAO();
                metodoProduto.UpdateProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Deletar(int id)
        {
            var metodoProduto = new ProdutoDAO();
            var produto = metodoProduto.ListarId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        [HttpPost]
        public ActionResult Deletar(ModelProduto produto)
        {
            if (ModelState.IsValid)
            {
                var metodoProduto = new ProdutoDAO();
                metodoProduto.DeleteProduto(produto);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ActionResult Detalhes(int id)
        {
            var metodoProduto = new ProdutoDAO();
            var produto = metodoProduto.ListarId(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
    }
}