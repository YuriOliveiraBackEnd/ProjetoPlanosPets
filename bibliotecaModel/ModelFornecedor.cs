using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelFornecedor
    {
        [DisplayName("Id do fornecedor")]
        public int id_forn { get; set; }

        [DisplayName("Nome do fornecedor")]
        [Required(ErrorMessage = "insira seu nome")]
        public string nome_forn { get; set; }

        [DisplayName("Email do fornecedor")]
        [Required(ErrorMessage = "insira seu email")]
        public string email_forn { get; set; }

        [DisplayName("CNPJ do fornecedor")]
        [Required(ErrorMessage = "insira seu CNPJ")]
        public string CNPJ_forn { get; set; }

        [DisplayName("Cep do fornecedor")]
        [Required(ErrorMessage = "insira seu cep")]
        public string cep_forn { get; set; }

        [DisplayName("Número do fornecedor")]
        [Required(ErrorMessage = "insira seu número")]
        public int num_forn { get; set; }

        [DisplayName("Logradouro do fornecedor")]
        [Required(ErrorMessage = "insira seu logradouro")]
        public string logradouro_forn { get; set; }

        [DisplayName("Telefone do fornecedor")]
        [Required(ErrorMessage = "insira seu telefone")]
        public string tel_forn { get; set; }

        [DisplayName("Id do produto")]
        [Required(ErrorMessage = "insira seu id do produto")]
        public int id_prod { get; set; }
    }
}
