using bibliotecaDAO;
using bibliotecaModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanosPets.Controllers
{
    public class ProdutoController : Controller
    {

        CategoriaDAO cat = new CategoriaDAO();

        public void CarregaCategoria()
        {
            List<SelectListItem> categoria = new List<SelectListItem>();

            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db4luck;User=root;pwd=12345678"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from Categorias", con);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    categoria.Add(new SelectListItem
                    {
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }

            ViewBag.cat = new SelectList(categoria, "Value", "Text");
        }

        public ActionResult Index()
        {
            var metodoProduto = new ProdutoDAO();
            var listaProduto = metodoProduto.Listar();
            return View(listaProduto);
        }

        public ActionResult Cadastrar()
        {
            CarregaCategoria();
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

        public ActionResult Excluir(int id)
        {
            var metodoProduto = new ProdutoDAO();
            metodoProduto.Excluir(id);
            return RedirectToAction("Index");
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