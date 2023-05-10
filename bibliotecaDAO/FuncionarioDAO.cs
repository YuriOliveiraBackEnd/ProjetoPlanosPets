using bibliotecaModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaDAO
{
    public class FuncionarioDAO
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertFuncionario(ModelFuncionario funcionario)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@nome_func, @tel_func, @email_func, @CPF_func, @cep_func, @num_func, @logradouro_func, @nasc_func);";
            comand.Parameters.Add("@nome_cli", MySqlDbType.VarChar).Value = funcionario.nome_func;
            comand.Parameters.Add("@tel_cli", MySqlDbType.VarChar).Value = funcionario.tel_func;
            comand.Parameters.Add("@email_cli", MySqlDbType.VarChar).Value = funcionario.email_func;
            comand.Parameters.Add("@CPF_cli", MySqlDbType.VarChar).Value = funcionario.CPF_func;
            comand.Parameters.Add("@cep_cli", MySqlDbType.VarChar).Value = funcionario.cep_func;
            comand.Parameters.Add("@num_cli", MySqlDbType.VarChar).Value = funcionario.num_func;
            comand.Parameters.Add("@logradouro_cli", MySqlDbType.VarChar).Value = funcionario.logradouro_func;
            comand.Parameters.Add("@nasc_cli", MySqlDbType.VarChar).Value = funcionario.nasc_func;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }


    }
}
