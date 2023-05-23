﻿using bibliotecaDAO;
using bibliotecaModel;
using PlanosPets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace PlanosPets.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
        
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel vielmodel)
        {
            if (!ModelState.IsValid)
            {
                return View(vielmodel);
            }
            ModelFuncionario funcionario = new ModelFuncionario();
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            ModelCliente cliente = new ModelCliente();
            ClienteDAO clienteDAO = new ClienteDAO();
            funcionario = funcionarioDAO.SelectFuncionario(vielmodel.Email);
            cliente = clienteDAO.SelectCliente(vielmodel.Email);
            if (funcionario == null | funcionario.email_func != vielmodel.Email | cliente == null | cliente.email_cli != vielmodel.Email)
            {
                ModelState.AddModelError("Email", "Email incorreto");
                return View(vielmodel);
            }

            if (funcionario == null | funcionario.senha_func != vielmodel.senha | cliente == null | cliente.senha_cli != vielmodel.senha)
            {
                ModelState.AddModelError("Senha", "Senha incorreto");
                return View(vielmodel);
            }
            else if (funcionario != null | funcionario.email_func == vielmodel.Email)
            {
                Session["FuncLogado"] = vielmodel.Email.ToString();
                Session["senhaLogado"] = vielmodel.senha.ToString();

                return RedirectToAction("IndexFunc", "Home");
            }
            else if (cliente != null | cliente.email_cli == vielmodel.Email)
            {
                Session["ClienteLogado"] = vielmodel.Email.ToString();
                Session["senhaLogado"] = vielmodel.senha.ToString();

                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}