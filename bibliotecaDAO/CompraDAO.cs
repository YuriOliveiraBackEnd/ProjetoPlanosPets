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
    public class CompraDAO
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertCompra(ModelCompra compra)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@pagamento, @valor_total, @id_cli);";
            comand.Parameters.Add("@pagamento", MySqlDbType.VarChar).Value = compra.pagamento;
            comand.Parameters.Add("@valor_total", MySqlDbType.VarChar).Value = compra.valor_total;
            comand.Parameters.Add("@id_cli", MySqlDbType.VarChar).Value = compra.id_cli;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }


    }
}
