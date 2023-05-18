using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelVenda
    {
        [DisplayName("Id da venda")]
        public int id_venda {  get; set; }

        [DisplayName("Data da venda")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime data_venda { get; set; }

        [DisplayName("Quantidade da venda")]
        public int quant_venda { get; set; }

        [DisplayName("Id da compra")]
        public int id_compra { get; set; }

        [DisplayName("Id do produto")]
        public int id_prod { get; set; }
    }
}
