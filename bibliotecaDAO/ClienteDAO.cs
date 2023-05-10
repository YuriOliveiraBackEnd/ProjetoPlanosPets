using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using bibliotecaModel;

namespace bibliotecaDAO
{
    public class ClienteDAO
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertCliente(ModelCliente cliente)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@nome_cli, @tel_cli, @email_cli, @CPF_cli, @cep_cli, @num_cli, @logradouro_cli, @nasc_cli);";
            comand.Parameters.Add("@nome_cli", MySqlDbType.VarChar).Value = cliente.nome_cli;
            comand.Parameters.Add("@tel_cli", MySqlDbType.VarChar).Value = cliente.tel_cli;
            comand.Parameters.Add("@email_cli", MySqlDbType.VarChar).Value = cliente.email_cli;
            comand.Parameters.Add("@CPF_cli", MySqlDbType.VarChar).Value = cliente.CPF_cli;
            comand.Parameters.Add("@cep_cli", MySqlDbType.VarChar).Value = cliente.cep_cli;
            comand.Parameters.Add("@num_cli", MySqlDbType.VarChar).Value = cliente.num_cli;
            comand.Parameters.Add("@logradouro_cli", MySqlDbType.VarChar).Value = cliente.logradouro_cli;
            comand.Parameters.Add("@nasc_cli", MySqlDbType.VarChar).Value = cliente.nasc_cli;
           
            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
