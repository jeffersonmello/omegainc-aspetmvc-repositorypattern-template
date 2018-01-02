using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmegaInc.MultiPorpose.WEB.ViewModels.Example
{
    public class UserIndexViewModel
    {
        [Display(Name = "Code")]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }
    }
}