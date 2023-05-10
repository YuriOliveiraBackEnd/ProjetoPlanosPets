using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelVenda
    {
        public int id_venda {  get; set; }
        public DateTime data_venda { get; set; }
        public int quant_venda { get; set; }
        public int id_compra { get; set; }
        public int id_prod { get; set; }
    }
}
