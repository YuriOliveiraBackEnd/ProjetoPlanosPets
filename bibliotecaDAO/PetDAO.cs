using bibliotecaBanco;
using bibliotecaModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
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
            comand.CommandText = "call spInsertCliente(@nome_pet, @ft_pet, @nasc_pet, @RGA, @id_cli, @id_raca);";
            comand.Parameters.Add("@nome_pet", MySqlDbType.VarChar).Value = pets.nome_pet;
            comand.Parameters.Add("@ft_pet", MySqlDbType.VarChar).Value = pets.ft_pet;
            comand.Parameters.Add("@nasc_pet", MySqlDbType.VarChar).Value = pets.nasc_pet;
            comand.Parameters.Add("@RGA", MySqlDbType.VarChar).Value = pets.RGA;
            comand.Parameters.Add("@id_cli", MySqlDbType.VarChar).Value = pets.id_cli;
            comand.Parameters.Add("@id_raca", MySqlDbType.VarChar).Value = pets.id_raca;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }
        public List<ModelPets> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from pet;";
                var retorno = db.Retornar(strQuery);
                return ListaDeFuncionarios(retorno);
            }

        }
        public List<ModelPets> ListaDeFuncionarios(MySqlDataReader retorno)
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

    }
}
