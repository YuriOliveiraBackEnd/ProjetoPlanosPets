using bibliotecaDAO;
using bibliotecaModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PlanosPets.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            var metodoCliente = new ClienteDAO();
            var listaCliente = metodoCliente.Listar();
            return View(listaCliente);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ModelCliente cliente)
        {
            if (ModelState.IsValid)
            {
                var metodoCliente = new ClienteDAO();
                metodoCliente.InsertCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Atualizar(int id)
        {
            var metodoCliente = new ClienteDAO();
            var cliente = metodoCliente.ListarId(id);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Atualizar(ModelCliente cliente)
        {
            if(ModelState.IsValid)
            {
                var metodoCliente = new ClienteDAO();
                metodoCliente.UpdateCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }
    
        public ActionResult Deletar(int id) 
        {
            var metodoCliente = new ClienteDAO();
            var cliente = metodoCliente.ListarId(id);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        [HttpPost]
        public ActionResult Deletar(ModelCliente cliente)
        {
            if (ModelState.IsValid)
            {
                var metodoCliente = new ClienteDAO();
                metodoCliente.DeleteCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Detalhes(int id)
        {
            var metodoCliente = new ClienteDAO();
            var cliente = metodoCliente.ListarId(id);
            if(cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }
    }
}