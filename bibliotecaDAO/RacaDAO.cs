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
    public class RacaDAO
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertRaca(ModelRacas racas)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@nome_raca, @ft_raca, @id_func);";
            comand.Parameters.Add("@nome_raca", MySqlDbType.VarChar).Value = racas.nome_raca;
            comand.Parameters.Add("@ft_raca", MySqlDbType.VarChar).Value = racas.ft_raca;
            comand.Parameters.Add("@id_func", MySqlDbType.VarChar).Value = racas.id_func;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }

    }
}
