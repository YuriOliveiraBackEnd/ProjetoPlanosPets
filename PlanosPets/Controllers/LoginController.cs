using bibliotecaDAO;
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
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            var viewmodel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewmodel);
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
            funcionario = funcionarioDAO.SelectFuncionario(vielmodel.senha);


            if (funcionario == null | funcionario.email_func != vielmodel.Email)
            {
                ModelState.AddModelError("Email", "Email incorreto");
                return View(vielmodel);
            }
            if (funcionario == null | funcionario.senha_func != vielmodel.senha)
            {
                ModelState.AddModelError("Senha", "senha incorreta");
                return View(vielmodel);
            }



            var identity = new ClaimsIdentity(new[]
            {
                 new Claim(ClaimTypes.Name, funcionario.senha_func),
                 new Claim("CPF", funcionario.senha_func)
            }, "AppAplicationCookie");
            Request.GetOwinContext().Authentication.SignIn(identity);
            if (!String.IsNullOrWhiteSpace(vielmodel.UrlRetorno) || Url.IsLocalUrl(vielmodel.UrlRetorno))


                return Redirect(vielmodel.UrlRetorno);


            else
            {
                funcionario = funcionarioDAO.SelectFuncionario(vielmodel.senha);



                Session["id_cli"] = funcionario.id_func.ToString();
                return RedirectToAction("Index", "Produto");
            }





        }
    }
}