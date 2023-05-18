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
        [DisplayName("Id do funcionário")]
        public int id_func { get; set; }

        [DisplayName("Nome do funcionário")]
        [Required(ErrorMessage = "insira seu nome")]
        public string nome_func { get; set; }


        [DisplayName("Email do funcionário")]
        [Required(ErrorMessage = "insira seu email")]
        public string email_func { get; set; }


        [DisplayName("CPF do funcionário")]
        [Required(ErrorMessage = "insira seu CPF")]
        public string CPF_func { get; set; }


        [DisplayName("Cep do funcionário")]
        [Required(ErrorMessage = "insira seu cep")]
        public string cep_func { get; set; }


        [DisplayName("Número do funcionário")]
        [Required(ErrorMessage = "insira seu número")]
        public string num_func { get; set; }


        [DisplayName("Logradouro do funcionário")]
        [Required(ErrorMessage = "insira seu logradouro")]
        public string logradouro_func { get; set; }

        [DisplayName("Data de nascimento do funcionário")]
        [Required(ErrorMessage = "insira sua data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime nasc_func { get; set; }

        [DisplayName("Senha do funcionário")]
        [Required(ErrorMessage = "insira sua senha")]
        public string senha_func { get; set; }

        [DisplayName("Telefone do funcionário")]
        [Required(ErrorMessage = "insira seu telefone")]
        public string tel_func { get; set; }
    }
}
