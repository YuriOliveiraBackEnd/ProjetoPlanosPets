using bibliotecaDAO;
using bibliotecaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanosPets.Controllers
{
    public class FornecedorController : Controller
    {
        // GET: Fornecedor
        public ActionResult Index()
        {
            var metodoFornecedor = new FornecedorDAO();
            var listaFornecedor = metodoFornecedor.Listar();
            return View(listaFornecedor);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ModelFornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var metodoFornecedor = new FornecedorDAO();
                metodoFornecedor.InsertFornecedor(fornecedor);
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        public ActionResult Atualizar(int id)
        {
            var metodoFornecedor = new FornecedorDAO();
            var fornecedor = metodoFornecedor.ListarId(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Atualizar(ModelFornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var metodoFornecedor = new FornecedorDAO();
                metodoFornecedor.Updatefornecedor(fornecedor);
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        public ActionResult Deletar(int id)
        {
            var metodoFornecedor = new FornecedorDAO();
            var fornecedor = metodoFornecedor.ListarId(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }

        [HttpPost]
        public ActionResult Deletar(ModelFornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                var metodoFornecedor = new FornecedorDAO();
                metodoFornecedor.Deletefornecedor(fornecedor);
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }

        public ActionResult Detalhes(int id)
        {
            var metodoFornecedor = new FornecedorDAO();
            var fornecedor = metodoFornecedor.ListarId(id);
            if (fornecedor == null)
            {
                return HttpNotFound();
            }
            return View(fornecedor);
        }
    }
}