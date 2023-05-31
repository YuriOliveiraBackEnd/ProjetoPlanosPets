﻿using bibliotecaBanco;
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
            comand.CommandText = "call InsertProduto(@nome_prod,@valor_unitario, @quant, @desc_prod, @ft_prod, @id_func,@id_categoria);";
            comand.Parameters.Add("@valor_unitario", MySqlDbType.VarChar).Value = produto.valor_unitario;
            comand.Parameters.Add("@nome_prod", MySqlDbType.VarChar).Value = produto.nome_prod;
            comand.Parameters.Add("@quant", MySqlDbType.VarChar).Value = produto.quant;
            comand.Parameters.Add("@desc_prod", MySqlDbType.VarChar).Value = produto.desc_prod;
            comand.Parameters.Add("@ft_prod", MySqlDbType.VarChar).Value = produto.ft_prod;
            comand.Parameters.Add("@id_func", MySqlDbType.VarChar).Value = produto.id_func;
            comand.Parameters.Add("@id_categoria", MySqlDbType.VarChar).Value = produto.id_categoria;
         

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }
        public string SelectIdDofunc(string Email)
        {
            string VEmail = "";
            conexao.Open();
            comand.CommandText = "call SelectIdfunc(@email_func);";
            comand.Parameters.Add("@email_func", MySqlDbType.VarChar).Value = Email;
            comand.Connection = conexao;
            object result = comand.ExecuteScalar();
            if (result != null)
            {
                int id = (int)result; // Converte o resultado para int
                VEmail = id.ToString();
            }
            return VEmail;
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
                    nome_prod = retorno["nome_prod"].ToString(),
                    id_categoria = int.Parse(retorno["id_categoria"].ToString()),
                    id_func = int.Parse(retorno["id_func"].ToString()),
                    quant = int.Parse(retorno["quant"].ToString()),
                    valor_unitario = double.Parse(retorno["valor_unitario"].ToString()),
                    desc_prod = retorno["desc_prod"].ToString(),
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
                var strQuery = string.Format("select * from Produto where id_prod = '{0}';", Id);
                var retorno = db.Retornar(strQuery);
                return ListaDeProduto(retorno).FirstOrDefault();
            }
        }

        public void UpdateProduto(ModelProduto produto)
        {
           
                var strQuery = "";
                strQuery += "Update produto set ";
                strQuery += string.Format("nome_prod = '{0}',", produto.nome_prod);
                strQuery += string.Format("valor_unitario= '{0}', ", produto.valor_unitario);
                strQuery += string.Format("quant = '{0}',", produto.quant);
                strQuery += string.Format("desc_prod = '{0}',", produto.desc_prod);
                strQuery += string.Format("id_categoria = '{0}',", produto.id_categoria);
                strQuery += string.Format("ft_prod = '{0}',", produto.ft_prod);
                strQuery += string.Format("id_func = '{0}'", produto.id_func);
      
                strQuery += string.Format("where id_prod = '{0}'", produto.id_prod);



            using (db = new Banco())
                {
                    db.Executar(strQuery);
                }

            
        }

        public void DeleteProduto(ModelProduto produto)
        {
            var strQuery = "";
            strQuery += "delete from produto ";
            strQuery += string.Format("where id_prod = '{0}';", produto.id_prod);

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
