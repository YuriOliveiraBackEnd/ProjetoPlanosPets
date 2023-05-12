using bibliotecaDAO;
using bibliotecaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanosPets.Controllers
{
    public class FuncionarioController : Controller
    {
        // GET: Funcionario
        public ActionResult Index()
        {
            var metodoFuncionario = new FuncionarioDAO();
            var listaFuncionario = metodoFuncionario.Listar();
            return View(listaFuncionario);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ModelFuncionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodoFuncionario = new FuncionarioDAO();
                metodoFuncionario.InsertFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        public ActionResult Atualizar(int id)
        {
            var metodoFuncionario = new FuncionarioDAO();
            var funcionario = metodoFuncionario.ListarId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Atualizar(ModelFuncionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodoFuncionario = new FuncionarioDAO();
                metodoFuncionario.UpdateFuncionario(funcionario);
                return RedirectToAction("Index");
            }
            return View(funcionario);
        }

        public ActionResult Deletar(int id)
        {
            var metodoFuncionario = new FuncionarioDAO();
            var funcionario = metodoFuncionario.ListarId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }

        [HttpPost]
        public ActionResult Deletar(ModelFuncionario funcionario)
        {
            if (ModelState.IsValid)
            {
                var metodoFuncionario = new FuncionarioDAO();
                metodoFuncionario.DeleteFuncionario(funcionario);
                return RedirectToAction("Index");
            }   
            return View(funcionario);
        }

        public ActionResult Detalhes(int id)
        {
            var metodoFuncionario = new FuncionarioDAO();
            var funcionario = metodoFuncionario.ListarId(id);
            if (funcionario == null)
            {
                return HttpNotFound();
            }
            return View(funcionario);
        }
    }
}