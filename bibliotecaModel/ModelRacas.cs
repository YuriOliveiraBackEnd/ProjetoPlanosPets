using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelRacas
    {
        [DisplayName("Id da raça")]
        public int id_raca { get; set; }

        [DisplayName("Nome da raça")]
        [Required(ErrorMessage = "insira o nome da raça")]
        public string nome_raca { get; set; }

        [DisplayName("Foto da raça")]
        [Required(ErrorMessage = "insira uma imagem da raça")]
        public string ft_raca { get; set; }

        [DisplayName("Id do funcionário")]
        public int id_func { get; set; }
    }
}
