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
    public class RacaController : Controller
    {
        // GET: Raca
        public ActionResult Index()
        {
            var metodoRaca = new RacaDAO();
            var listaRaca = metodoRaca.Listar();
            return View(listaRaca);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ModelRacas raca, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View(raca);
            RacaDAO novaRacaDAO = new RacaDAO();
            string nome = new RacaDAO().SelectNomeRaca(raca.nome_raca);
            if (nome == raca.nome_raca)
            {
                ViewBag.Raca = "raça já cadastrada";
                return View(raca);
            }
            var modelRaca = new ModelProduto();
            var metodoRaca = new ProdutoDAO();

            string arquivo = Path.GetFileName(file.FileName);

            string file2 = "/images/" + Path.GetFileName(file.FileName);

            string _path = Path.Combine(Server.MapPath("~/images"), arquivo);

            file.SaveAs(_path);

            raca.ft_raca = file2;

            ModelRacas novaraca = new ModelRacas()
            {
                nome_raca= raca.nome_raca,
                ft_raca = raca.ft_raca
            };
            novaRacaDAO.InsertRaca(novaraca);

            return RedirectToAction("Index");
        }

      
        public ActionResult Excluir(int id)
        {
            var metodoRaca = new RacaDAO();
            var raca = metodoRaca.ListarId(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int id)
        {
              
                var metodoRaca = new RacaDAO();
                ModelRacas racas = new ModelRacas();
                racas.id_raca = id;
                metodoRaca.DeleteRaca(racas);
                return RedirectToAction("Index");
            
            
        }
      

    }
}