using bibliotecaDAO;
using bibliotecaModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanosPets.Controllers
{
    public class HomeController : Controller
    {
      
        public ActionResult Listarproduto()
        {
            var metodoProduto = new ProdutoDAO();
            var listaProduto = metodoProduto.Listar();
            return View(listaProduto);
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IndexFunc()
        {
            return View();
        }
      
        public ActionResult Buscar(string pesquisar)
        {
            if (pesquisar == "Planos")
                return RedirectToAction("Planos");

            else
            {
                var metodoProduto = new ProdutoDAO();
                var produto = metodoProduto.Pesquisa(pesquisar);
                if (produto == null)
                {
                    return HttpNotFound();
                }
                return View(produto);
            }

        }
    }
}