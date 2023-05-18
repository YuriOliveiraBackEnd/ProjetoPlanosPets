using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

<<<<<<< HEAD
=======


>>>>>>> df03e5be2f99826adbabb601c2f089a01fb38c06
namespace PlanosPets.ViewModels
{
    public class LoginViewModel
    {
        public string UrlRetorno { get; set; }

<<<<<<< HEAD
=======


>>>>>>> df03e5be2f99826adbabb601c2f089a01fb38c06
        [Required(ErrorMessage = "Informe o email")]
        [MaxLength(50, ErrorMessage = "o email deve ter até 50 caracteres")]
        public string Email { get; set; }


<<<<<<< HEAD
        [Display(Name = "senha")]
        [Required(ErrorMessage = "Informe a senha")]
=======


        [Display(Name = "Senha")]
        [Required(ErrorMessage = "Informe a semha")]
>>>>>>> df03e5be2f99826adbabb601c2f089a01fb38c06
        public string senha { get; set; }
    }
}