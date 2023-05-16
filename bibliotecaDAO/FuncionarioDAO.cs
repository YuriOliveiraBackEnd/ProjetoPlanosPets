using bibliotecaBanco;
using bibliotecaModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace bibliotecaDAO
{
    public class FuncionarioDAO
    {
        public Banco db;
        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();



        public void InsertFuncionario(ModelFuncionario funcionario)
        {
            conexao.Open();
            comand.CommandText = "call InsertFuncionario(@nome_func,@email_func, @CPF_func, @cep_func, @num_func, @logradouro_func, @nasc_func, @tel_func,@senha_func);";
            comand.Parameters.Add("@nome_func", MySqlDbType.VarChar).Value = funcionario.nome_func;
            comand.Parameters.Add("@email_func", MySqlDbType.VarChar).Value = funcionario.email_func;
            comand.Parameters.Add("@CPF_func", MySqlDbType.VarChar).Value = funcionario.CPF_func;
            comand.Parameters.Add("@cep_func", MySqlDbType.VarChar).Value = funcionario.cep_func;
            comand.Parameters.Add("@num_func", MySqlDbType.VarChar).Value = funcionario.num_func;
            comand.Parameters.Add("@logradouro_func", MySqlDbType.VarChar).Value = funcionario.logradouro_func;
            comand.Parameters.Add("@nasc_func", MySqlDbType.DateTime).Value = funcionario.nasc_func;
            comand.Parameters.Add("@tel_func", MySqlDbType.VarChar).Value = funcionario.tel_func;
            comand.Parameters.Add("@senha_func", MySqlDbType.VarChar).Value = funcionario.senha_func;
            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }

        public string SelectEmailFunc(string vEmail)
        {
            conexao.Open();
            comand.CommandText = "call spSelectEmailDoFunc(@email_func);";
            comand.Parameters.Add("email_func", MySqlDbType.VarChar).Value = vEmail;



            comand.Connection = conexao;
            string Email = (string)comand.ExecuteScalar();
            conexao.Close();
            if (Email == null)



                Email = "";
            return Email;




        }



        public string SelectCPFFunc(string vCPF)
        {
            conexao.Open();
            comand.CommandText = "call spSelectCPFDoFunc(@noCPF);";
            comand.Parameters.Add("@noCPF", MySqlDbType.VarChar).Value = vCPF;



            comand.Connection = conexao;
            string CPF = (string)comand.ExecuteScalar();
            conexao.Close();
            if (CPF == null)



                CPF = "";
            return CPF;




        }





        public ModelFuncionario SelectFuncionario(string vNoCPF)
        {
            conexao.Open();
            comand.CommandText = "call spSelectFuncionario(@noCPF);";
            comand.Parameters.Add("@noCPF", MySqlDbType.VarChar).Value = vNoCPF;



            comand.Connection = conexao;
            var readFunc = comand.ExecuteReader();
            var tempFunc = new ModelFuncionario();



            if (readFunc.Read())
            {
                tempFunc.id_func = int.Parse(readFunc["id_func"].ToString());
                tempFunc.nome_func = readFunc["nome_func"].ToString();
                tempFunc.num_func = readFunc["num_func"].ToString();
                tempFunc.cep_func = readFunc["cep_func"].ToString();
                tempFunc.tel_func = readFunc["tel_func"].ToString();
                tempFunc.email_func = readFunc["email_func"].ToString();
                tempFunc.nasc_func = DateTime.Parse(readFunc["nasc_func"].ToString());
                tempFunc.logradouro_func = readFunc["logradouro_func"].ToString();
                tempFunc.senha_func = readFunc["senha_func"].ToString();
                tempFunc.CPF_func = readFunc["CPF_func"].ToString();




            }
            readFunc.Close();
            conexao.Close();
            return tempFunc;
        }
        public List<ModelFuncionario> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from Funcionario;";
                var retorno = db.Retornar(strQuery);
                return ListaDeFuncionarios(retorno);
            }



        }
        public List<ModelFuncionario> ListaDeFuncionarios(MySqlDataReader retorno)
        {
            var funcionarios = new List<ModelFuncionario>();
            while (retorno.Read())
            {
                var TempFunc = new ModelFuncionario()
                {
                    id_func = int.Parse(retorno["id_func"].ToString()),
                    nome_func = retorno["nome_func"].ToString(),
                    email_func = retorno["email_func"].ToString(),
                    CPF_func = retorno["CPF_func"].ToString(),
                    tel_func = retorno["tel_func"].ToString(),
                    num_func = retorno["num_func"].ToString(),
                    cep_func = retorno["cep_func"].ToString(),
                    logradouro_func = retorno["logradouro_func"].ToString(),
                    nasc_func = DateTime.Parse(retorno["nasc_func"].ToString())



                };



                funcionarios.Add(TempFunc);
            }
            retorno.Close();
            return funcionarios;
        }



        public ModelFuncionario ListarId(int Id)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select * from Funcionario where id_func = {0};", Id);
                var retorno = db.Retornar(strQuery);
                return ListaDeFuncionarios(retorno).FirstOrDefault();
            }
        }



        public void UpdateFuncionario(ModelFuncionario funcionario)
        {
            var strQuery = "";
            strQuery += "update Funcionario set ";
            strQuery += string.Format("nome_func = '{0}', email_func = '{1}', CPF_func = '{2}', cep_func = '{3}', num_func = '{4}', logradouro_func = '{5}', nasc_func = str_to_date('{6}', '%d/%m/%Y %T'), tel_func = '{7}', senha_func = '{8}' where id_func = {8};", funcionario.nome_func, funcionario.email_func, funcionario.CPF_func, funcionario.num_func, funcionario.nasc_func, funcionario.tel_func, funcionario.senha_func, funcionario.id_func);



            using (db = new Banco())
            {
                db.Executar(strQuery);
            }
        }



        public void DeleteFuncionario(ModelFuncionario funcionario)
        {
            var strQuery = "";
            strQuery += "delete from Funcionario ;";
            strQuery += string.Format("where id_func = {0};", funcionario.id_func);



            using (db = new Banco())
            {
                db.Executar(strQuery);
            }
        }



        public void Save(ModelFuncionario funcionario)
        {
            if (funcionario.id_func > 0)
            {
                UpdateFuncionario(funcionario);
            }
            else
            {
                InsertFuncionario(funcionario);
            }
        }
    }
}