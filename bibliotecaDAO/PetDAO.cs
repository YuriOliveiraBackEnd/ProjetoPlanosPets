using bibliotecaBanco;
using bibliotecaModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace bibliotecaDAO
{
    public class PetDAO
    {
        public Banco db; 
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertPet(ModelPets pets)
        {
            conexao.Open();
            comand.CommandText = "call InsertPet(@nome_pet, @ft_pet, @nasc_pet, @RGA, @id_cli, @id_raca);";
            comand.Parameters.Add("@nome_pet", MySqlDbType.VarChar).Value = pets.nome_pet;
            comand.Parameters.Add("@ft_pet", MySqlDbType.VarChar).Value = pets.ft_pet;
            comand.Parameters.Add("@nasc_pet", MySqlDbType.DateTime).Value = pets.nasc_pet;
            comand.Parameters.Add("@RGA", MySqlDbType.VarChar).Value = pets.RGA;
            comand.Parameters.Add("@id_cli", MySqlDbType.VarChar).Value = pets.id_cli;
            comand.Parameters.Add("@id_raca", MySqlDbType.VarChar).Value = pets.id_raca;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }
        public string SelectRGA(string vRGA)
        {
            conexao.Open();
            comand.CommandText = "call SelectRGA(@RGA);";
            comand.Parameters.Add("@RGA", MySqlDbType.VarChar).Value = vRGA;
            comand.Connection = conexao;
            string RGA = (string)comand.ExecuteScalar();
            conexao.Close();
            if (RGA == null)



                RGA = "";
            return RGA;

        }
        public string SelectIdDoCli(string Email)
        {
            string VEmail = "";
            conexao.Open();
            comand.CommandText = "call SelectIdcli(@email_cli);";
            comand.Parameters.Add("@email_cli", MySqlDbType.VarChar).Value = Email;
            comand.Connection = conexao;
            object result = comand.ExecuteScalar();
            if (result != null)
            {
                int id = (int)result; // Converte o resultado para int
                VEmail = id.ToString();
            }
            return VEmail;
        }
            public List<ModelPets> Listar() { 
            using (db = new Banco())
            {
                var strQuery = "Select * from Pets;";
                var retorno = db.Retornar(strQuery);
                return ListaDePets(retorno);
            }

        }
        public List<ModelPets> ListaDePets(MySqlDataReader retorno)
        {
            var pets = new List<ModelPets>();
            while (retorno.Read())
            {
                var TempPets = new ModelPets()
                {
                    id_pet = int.Parse(retorno["id_pet"].ToString()),
                    id_cli = int.Parse(retorno["id_cli"].ToString()),
                    id_raca = int.Parse(retorno["id_raca"].ToString()),
                    nome_pet = retorno["nome_pet"].ToString(),
                    ft_pet = retorno["ft_pet"].ToString(),
                    RGA = retorno["RGA"].ToString(),
                    nasc_pet = DateTime.Parse(retorno["nasc_pet"].ToString())

                };

                pets.Add(TempPets);
            }
            retorno.Close();
            return pets;
        }
  
              
        public ModelPets ListarId(int Id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from Pets where id_pet = {0};", Id);
                var retorno = db.Retornar(strQuery);
                return ListaDePets(retorno).FirstOrDefault();
            }
        }

        public void UpdatePet(ModelPets pets)
        {
            var strQuery = "";
            strQuery += "update Pets set ";
            strQuery += string.Format("nome_pet = '{0}',", pets.nome_pet);
            strQuery += string.Format("ft_pet = '{0}',", pets.ft_pet);
            strQuery += string.Format ("nasc_pet= STR_TO_DATE('{0}', '%d/%m/%Y %H :%i: %s'),", pets.nasc_pet);
            strQuery += string.Format(" RGA = '{0}',", pets.RGA);
            strQuery += string.Format(" id_raca = '{0}',", pets.id_raca);
            strQuery += string.Format(" id_cli = '{0}'", pets.id_cli);
            strQuery += string.Format("where id_pet = '{0}'", pets.id_pet);

            using (db = new Banco())
            {
                db.Executar(strQuery);
            }
        }



        public void DeletePet(ModelPets pet)
        {

            using (db = new Banco())
            {
                var strQuery = string.Format("Delete from pets where id_pet = '{0}'",pet.id_pet);
                db.Executar(strQuery);
            }

        }

        public void Save(ModelPets pets)
        {
            if (pets.id_pet > 0)
            {
                UpdatePet(pets);
            }
            else
            {
                InsertPet(pets);
            }
        }


        public List<ModelRacas> GetRaca(string vNome)
        {

            List<ModelRacas> ListRaca = new List<ModelRacas>();
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand("call SelectRaca(@nome_raca);");
            cmd.CommandType = CommandType.StoredProcedure;
            comand.Parameters.Add("@nome_raca", MySqlDbType.VarChar).Value = vNome;
            MySqlDataAdapter sd = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            foreach (DataRow dr in dt.Rows)

            {
                ListRaca.Add(

                    new ModelRacas

                    {

                        id_raca = int.Parse(Convert.ToString(dr["id_raca"])),

                        nome_raca = Convert.ToString(dr["nome_raca"]),

                   

                    });

            }

            return ListRaca;
       
        }
  
        
    }
}
