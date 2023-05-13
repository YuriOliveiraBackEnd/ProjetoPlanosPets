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
                ModelCliente novoCliente = new ModelCliente()
                {
                    nome_cli = cliente.nome_cli,
                    email_cli = cliente.email_cli,
                    CPF_cli = cliente.CPF_cli,
                    cep_cli = cliente.cep_cli,
                    num_cli = cliente.num_cli,
                    logradouro_cli = cliente.logradouro_cli,
                    nasc_cli = cliente.nasc_cli,
                    tel_cli = cliente.tel_cli,
                    senha_cli = cliente.senha_cli
                };
                metodoCliente.InsertCliente(novoCliente);
            }
            return View();
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