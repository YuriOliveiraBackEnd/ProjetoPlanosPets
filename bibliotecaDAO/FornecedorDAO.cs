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
    public class FornecedorDAO
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertFornecedor(ModelFornecedor fornecedor)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@nome_forn, @tel_forn, @email_forn, @CNPJ_forn, @cep_forn, @num_forn, @logradouro_forn, @id_prod);";
            comand.Parameters.Add("@nome_cli", MySqlDbType.VarChar).Value = fornecedor.nome_forn;
            comand.Parameters.Add("@tel_cli", MySqlDbType.VarChar).Value = fornecedor.tel_forn;
            comand.Parameters.Add("@email_cli", MySqlDbType.VarChar).Value = fornecedor.email_forn;
            comand.Parameters.Add("@CPF_cli", MySqlDbType.VarChar).Value = fornecedor.CNPJ_forn;
            comand.Parameters.Add("@cep_cli", MySqlDbType.VarChar).Value = fornecedor.cep_forn;
            comand.Parameters.Add("@num_cli", MySqlDbType.VarChar).Value = fornecedor.num_forn;
            comand.Parameters.Add("@logradouro_cli", MySqlDbType.VarChar).Value = fornecedor.logradouro_forn;
            comand.Parameters.Add("@id_prod", MySqlDbType.VarChar).Value = fornecedor.id_prod;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }

    }
}
