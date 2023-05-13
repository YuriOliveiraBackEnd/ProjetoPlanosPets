using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace bibliotecaModel
{
    public class ModelFuncionario
    {
        public int id_func { get; set; }
        public string nome_func { get; set; }
        public string email_func { get; set; }
        public string CPF_func { get; set; }
        public string cep_func { get; set; }
        public string num_func { get; set; }
        public string logradouro_func { get; set; }

       
        public DateTime nasc_func { get; set; }
        public string senha_func { get; set; }
        public string tel_func { get; set; }
    }
}
