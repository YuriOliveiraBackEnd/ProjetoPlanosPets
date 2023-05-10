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
    public class ProdutoDAO
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertProduto(ModelProduto produto)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@valor_unitario, @quant, @desc_prod, @ft_prod, @id_categoria, @id_func);";
            comand.Parameters.Add("@valor_unitario", MySqlDbType.VarChar).Value = produto.valor_unitario;
            comand.Parameters.Add("@quant", MySqlDbType.VarChar).Value = produto.quant;
            comand.Parameters.Add("@desc_prod", MySqlDbType.VarChar).Value = produto.desc_prod;
            comand.Parameters.Add("@ft_prod", MySqlDbType.VarChar).Value = produto.ft_prod;
            comand.Parameters.Add("@id_categoria", MySqlDbType.VarChar).Value = produto.id_categoria;
            comand.Parameters.Add("@id_func", MySqlDbType.VarChar).Value = produto.id_func;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }

    }
}
