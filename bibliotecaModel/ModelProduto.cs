using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelProduto
    {
        [DisplayName("Id do produto")]
        public int id_prod { get; set; }

        [DisplayName("Nome do produto")]
        [Required(ErrorMessage = "insira o nome do produto")]
        public string nome_prod { get; set; }

        [DisplayName("Valor unitário")]
        [Required(ErrorMessage = "insira o valor unitário")]
        public double valor_unitario { get; set; }

        [DisplayName("Quantidade")]
        [Required(ErrorMessage = "insira a quantidade")]
        public int quant { get; set; }

        [DisplayName("Descrição do produto")]
        [Required(ErrorMessage = "insira uma descrição")]
        public string desc_prod { get; set; }

        [DisplayName("Foto do produto")]
        [Required(ErrorMessage = "insira uma imagem do produto")]
        public string ft_prod { get; set; }

        [DisplayName("Id da categoria")]
        [Required(ErrorMessage = "insira o id da categoria")]
        public int id_categoria { get; set; }

        [DisplayName("Id do funcionário")]
        [Required(ErrorMessage = "insira o id do funcionário")]
        public int id_func { get; set; }

        [DisplayName("Id do fornecedor")]
        [Required(ErrorMessage = "insira o id do fornecedor")]
        public int id_forn { get; set; }
    }
}
