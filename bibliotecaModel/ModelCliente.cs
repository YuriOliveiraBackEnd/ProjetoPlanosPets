
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;


namespace bibliotecaModel
{
    public class ModelCliente
    {
        [DisplayName("Id do cliente")]
        public int id_cli { get; set; }



        [DisplayName("Nome do cliente")]
        [Required(ErrorMessage = "insira seu nome")]
        [MaxLength(80, ErrorMessage = "O nome deve conter no maximo 80 caracteres")]
        public string nome_cli { get; set; }




        [DisplayName("Email do cliente")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Digite um Email válido")]
        [Required(ErrorMessage = "insira seu email")]
        public string email_cli { get; set; }




        [DisplayName("CPF do cliente")]
        [Required(ErrorMessage = "insira seu cpf")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter no maximo 11 caracteres")]
        [MinLength(11, ErrorMessage = "O CPF deve conter no minimo 11 caracters")]
        public string CPF_cli { get; set; }




        [DisplayName("Cep do cliente")]
        [Required(ErrorMessage = "insira seu cep")]
        public string cep_cli { get; set; }




        [DisplayName("Número do cliente")]
        [Required(ErrorMessage = "insira seu número")]
        public string num_cli { get; set; }




        [DisplayName("Logradouro do cliente")]
        [Required(ErrorMessage = "insira seu logradouro")]
        public string logradouro_cli { get; set; }



        [DisplayName("Data de nascimento do cliente")]
        [Required(ErrorMessage = "insira sua data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode =  true, DataFormatString  = "{0:dd/MM/yyyy}")]
        public DateTime nasc_cli { get; set; }



        [DisplayName("Senha do cliente")]
        [Required(ErrorMessage = "insira sua senha")]
        public string senha_cli { get; set; }



        [Display(Name = "Número do Telefone")]
        [Required(ErrorMessage = "Digite o número de telefone")]
        [MaxLength(11, ErrorMessage = "O telefone deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "O telefone deve conter 11 caracteres")]
        [RegularExpression(@"^[0-9]+${11,11}", ErrorMessage = "Somente números")]
        public string tel_cli { get; set; }



    }
}