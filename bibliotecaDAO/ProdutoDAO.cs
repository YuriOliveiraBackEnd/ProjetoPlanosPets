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
    public class ProdutoDAO
    {
        public Banco db;
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
        public List<ModelProduto> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from produto;";
                var retorno = db.Retornar(strQuery);
                return ListaDeFuncionarios(retorno);
            }

        }
        public List<ModelProduto> ListaDeFuncionarios(MySqlDataReader retorno)
        {
            var produtos = new List<ModelProduto>();
            while (retorno.Read())
            {
                var TempProd = new ModelProduto()
                {
                    id_prod = int.Parse(retorno["id_prod"].ToString()),
                    id_categoria = int.Parse(retorno["id_categoria"].ToString()),
                    id_func = int.Parse(retorno["id_func"].ToString()),
                    quant = int.Parse(retorno["quant"].ToString()),
                    valor_unitario = double.Parse(retorno["valor_unitario"].ToString()),
                    desc_prod = retorno["desc_prod"].ToString(),
                    categoria = retorno["categoria"].ToString(),
                    ft_prod = retorno["ft_prod"].ToString()

                };

                produtos.Add(TempProd);
            }
            retorno.Close();
            return produtos;
        }

    }
}
