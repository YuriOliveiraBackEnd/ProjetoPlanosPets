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
            comand.CommandText = "call spInsertProduto(@valor_unitario, @quant, @desc_prod, @ft_prod, @id_categoria, @id_func);";
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
                var strQuery = "Select * from Produto;";
                var retorno = db.Retornar(strQuery);
                return ListaDeProduto(retorno);
            }

        }
        public List<ModelProduto> ListaDeProduto(MySqlDataReader retorno)
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
        public ModelProduto Pesquisa(string pesquisar)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from Produto where nome_prod = '%{0}%';", pesquisar);
                var retorno = db.Retornar(strQuery);
                return ListaDeProduto(retorno).FirstOrDefault();
            }
        }

        public ModelProduto ListarId(int Id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from Produto where id_prod = {0};", Id);
                var retorno = db.Retornar(strQuery);
                return ListaDeProduto(retorno).FirstOrDefault();
            }
        }

        public void UpdateProduto(ModelProduto produto)
        {
            var strQuery = "";
            strQuery += "update Produto set ";
            strQuery += string.Format("nome_prod = '{0}', valor_unitario = '{1}', quant = '{2}', desc_prod = '{3}', ft_prod = '{4}', id_categoria = '{5}', id_func = '{6}' where id_prod = {8};", produto.valor_unitario, produto.quant, produto.desc_prod, produto.ft_prod, produto.id_categoria, produto.id_func, produto.id_prod);

            using (db = new Banco())
            {
                db.Executar(strQuery);
            }
        }

        public void DeleteProduto(ModelProduto produto)
        {
            var strQuery = "";
            strQuery += "delete from Produto ";
            strQuery += string.Format("where id_prod = {0};", produto.id_prod);

            using (db = new Banco())
            {
                db.Executar(strQuery);
            }
        }

        public void Save(ModelProduto produto)
        {
            if (produto.id_prod > 0)
            {
                UpdateProduto(produto);
            }
            else
            {
                InsertProduto(produto);
            }
        }
    }
}
