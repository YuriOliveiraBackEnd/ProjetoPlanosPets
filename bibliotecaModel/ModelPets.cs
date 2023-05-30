using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace bibliotecaModel
{
    public class ModelPets
    {
        [DisplayName("Código pet")]
        public int id_pet { get; set; }
        [DisplayName("Nome pet")]
        [Required(ErrorMessage = "insira o nome do seu pet")]
        public string nome_pet { get; set; }
        [DisplayName("foto pet")]
        public string ft_pet { get; set; }
        [DisplayName("Data de nascimento")]
        [Required(ErrorMessage = "insira a data de nascimento do seu pet")]
        public DateTime nasc_pet { get; set; }
        [DisplayName("RGA")]
        [Required(ErrorMessage = "insira o RGA do pet")]
        public string RGA { get; set; }
        [DisplayName("Código cliente")]
        [Required(ErrorMessage = "insira o código do cliente")]
        public int id_cli { get; set; }
        [DisplayName("Código raça")]
        public int id_raca { get; set; }
    }
}
