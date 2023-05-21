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
    public class RacaDAO
    {
        public Banco db;
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();

        public void InsertRaca(ModelRacas racas)
        {
            conexao.Open();
            comand.CommandText = "call spInsertCliente(@nome_raca, @ft_raca, @id_func);";
            comand.Parameters.Add("@nome_raca", MySqlDbType.VarChar).Value = racas.nome_raca;
            comand.Parameters.Add("@ft_raca", MySqlDbType.VarChar).Value = racas.ft_raca;
            comand.Parameters.Add("@id_func", MySqlDbType.VarChar).Value = racas.id_func;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }

        public List<ModelRacas> Listar()
        {
            using (db = new Banco())
            {
                var strquery = ("select * from Raca;");
                var retorno = db.Retornar(strquery);
                return ListaDeRacas(retorno);

            }
        }
        public List<ModelRacas> ListaDeRacas(MySqlDataReader retorno)
        {
            var racas = new List<ModelRacas>();
            while (retorno.Read())
            {
                var TempRacas = new ModelRacas()
                {
                    id_raca = int.Parse(retorno["id_raca"].ToString()),
                    id_func = int.Parse(retorno["id_func"].ToString()),
                    ft_raca = retorno["ft_raca"].ToString(),
                    nome_raca = retorno["nome_raca"].ToString()

                };

                racas.Add(TempRacas);
            }
            retorno.Close();
            return racas;
        }
        public ModelRacas ListarId(int Id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from Raca where id_raca = {0};", Id);
                var retorno = db.Retornar(strQuery);
                return ListaDeRacas(retorno).FirstOrDefault();
            }
        }

        public void UpdateRaca(ModelRacas raca)
        {
            var strQuery = "";
            strQuery += "update Raca set ";
            strQuery += string.Format("nome_raca = '{0}', ft_raca = '{1}', id_func = '{2}' where id_raca = {3};", raca.nome_raca, raca.ft_raca, raca.id_func, raca.id_raca);

            using (db = new Banco())
            {
                db.Executar(strQuery);
            }
        }

        public void DeleteRaca(ModelRacas raca)
        {
            var strQuery = "";
            strQuery += "delete from Raca ";
            strQuery += string.Format("where id_raca = {0};", raca.id_raca);

            using (db = new Banco())
            {
                db.Executar(strQuery);
            }
        }

        public void Save(ModelRacas raca)
        {
            if (raca.id_raca > 0)
            {
                UpdateRaca(raca);
            }
            else
            {
                InsertRaca(raca);
            }
        }

    }
}
