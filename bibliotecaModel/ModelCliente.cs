using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelCliente
    {
        public int id_cli { get; set; }
        public string nome_cli { get; set; }
        public string email_cli { get; set; }
        public string CPF_cli { get; set; }
        public string cep_cli { get; set; }
        public string num_cli { get; set; }
        public string logradouro_cli { get; set; }
        public DateTime nasc_cli { get; set; }
        public string senha_cli { get; set; }
        public string tel_cli { get; set; }

    }
}
