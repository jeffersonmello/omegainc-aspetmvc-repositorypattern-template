using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmegaInc.MultiPorpose.WEB.ViewModels.Example
{
    public class UserViewModel
    {
        [Display(Name = "Code")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "E-mail is required!")]
        public string Email { get; set; }
    }
}