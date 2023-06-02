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
                MySqlCommand cmd = new MySqlCommand("select * from Raca", con);
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
            ViewBag.raca = new SelectList(raca, "Value", "Text");
        }

        public ActionResult Index()
        {

            var metodoPet = new PetDAO();
            var listaPet = metodoPet.Listar();
            return View(listaPet);
            
        }

        public ActionResult Cadastrar()
        {
            if (Session["ClienteLogado"] == null)
            {
                return RedirectToAction("Login", "Login");
            }
            else
            {
                CarregaRaca();
                return View();
            }
        }
        [HttpPost]
        public ActionResult Cadastrar(ModelCliente pets, HttpPostedFileBase file)
        {

            PetDAO novapetsDAO = new PetDAO();
            string Email = Session["ClienteLogado"] as string;
            string id = new PetDAO().SelectIdDoCli(Email);
            pets.id_cli = int.Parse(id);


            string arquivo = Path.GetFileName(file.FileName);

            string file2 = "/images/" + Path.GetFileName(file.FileName);

            string _path = Path.Combine(Server.MapPath("~/images"), arquivo);

            file.SaveAs(_path);

            pets.ft_pet = file2;



            ModelCliente novopet = new ModelCliente()
            {
                nome_pet = pets.nome_pet,
                nasc_pet = pets.nasc_pet,
                RGA = pets.RGA,
                id_cli = pets.id_cli,
                ft_pet = pets.ft_pet,
                id_raca = int.Parse(Request["raca"])
            };
            novapetsDAO.InsertPet(novopet);

            return RedirectToAction("Index","Home");
        }
    

        public ActionResult Atualizar(int id)
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



        [HttpPost]
        public ActionResult Atualizar(ModelCliente pet)
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

            var metodopet = new PetDAO();
            var pet = metodopet.ListarId(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
            
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirma(int id)
        {
            var metodopet = new PetDAO();
            ModelCliente pet = new ModelCliente();
            pet.id_pet = id;
            metodopet.DeletePet(pet);
            return RedirectToAction("Index");
        }

        public ActionResult Detalhes(int id)
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