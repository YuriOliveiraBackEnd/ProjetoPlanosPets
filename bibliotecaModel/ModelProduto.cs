using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelProduto
    {
        public int id_prod { get; set; }
        public string nome_prod { get; set; }
        public string nome_compra { get; set; }
        public double valor_unitario { get; set; }
        public int quant { get; set; }
        public string desc_prod { get; set; }
        public string categoria { get; set; }
        public string ft_prod { get; set; }

        public int id_categoria { get; set; }
        public int id_func { get; set; }
    }
}
