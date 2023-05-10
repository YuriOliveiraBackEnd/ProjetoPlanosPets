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
    public class VendaDAO
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertVenda(ModelVenda venda)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@id_compra, @id_prod, @data_venda, @quant_venda);";
            comand.Parameters.Add("@id_compra", MySqlDbType.VarChar).Value = venda.id_compra;
            comand.Parameters.Add("@id_prod", MySqlDbType.VarChar).Value = venda.id_prod;
            comand.Parameters.Add("@data_venda", MySqlDbType.VarChar).Value = venda.data_venda;
            comand.Parameters.Add("@quant_venda", MySqlDbType.VarChar).Value = venda.quant_venda;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }


    }
}
