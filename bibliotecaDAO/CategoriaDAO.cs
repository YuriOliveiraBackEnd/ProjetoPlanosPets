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
    public class CategoriaDAO
    {
        public Banco db;
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
        public List<ModelCategorias> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from categoria;";
                var retorno = db.Retornar(strQuery);
                return ListaDeCategoria(retorno);
            }

        }
        public List<ModelCategorias> ListaDeCategoria(MySqlDataReader retorno)
        {
            var categorias = new List<ModelCategorias>();
            while (retorno.Read())
            {
                var TempCategorias = new ModelCategorias()
                {
                    id_categoria = int.Parse(retorno["id_categoria"].ToString()),
                    desc_categoria = retorno["desc_categorias"].ToString(),
                    nome_categoria = retorno["nome_categoria"].ToString(),
               
                };

                categorias.Add(TempCategorias);
            }
            retorno.Close();
            return categorias;
        }
    }
}
