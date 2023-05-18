using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bibliotecaModel
{
    public class ModelPets
    {
        [DisplayName("Id do pet")]
        public int id_pet { get; set; }

        [DisplayName("Nome do pet")]
        [Required(ErrorMessage = "insira o nome do pet")]
        public string nome_pet { get; set; }

        [DisplayName("Foto do pet")]
        [Required(ErrorMessage = "insira a foto do pet")]
        public string ft_pet { get; set; }

        [DisplayName("Data de nascimento do pet")]
        [Required(ErrorMessage = "insira a data de nascimento do pet")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime nasc_pet { get; set; }

        [DisplayName("RGA do pet")]
        [Required(ErrorMessage = "insira o RGA do pet")]
        public string RGA { get; set; }

        [DisplayName("Id do cliente")]
        [Required(ErrorMessage = "insira o id do cliente")]
        public int id_cli { get; set; }

        [DisplayName("Id da raça")]
        [Required(ErrorMessage = "insira o id da raça")]
        public int id_raca { get; set; }
    }
}
