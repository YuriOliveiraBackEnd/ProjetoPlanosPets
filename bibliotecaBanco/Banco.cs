using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace bibliotecaBanco
{
    public class Banco : IDisposable
    {
        private readonly MySqlConnection conexaobanco;

        public Banco()
        {
            conexaobanco = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
            conexaobanco.Open();
        }

        public void Executar(string StrQuery)
        {
            var vComando = new MySqlCommand
            {
                CommandText = StrQuery,
                CommandType = CommandType.Text,
                Connection = conexaobanco
            };
            vComando.ExecuteNonQuery();
        }

        public MySqlDataReader Retornar(string StrQuery)
        {
            var comandoreturn = new MySqlCommand(StrQuery, conexaobanco);
            return comandoreturn.ExecuteReader();
        }

        public void Dispose()
        {
            if (conexaobanco.State == ConnectionState.Open)
                conexaobanco.Close();   
        }

    }
}
