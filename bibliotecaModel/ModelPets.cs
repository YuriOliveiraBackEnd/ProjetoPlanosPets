using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelPets
    {
        public int id_pet { get; set; }
        public string nome_pet { get; set; }
        public string ft_pet { get; set; }        
        public DateTime nasc_pet { get; set; }
        public string RGA { get; set; }
        public int id_cli { get; set; }
        public int id_raca { get; set; }
    }
}
