using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;
using System.Configuration;
using MySql.Data.MySqlClient;
using bibliotecaDAO;
using bibliotecaModel;
using System.IO;

namespace PlanosPets.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public void CarregaRaca()
        {
            List<SelectListItem> raca = new List<SelectListItem>();



            using (MySqlConnection con = new MySqlConnection("Server=localhost;DataBase=db4luck;User=root;pwd=metranca789456123"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("select * from raca", con);
                MySqlDataReader rdr = cmd.ExecuteReader();



                while (rdr.Read())
                {
                    raca.Add(new SelectListItem
                    {                       
                        Text = rdr[1].ToString(),
                        Value = rdr[0].ToString()
                    });
                }
                con.Close();
            }
            ViewBag.raca = new SelectList(raca, "Value", "Text","Text1");
        }
        public ActionResult Index()
        {
            if (Session["FuncLogado"] == null)
            {
                return RedirectToAction("SemAcesso", "Login");
            }
            else
            {
                var metodoPet = new PetDAO();
                var listaPet = metodoPet.Listar();
                return View(listaPet);
            }
        }
       
       
     public ActionResult Cadastrar()
        {
            CarregaRaca();
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(ModelPets pets, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
                return View(pets);
            PetDAO novapetsDAO = new PetDAO();
            string Email = Session["ClienteLogado"] as string;
            string id = new PetDAO().SelectIdDoCli(Email);
            pets.id_cli = int.Parse(id);
            //string RGA = new PetDAO().SelectRGA(pets.RGA);
            //if (RGA == pets.RGA)
            //{
            //    ViewBag.RGA = "RGA já cadastrado";
            //    return View();
            //}

            string arquivo = Path.GetFileName(file.FileName);

            string file2 = "/images/" + Path.GetFileName(file.FileName);

            string _path = Path.Combine(Server.MapPath("~/images"), arquivo);

            file.SaveAs(_path);

            pets.ft_pet = file2;
          


            ModelPets novopet = new ModelPets()
            {
                nome_pet = pets.nome_pet,
                nasc_pet = pets.nasc_pet,
                RGA = pets.RGA,
                id_cli = pets.id_cli,
                ft_pet = pets.ft_pet,
                id_raca = int.Parse(Request["raca"])
            };
            novapetsDAO.InsertPet(novopet);

            return RedirectToAction("Index");
        }

        public ActionResult Atualizar(int id)
        {
            if (Session["FuncLogado"] == null)
            {
                return RedirectToAction("SemAcesso", "Login");
            }
            else
            {
                CarregaRaca();
                var metodopet = new PetDAO();
                var pet = metodopet.ListarId(id);
                if (pet == null)
                {
                    return HttpNotFound();
                }
                return View(pet);
            }
        }



        [HttpPost]
        public ActionResult Atualizar(ModelPets pet)
        {
            if (ModelState.IsValid)
            {
                var metodopet = new PetDAO();
                pet.id_raca = int.Parse(Request["raca"]);
                metodopet.UpdatePet(pet);
                return RedirectToAction("Index");
            }
            return View(pet);
        }
        public ActionResult Excluir(int id)
        {
            if (Session["FuncLogado"] == null)
            {
                return RedirectToAction("SemAcesso", "Login");
            }
            else
            {
                var metodopet = new PetDAO();
                var pet = metodopet.ListarId(id);
                if (pet == null)
                {
                    return HttpNotFound();
                }
                return View(pet);
            }
        }
        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int id)
        {
            var metodopet = new PetDAO();
            ModelPets pet = new ModelPets();
            pet.id_pet = id;
            metodopet.DeletePet(pet);
            return RedirectToAction("Index");
        }
        public ActionResult Detalhes(int id)
        {
            if (Session["FuncLogado"] == null)
            {
                return RedirectToAction("SemAcesso", "Login");
            }
            else
            {
                var metodopet = new PetDAO();
                var pet = metodopet.ListarId(id);
                if (pet == null)
                {
                    return HttpNotFound();
                }
                return View(pet);
            }
        }
    }
}