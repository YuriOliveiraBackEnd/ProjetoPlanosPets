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
    public class VendaDAO
    {
        public Banco db;
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertVenda(ModelVenda venda)
        {
            conexao.Open();
            comand.CommandText = "call InsertVenda(@id_cli,@pagamento,@datavenda,@horaVenda, @valorFinal) ;";
            comand.Parameters.Add("@pagamento", MySqlDbType.VarChar).Value = venda.pagamento;
            comand.Parameters.Add("@datavenda", MySqlDbType.VarChar).Value = venda.data_venda;
            comand.Parameters.Add("@id_cli", MySqlDbType.VarChar).Value = venda.id_cli;
            comand.Parameters.Add("@horaVenda", MySqlDbType.VarChar).Value = venda.horaVenda;
            comand.Parameters.Add("@valorFinal", MySqlDbType.VarChar).Value = venda.ValorTotal;


            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();

        
        }
        //public List<ModelVenda> Listar()
        //{
        //    using (db = new Banco())
        //    {
        //        var strquery = ("select * from vendas;");
        //        var retorno = db.Retornar(strquery);
        //        return ListaDeVendas(retorno);

        //    }
        //}
        //public List<ModelVenda> ListaDeVendas(MySqlDataReader retorno)
        //{
        //    var vendas = new List<ModelVenda>();
        //    while (retorno.Read())
        //    {
        //        var TempVendas = new ModelVenda()
        //        {
        //            id_venda = int.Parse(retorno["id_venda"].ToString()),
        //            id_compra = int.Parse(retorno["id_compra"].ToString()),
        //            id_prod = int.Parse(retorno["id_prod"].ToString()),
        //            data_venda = DateTime.Parse(retorno["data_venda"].ToString()),
        //            quant_venda = int.Parse(retorno["quant_venda"].ToString()),

        //        };

        //        vendas.Add(TempVendas);
        //    }
        //    retorno.Close();
        //    return vendas;
        //}

        //public ModelVenda ListarId(int Id)
        //{
        //    using (db = new Banco())
        //    {
        //        var strQuery = string.Format("select * from Venda where id_venda = {0};", Id);
        //        var retorno = db.Retornar(strQuery);
        //        return ListaDeVendas(retorno).FirstOrDefault();
        //    }
        //}
        MySqlDataReader dr;
        public void buscaIdVenda(ModelVenda vend)
        {
            conexao.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT id_venda FROM venda ORDER BY id_venda DESC limit 1",conexao);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                vend.id_venda = dr[0].ToString();
            }
            conexao.Close(); ;
        }
      

        public void DeleteVenda(ModelVenda venda)
        {
            var strQuery = "";
            strQuery += "delete from Venda ";
            strQuery += string.Format("where id_venda = {0};", venda.id_venda);

            using (db = new Banco())
            {
                db.Executar(strQuery);
            }
        }

        //public void Save(ModelVenda venda)
        //{
        //    if (venda.id_venda > 0)
        //    {
        //        UpdateVenda(venda);
        //    }
        //    else
        //    {
        //        InsertVenda(venda);
        //    }
        //}

    }
}
