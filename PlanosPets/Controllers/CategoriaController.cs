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
        public ActionResult Index()
        {
            var metodoCategoria = new CategoriaDAO();
            var listaCategoria = metodoCategoria.Listar();
            return View(listaCategoria);
        }
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ModelCategorias categorias)
        {
            if (!ModelState.IsValid)
                return View(categorias);
            CategoriaDAO novoCategoriaDAO = new CategoriaDAO();
            string nome = new CategoriaDAO().SelectNomeCategoria(categorias.nome_categoria);
            if (nome == categorias.nome_categoria)
            {
                ViewBag.Categoria = "Categoria já cadastrada";
                return View(categorias);
            }


            ModelCategorias novacategoria = new ModelCategorias()
            {
                nome_categoria = categorias.nome_categoria,
                desc_categoria = categorias.desc_categoria,
            };
            novoCategoriaDAO.InsertCategoria(novacategoria);

            return RedirectToAction("Index");
        }

        public ActionResult Atualizar(int id)
        {
            var metodoCategoria = new CategoriaDAO();
            var cliente = metodoCategoria.ListarId(id);


            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
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
            var categoria = metodoCategoria.ListarId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }
        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int id)
        {
            var metodoCategoria = new CategoriaDAO();
            ModelCategorias categoria = new ModelCategorias();
            categoria.id_categoria = id;
            metodoCategoria.DeleteCategoria(categoria);
            return RedirectToAction("Index");

        }

        public ActionResult Detalhes(int id)
        {
            var metodoCategoria = new CategoriaDAO();
            var categoria = metodoCategoria.ListarId(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

    }
}