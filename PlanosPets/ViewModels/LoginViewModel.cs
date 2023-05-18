using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace PlanosPets.ViewModels
{
    public class LoginViewModel
    {
        public string UrlRetorno { get; set; }

        [Required(ErrorMessage = "Informe o email")]
        [MaxLength(50, ErrorMessage = "o email deve ter até 50 caracteres")]
        public string Email { get; set; }


        [Display(Name = "senha")]
        [Required(ErrorMessage = "Informe a senha")]
        public string senha { get; set; }
    }
}