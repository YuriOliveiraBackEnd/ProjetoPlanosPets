using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelCompra
    {
        [DisplayName("Id da compra")]
        public int id_compra { get; set; }

        [DisplayName("Tipo de pagamento")]
        public string pagamento { get; set; }

        [DisplayName("Valor total")]
        public double valor_total { get; set; }

        [DisplayName("Id do cliente")]
        public int id_cli { get; set; }
    }
}
