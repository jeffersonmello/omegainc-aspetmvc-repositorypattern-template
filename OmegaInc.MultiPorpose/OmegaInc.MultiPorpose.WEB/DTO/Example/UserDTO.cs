using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OmegaInc.MultiPorpose.WEB.DTO.Example
{
    public class UserDTO
    {
        public int Id { get; set; }
    
        [Required(ErrorMessage = "Name is required!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail is required!")]
        public string Email { get; set; }
    }
}