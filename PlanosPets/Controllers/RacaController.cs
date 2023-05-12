using bibliotecaDAO;
using bibliotecaModel;
using System;
using System.Collections.Generic;
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
        public ActionResult Cadastrar(ModelRacas raca)
        {
            if (ModelState.IsValid)
            {
                var metodoRaca = new RacaDAO();
                metodoRaca.InsertRaca(raca);
                return RedirectToAction("Index");
            }
            return View(raca);
        }

        public ActionResult Atualizar(int id)
        {
            var metodoRaca = new RacaDAO();
            var raca = metodoRaca.ListarId(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }

        [HttpPost]
        public ActionResult Atualizar(ModelRacas raca)
        {
            if (ModelState.IsValid)
            {
                var metodoRaca = new RacaDAO();
                metodoRaca.UpdateRaca(raca);
                return RedirectToAction("Index");
            }
            return View(raca);
        }

        public ActionResult Deletar(int id)
        {
            var metodoRaca = new RacaDAO();
            var raca = metodoRaca.ListarId(id);
            if (raca == null)
            {
                return HttpNotFound();
            }
            return View(raca);
        }

        [HttpPost]
        public ActionResult Deletar(ModelRacas raca)
        {
            if (ModelState.IsValid)
            {
                var metodoRaca = new RacaDAO();
                metodoRaca.DeleteRaca(raca);
                return RedirectToAction("Index");
            }
            return View(raca);
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