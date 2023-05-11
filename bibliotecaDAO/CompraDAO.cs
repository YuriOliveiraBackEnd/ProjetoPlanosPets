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
    public class CompraDAO
    {
        public Banco db;
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertCompra(ModelCompra compra)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCompra(@pagamento, @valor_total, @id_cli);";
            comand.Parameters.Add("@pagamento", MySqlDbType.VarChar).Value = compra.pagamento;
            comand.Parameters.Add("@valor_total", MySqlDbType.VarChar).Value = compra.valor_total;
            comand.Parameters.Add("@id_cli", MySqlDbType.VarChar).Value = compra.id_cli;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }
        public List<ModelCompra> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from compras;";
                var retorno = db.Retornar(strQuery);
                return ListaDeCompras(retorno);
            }

        }
        public List<ModelCompra> ListaDeCompras(MySqlDataReader retorno)
        {
            var compras = new List<ModelCompra>();
            while (retorno.Read())
            {
                var TempCompras = new ModelCompra()
                {
                    id_compra = int.Parse(retorno["id_compra"].ToString()),
                    id_cli = int.Parse(retorno["id_cli"].ToString()),
                    pagamento = retorno["pagamento"].ToString(),
                    valor_total = Double.Parse(retorno["valor_total"].ToString()),
                  

                };

                compras.Add(TempCompras);
            }
            retorno.Close();
            return compras;
        }


    }
}
