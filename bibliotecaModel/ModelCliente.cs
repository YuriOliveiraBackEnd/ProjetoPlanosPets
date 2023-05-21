using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace bibliotecaModel
{
    public class ModelCliente
    {
        [DisplayName("Id do Cliente")]
        public int id_cli { get; set; }

        [DisplayName("Nome do Cliente")]
        [MaxLength(80, ErrorMessage = "O nome deve conter no maximo 80 caracteres")]
        [Required(ErrorMessage = "insira seu nome")]
        public string nome_cli { get; set; }


        [DisplayName("Email do Cliente")]
        [MaxLength(50, ErrorMessage = "o Email deve conter no maximo 15 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Digite um Email válido")]
        [Required(ErrorMessage = "insira seu email")]
        [Remote("SelectEmailCli", "Autenticação", ErrorMessage = "Email já foi casdastrado")]
        public string email_cli { get; set; }


        [DisplayName("CPF do Cliente")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "O CPF deve conter 11 caracters")]
        [RegularExpression(@"^[0-9]+${11,11}", ErrorMessage = "Somente números")]
        [Required(ErrorMessage = "insira seu CPF")]
        public string CPF_cli { get; set; }


        [RegularExpression(@"^[0-9]+${11,11}", ErrorMessage = "Somente números")]
        [DisplayName("Cep do Cliente")]
        [MaxLength(8, ErrorMessage = "O cep deve conter 8 caracteres")]
        [MinLength(8, ErrorMessage = "O cep deve conter 8 caracters")]
        [Required(ErrorMessage = "insira seu cep")]
        public string cep_cli { get; set; }


        [DisplayName("Número da casa")]
        [Required(ErrorMessage = "insira o número da casa")]
        [RegularExpression(@"^[0-9]+${11,11}", ErrorMessage = "Somente números")]
        public string num_cli { get; set; }


        [DisplayName("Logradouro do Cliente")]
        [Required(ErrorMessage = "insira seu logradouro")]
        public string logradouro_cli { get; set; }

        [DisplayName("Data de nascimento do Cliente")]
        [Required(ErrorMessage = "insira sua data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime nasc_cli { get; set; }

        [DisplayName("Senha do Cliente")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "insira sua senha")]
        [SenhaBrasil(CaracterEspecialRequerido = true, SenhaForteRequerida = true, SenhaTamanhoMinimo = 5)]
        public string senha_cli { get; set; }


        [DisplayName("Confirmar senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirme sua senha")]
        [Compare(nameof(senha_cli), ErrorMessage = "Senhas digitadas não conferem.")]
        public string confirmar_senha { get; set; }

        [DisplayName("Telefone do Cliente")]
        [MaxLength(11, ErrorMessage = "O telefone deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "O telefone deve conter 11 caracteres")]
        [RegularExpression(@"^[0-9]+${11,11}", ErrorMessage = "Somente números")]
        [Required(ErrorMessage = "insira seu telefone")]
        public string tel_cli { get; set; }
    }
}
