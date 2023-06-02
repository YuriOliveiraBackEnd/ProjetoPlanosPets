﻿using System;
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
            comand.CommandText = "call SelectEmailDoCliente(@email_cli);";
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
            comand.CommandText = "call SelectCPFDoCliente(@CPF_cli);";
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
                var strQuery = string.Format("select * from Cliente where id_cli = '{0}';", Id);
                var retorno = db.Retornar(strQuery);
                return ListaDeClientes(retorno).FirstOrDefault();
            }
        }

        public ModelCliente ListarEmail(string Login)
        {
            using (db = new Banco())
            {
                var strQuery = string.Format("select c.nome_cli as cliente, c.tel_cli as telefone, c.email_cli as email, c.CPF_cli as CPF, c.cep_cli as CEP, c.num_cli as numero, c.logradouro_cli as rua, c.nasc_cli as nascimento, c.senha_cli as senha,  p.nome_pet as pet, p.nasc_pet as nascimento_pet, p.RGA as RGA, r.nome_raca as raça, r.tipo_animal as tipo from db4luck.Cliente c, db4luck.Pets p, db4luck.Raca r where c.id_cli = p.id_cli and r.id_raca = p.id_raca  and email_cli = '{0}'; ", Login);
               var retorno = db.Retornar(strQuery);
                return ListaDeClientes(retorno).FirstOrDefault();
            }
        }



        public void UpdateCliente(ModelCliente cliente)
        {
            var strQuery = "";
            strQuery += "Update cliente set ";
            strQuery += string.Format("nome_cli = '{0}',", cliente.nome_cli);
            strQuery += string.Format("email_cli= '{0}', ", cliente.email_cli);
            strQuery += string.Format("CPF_cli = '{0}',", cliente.CPF_cli);
            strQuery += string.Format("tel_cli = '{0}',", cliente.tel_cli);
            strQuery += string.Format("num_cli = '{0}',", cliente.num_cli);
            strQuery += string.Format("cep_cli = '{0}',", cliente.cep_cli);
            strQuery += string.Format("logradouro_cli = '{0}',", cliente.logradouro_cli);
            strQuery += string.Format("nasc_cli = STR_TO_DATE('{0}', '%d/%m/%Y %H :%i: %s')", cliente.nasc_cli);
          
            strQuery += string.Format("where id_cli = '{0}'", cliente.id_cli);



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