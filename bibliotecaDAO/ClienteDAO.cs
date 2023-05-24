using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using bibliotecaModel;
using bibliotecaBanco;



namespace bibliotecaDAO
{
    public class ClienteDAO
    {



        public Banco db;



        MySqlConnection conexao = new MySqlConnection(ConfigurationManager.ConnectionStrings["conexao"].ConnectionString);
        MySqlCommand comand = new MySqlCommand();



        public void InsertCliente(ModelCliente cliente)
        {
            conexao.Open();
            comand.CommandText = "call InsertCliente(@nome_cli, @tel_cli, @email_cli, @CPF_cli, @cep_cli, @num_cli, @logradouro_cli, @nasc_cli,@senha_cli);";
            comand.Parameters.Add("@nome_cli", MySqlDbType.VarChar).Value = cliente.nome_cli;
            comand.Parameters.Add("@tel_cli", MySqlDbType.VarChar).Value = cliente.tel_cli;
            comand.Parameters.Add("@email_cli", MySqlDbType.VarChar).Value = cliente.email_cli;
            comand.Parameters.Add("@CPF_cli", MySqlDbType.VarChar).Value = cliente.CPF_cli;
            comand.Parameters.Add("@cep_cli", MySqlDbType.VarChar).Value = cliente.cep_cli;
            comand.Parameters.Add("@num_cli", MySqlDbType.VarChar).Value = cliente.num_cli;
            comand.Parameters.Add("@logradouro_cli", MySqlDbType.VarChar).Value = cliente.logradouro_cli;
            comand.Parameters.Add("@nasc_cli", MySqlDbType.DateTime).Value = cliente.nasc_cli;
            comand.Parameters.Add("@senha_cli", MySqlDbType.VarChar).Value = cliente.senha_cli;

            comand.Connection = conexao;
            comand.ExecuteNonQuery();
            conexao.Close();
        }
        public string SelectEmailDoCliente(string vEmail)
        {
            conexao.Open();
            comand.CommandText = "call spSelectEmailCli(@email_cli);";
            comand.Parameters.Add("@email_cli", MySqlDbType.VarChar).Value = vEmail;
            comand.Connection = conexao;
            string Email = (string)comand.ExecuteScalar();
            conexao.Close();
            if (Email == null)



                Email = "";
            return Email;
        }


        public ModelCliente SelectCliente(string vEmail)
        {
            conexao.Open();
            comand.CommandText = "call SelectCliente(@email_cli);";
            comand.Parameters.Add("@email_cli", MySqlDbType.VarChar).Value = vEmail;



            comand.Connection = conexao;
            var readcli = comand.ExecuteReader();
            var tempcli = new ModelCliente();



            if (readcli.Read())
            {
                tempcli.id_cli = int.Parse(readcli["id_cli"].ToString());
                tempcli.nome_cli = readcli["nome_cli"].ToString();
                tempcli.num_cli = readcli["num_cli"].ToString();
                tempcli.cep_cli = readcli["cep_cli"].ToString();
                tempcli.tel_cli = readcli["tel_cli"].ToString();
                tempcli.email_cli = readcli["email_cli"].ToString();
                tempcli.nasc_cli = DateTime.Parse(readcli["nasc_cli"].ToString());
                tempcli.logradouro_cli = readcli["logradouro_cli"].ToString();
                tempcli.senha_cli = readcli["senha_cli"].ToString();
                tempcli.CPF_cli = readcli["CPF_cli"].ToString();

            }
            readcli.Close();
            conexao.Close();
            return tempcli;
        }
        public string SelectCPFDoCliente(string vCPF)
        {
            conexao.Open();
            comand.CommandText = "call spSelectCPFDoCli(@CPF_cli);";
            comand.Parameters.Add("@CPF_cli", MySqlDbType.String).Value = vCPF;
            comand.Connection = conexao;
            string CPF = (string)comand.ExecuteScalar();
            conexao.Close();
            if (CPF == null)



                CPF = "";
            return CPF;




        }
        public List<ModelCliente> Listar()
        {
            using (db = new Banco())
            {
                var strQuery = "Select * from Cliente;";
                var retorno = db.Retornar(strQuery);
                return ListaDeClientes(retorno);
            }



        }



        public List<ModelCliente> ListaDeClientes(MySqlDataReader retorno)
        {
            var clientes = new List<ModelCliente>();
            while (retorno.Read())
            {
                var TempCliente = new ModelCliente()
                {
                    id_cli = int.Parse(retorno["id_cli"].ToString()),
                    nome_cli = retorno["nome_cli"].ToString(),
                    email_cli = retorno["email_cli"].ToString(),
                    CPF_cli = retorno["CPF_cli"].ToString(),
                    senha_cli = retorno["senha_cli"].ToString(),
                    tel_cli = retorno["tel_cli"].ToString(),
                    num_cli = retorno["num_cli"].ToString(),
                    cep_cli = retorno["cep_cli"].ToString(),
                    logradouro_cli = retorno["logradouro_cli"].ToString(),
                    nasc_cli = DateTime.Parse(retorno["nasc_cli"].ToString())



                };



                clientes.Add(TempCliente);
            }
            retorno.Close();
            return clientes;
        }




        public ModelCliente ListarId(int Id)
        {
            using (db = new Banco())
            {
                var db = new Banco();
                var strQuery = string.Format("select * from Cliente where id_cli = {0};", Id);
                var retorno = db.Retornar(strQuery);
                return ListaDeClientes(retorno).FirstOrDefault();
            }
        }



        public void UpdateCliente(ModelCliente cliente)
        {
            var strQuery = "";
            strQuery += "update Cliente set ";
            strQuery += string.Format("nome_cli = '{0}', email_cli = '{1}', CPF_cli = '{2}', cep_cli = '{3}', num_cli = '{4}', logradouro_cli = '{5}', nasc_cli = str_to_date('{6}', '%d/%m/%Y %T'), tel_cli = '{7}', senha_cli = '{8}' where id_cli = {8};", cliente.nome_cli, cliente.email_cli, cliente.CPF_cli, cliente.num_cli, cliente.nasc_cli, cliente.tel_cli, cliente.senha_cli, cliente.id_cli);



            using (db = new Banco())
            {
                db.Executar(strQuery);
            }
        }



        public void Excluir(ModelCliente cliente)
        {

            using (db = new Banco())
            {
                var strQuery = string.Format("Delete from cliente where id_cli = {0}", cliente.id_cli);
                db.Executar(strQuery);
            }

        }



        public void Save(ModelCliente cliente)
        {
            if (cliente.id_cli > 0)
            {
                UpdateCliente(cliente);
            }
            else
            {
                InsertCliente(cliente);
            }
        }
    }
}