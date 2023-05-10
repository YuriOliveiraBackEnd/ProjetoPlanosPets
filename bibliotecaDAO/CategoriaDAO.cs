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
    public class CategoriaDAO
    {
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertCategoria(ModelCategorias categorias)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@nome_categoria, @desc_categoria);";
            comand.Parameters.Add("@nome_categoria", MySqlDbType.VarChar).Value = categorias.nome_categoria;
            comand.Parameters.Add("@desc_categoria", MySqlDbType.VarChar).Value = categorias.desc_categoria;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }
    }
}
