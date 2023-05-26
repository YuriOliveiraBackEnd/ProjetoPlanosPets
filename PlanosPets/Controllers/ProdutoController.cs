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
    public class ProdutoController : Controller
    {
        // GET: Produto

        public ActionResult Cadastrar()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Cadastrar(ModelProduto produto, HttpPostedFileBase file)
        {
            var metodoProduto = new ProdutoDAO();
            string arquivo = Path.GetFileName(file.FileName);

            string file2 = "/Imagens/" + Path.GetFileName(file.FileName);

            string _path = Path.Combine(Server.MapPath("~/Imagens"), arquivo);

            file.SaveAs(_path);

            produto.ft_prod = file2;


            ModelProduto novoProduto = new ModelProduto()
            {
                nome_prod = produto.nome_prod,
                desc_prod = produto.desc_prod,
                quant = produto.quant,
                valor_unitario = produto.valor_unitario,
                id_func = produto.id_func,
                id_categoria = produto.id_categoria,
                ft_prod = produto.ft_prod = file2

            };
                metodoProduto.InsertProduto(novoProduto);

                return View ();
            
           
        }
        public ActionResult ListarProduto()
        {
            var metodoProduto = new ProdutoDAO();
            var listaProduto = metodoProduto.Listar();
            return View(listaProduto);
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