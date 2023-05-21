﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;
using System.Web.Mvc;

namespace bibliotecaModel
{
    public class ModelFuncionario
    {
        [DisplayName("Id do funcionário")]
        public int id_func { get; set; }

        [DisplayName("Nome do funcionário")]
        [MaxLength(80, ErrorMessage = "O nome deve conter no maximo 80 caracteres")]
        [Required(ErrorMessage = "insira seu nome")]
        public string nome_func { get; set; }


        [DisplayName("Email do funcionário")]
        [MaxLength(50, ErrorMessage = "o Email deve conter no maximo 15 caracteres")]
        [RegularExpression(@"^[a-zA-Z]+(([\'\,\.\-][a-zA-Z ])?[a-zA-Z]*)*\s+<(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})>$|^(\w[-._\w]*\w@\w[-._\w]*\w\.\w{2,3})$", ErrorMessage = "Digite um Email válido")]
        [Required(ErrorMessage = "insira seu email")]
        [Remote("SelectEmailFunc", "Funcionario", ErrorMessage = "Email já foi casdastrado")]
        public string email_func { get; set; }


        [DisplayName("CPF do funcionário")]
        [MaxLength(11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "O CPF deve conter 11 caracters")]
        [RegularExpression(@"^[0-9]+${11,11}", ErrorMessage = "Somente números")]
        [Required(ErrorMessage = "insira seu CPF")]
        public string CPF_func { get; set; }


        [RegularExpression(@"^[0-9]+${11,11}", ErrorMessage = "Somente números")]
        [DisplayName("Cep do funcionário")]
        [MaxLength(8, ErrorMessage = "O CEP deve conter 8 caracters")]
        [MinLength(8, ErrorMessage = "O CEP deve conter 8 caracters")]
        [Required(ErrorMessage = "insira seu cep")]
        public string cep_func { get; set; }


        [DisplayName("Número da casa")]
        [Required(ErrorMessage = "insira o número da casa")]
        [RegularExpression(@"^[0-9]+${11,11}", ErrorMessage = "Somente números")]
        public string num_func { get; set; }


        [DisplayName("Logradouro do funcionário")]
        [Required(ErrorMessage = "insira seu logradouro")]
        public string logradouro_func { get; set; }

        [DisplayName("Data de nascimento do funcionário")]
        [Required(ErrorMessage = "insira sua data de nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime nasc_func { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Senha do funcionário")]
        [Required(ErrorMessage = "insira sua senha")]
        [SenhaBrasil(CaracterEspecialRequerido = true, SenhaForteRequerida = true, SenhaTamanhoMinimo = 5)]
        public string senha_func { get; set; }

        [DataType(DataType.Password)]
        [DisplayName("Confirmar senha")]
        [Required(ErrorMessage = "Confirme sua senha")]
        [Compare(nameof(senha_func), ErrorMessage = "Senhas digitadas não conferem.")]
        public string confirmar_senha { get; set; }

        [DisplayName("Telefone do funcionário")]
        [MaxLength(11, ErrorMessage = "O telefone deve conter 11 caracteres")]
        [MinLength(11, ErrorMessage = "O telefone deve conter 11 caracteres")]
        [RegularExpression(@"^[0-9]+${11,11}", ErrorMessage = "Somente números")]
        [Required(ErrorMessage = "insira seu telefone")]
        public string tel_func { get; set; }





    }
}
