using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelFornecedor
    {
        public int id_forn { get; set; }
        public string nome_forn { get; set; }
        public string email_forn { get; set; }
        public string CNPJ_forn { get; set; }
        public string cep_forn { get; set; }
        public int num_forn { get; set; }
        public string logradouro_forn { get; set; }
        public string tel_forn { get; set; }
        public int id_prod { get; set; }
    }
}
