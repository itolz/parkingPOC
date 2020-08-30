using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingPOC.Services.Models
{
    public class Login
    {

        [Required(ErrorMessage = "O login deve ser informado")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "O login  deve conter entre 8 e 255 caracteres")]
        public string Usuario { get; set; }
        
        [Required(ErrorMessage = "o password deve ser informado")]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "O password  deve conter entre 8 e 20 caracteres")]
        public string Password { get; set; }


    }
}
