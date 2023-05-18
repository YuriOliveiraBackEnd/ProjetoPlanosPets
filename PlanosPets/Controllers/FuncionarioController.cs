using bibliotecaDAO;
using bibliotecaModel;
using MySqlX.XDevAPI;
using PlanosPets.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        //public ActionResult Login()
        //{
        //    return View();
        //}
        //LoginDAO login = new LoginDAO();

        //[HttpPost]
        //public ActionResult Login(ModelFuncionario verLoginFunc)
        //{
        //    login.TestarUsuario(verLoginFunc);

        //    if (verLoginFunc.email_func != null && verLoginFunc.senha_func != null)
        //    {
        //        Session["emaillogadofunc"] = verLoginFunc.email_func;
        //        Session["senhalogadofunc"] = verLoginFunc.senha_func;

        //        return RedirectToAction("Index", "Home");
        //    }
        //    else
        //    {
        //        ViewBag.msgLogar = "Usuário não encontrado. Verifique se o nome e a senha estão corretos";
        //        return View();
        //    }
        //   }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ModelFuncionario funcionario)
        {
            if (!ModelState.IsValid)
                return View(funcionario);
            FuncionarioDAO novoFuncionarioDAO = new FuncionarioDAO();
            //string cpf = new FuncionarioDAO().SelectCPFFunc(funcionario.CPF_func);
            //string email = new FuncionarioDAO().SelectEmailFunc(funcionario.email_func);
            //if (cpf == funcionario.CPF_func && email == funcionario.email_func)
            //{
            //    ViewBag.Email = "Email já existente";
            //    ViewBag.CPF = "CPF já existente";
            //    return View(funcionario);
            //}

            //else if (cpf == funcionario.CPF_func)
            //{
            //    ViewBag.CPF = "CPF já existente";
            //    return View(funcionario);
            //}

            //else if (email == funcionario.email_func)
            //{
            //    ViewBag.Email = "Email já existente";
            //    return View(funcionario);
            //};


            var metodoFuncionario = new FuncionarioDAO();
                ModelFuncionario novoFuncionario = new ModelFuncionario()
                {
                    nome_func = funcionario.nome_func,
                    email_func = funcionario.email_func,
                    CPF_func = funcionario.CPF_func,
                    cep_func = funcionario.cep_func,
                    num_func = funcionario.num_func,
                    logradouro_func = funcionario.logradouro_func,
                    nasc_func = funcionario.nasc_func,
                    tel_func = funcionario.tel_func,
                    senha_func = funcionario.senha_func
                };
                metodoFuncionario.InsertFuncionario(novoFuncionario);


            return RedirectToAction("Index");
        }
        public ActionResult SelectEmail(string Email)
        {
            bool EmailExists;
            string email = new FuncionarioDAO().SelectEmailFunc(Email);
            if (email.Length == 0)

                EmailExists = false;

            else

                EmailExists = true;

            return Json(!EmailExists, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult SelectCPF(string CPF)
        //{
        //    bool CPFExists;
        //    string cpf = new FuncionarioDAO().SelectCPFFunc(CPF);
        //    if (cpf.Length == 0)

        //        CPFExists = false;

        //    else

        //        CPFExists = true;

        //    return Json(!CPFExists, JsonRequestBehavior.AllowGet);
        //}

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


            if (funcionario == null | funcionario.senha_func != vielmodel.senha)
            {
                ModelState.AddModelError("Senha", "Senha incorreto");
                return View(vielmodel);
            }

            if (funcionario == null | funcionario.email_func != vielmodel.Email)
            {
                ModelState.AddModelError("Email", "Email incorreto");
                return View(vielmodel);
            }

            var identity = new ClaimsIdentity(new[]
             {
                new Claim(ClaimTypes.Name, funcionario.senha_func),
                new Claim("Senha", funcionario.senha_func)
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

        public ActionResult Excluir(int id)
        {
            var metodoFuncionario = new FuncionarioDAO();
            metodoFuncionario.Excluir(id);
            return RedirectToAction("Index");
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