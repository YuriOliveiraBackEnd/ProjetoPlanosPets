using bibliotecaBanco;
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
        public Banco db;
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

        public List<ModelFuncionario> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from funcionario;";
                var retorno = db.Retornar(strQuery);
                return ListaDeFuncionarios(retorno);
            }

        }
        public List<ModelFuncionario> ListaDeFuncionarios(MySqlDataReader retorno)
        {
            var funcionarios = new List<ModelFuncionario>();
            while (retorno.Read())
            {
                var TempFunc = new ModelFuncionario()
                {
                    id_func = int.Parse(retorno["id_func"].ToString()),
                    nome_func = retorno["nome_func"].ToString(),
                    email_func = retorno["email_func"].ToString(),
                    CPF_func = retorno["CPF_func"].ToString(),
                    tel_func = retorno["tel_func"].ToString(),
                    num_func = int.Parse(retorno["num_func"].ToString()),
                    cep_func = retorno["cep_func"].ToString(),
                    logradouro_func = retorno["logradouro_func"].ToString(),
                    nasc_func = DateTime.Parse(retorno["nasc_func"].ToString())

                };

                funcionarios.Add(TempFunc);
            }
            retorno.Close();
            return funcionarios;
        }
    }
}
