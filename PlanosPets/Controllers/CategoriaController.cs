using bibliotecaDAO;
using bibliotecaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanosPets.Controllers
{
    public class CategoriaController : Controller
    {

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ModelCategorias categoria)
        {
            if (ModelState.IsValid)
            {
                var metodoCategoria = new CategoriaDAO();
                metodoCategoria.InsertCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Atualizar(int id)
        {
            var metodoCategoria = new CategoriaDAO();
            var categoria = metodoCategoria.ListarId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        [HttpPost]
        public ActionResult Atualizar(ModelCategorias categoria)
        {
            if (ModelState.IsValid)
            {
                var metodoCategoria = new CategoriaDAO();
                metodoCategoria.UpdateCategoria(categoria);
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        public ActionResult Excluir(int id)
        {
            var metodoCategoria = new CategoriaDAO();
            metodoCategoria.Excluir(id);
            return RedirectToAction("Index");
        }


        public ActionResult Detalhes(int id)
        {
            var metodoRaca = new RacaDAO();
            var raca = metodoRaca.ListarId(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }
    }
}