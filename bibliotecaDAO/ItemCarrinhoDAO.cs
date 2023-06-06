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
    public class ItemCarrinhoDAO
    {
        public Banco db;
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();
        public void inserirItem(ModelItemCarrinho cm)
        {
            conexao.Open();
            comand.CommandText = "call InsertItensCarrinho( @qt_itens,@id_venda , @valorParcial,@id_prod ); ";

            comand.Parameters.Add("@id_venda", MySqlDbType.VarChar).Value = cm.PedidoID;
            comand.Parameters.Add("@id_prod", MySqlDbType.VarChar).Value = cm.ProdutoID;
            comand.Parameters.Add("@qt_itens", MySqlDbType.VarChar).Value = cm.Qtd;
            comand.Parameters.Add("@valorParcial", MySqlDbType.VarChar).Value = cm.valorParcial;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
