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
    public class FornecedorDAO
    {
        public Banco db;
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertFornecedor(ModelFornecedor fornecedor)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@nome_forn, @tel_forn, @email_forn, @CNPJ_forn, @cep_forn, @num_forn, @logradouro_forn, @id_prod);";
            comand.Parameters.Add("@nome_forn", MySqlDbType.VarChar).Value = fornecedor.nome_forn;
            comand.Parameters.Add("@tel_forn", MySqlDbType.VarChar).Value = fornecedor.tel_forn;
            comand.Parameters.Add("@email_forn", MySqlDbType.VarChar).Value = fornecedor.email_forn;
            comand.Parameters.Add("@CNPJ_forn", MySqlDbType.VarChar).Value = fornecedor.CNPJ_forn;
            comand.Parameters.Add("@cep_forn", MySqlDbType.VarChar).Value = fornecedor.cep_forn;
            comand.Parameters.Add("@num_forn", MySqlDbType.VarChar).Value = fornecedor.num_forn;
            comand.Parameters.Add("@logradouro_forn", MySqlDbType.VarChar).Value = fornecedor.logradouro_forn;
            comand.Parameters.Add("@id_prod", MySqlDbType.VarChar).Value = fornecedor.id_prod;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }
        public List<ModelFornecedor> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from fornecedor;";
                var retorno = db.Retornar(strQuery);
                return ListaDeFornecedor(retorno);
            }

        }
        public List<ModelFornecedor> ListaDeFornecedor(MySqlDataReader retorno)
        {
            var fornecedores = new List<ModelFornecedor>();
            while (retorno.Read())
            {
                var TempForn = new ModelFornecedor()
                {
                    id_forn = int.Parse(retorno["id_forn"].ToString()),
                    nome_forn = retorno["nome_forn"].ToString(),
                    email_forn = retorno["email_forn"].ToString(),
                    CNPJ_forn = retorno["CNPJ_forn"].ToString(),
                    tel_forn = retorno["tel_forn"].ToString(),
                    num_forn = int.Parse(retorno["num_forn"].ToString()),
                    cep_forn = retorno["cep_forn"].ToString(),
                    logradouro_forn = retorno["logradouro_forn"].ToString(),
                    id_prod = int.Parse(retorno["id_prod"].ToString())

                };

                fornecedores.Add(TempForn);
            }
            retorno.Close();
            return fornecedores;
        }

    }
}
