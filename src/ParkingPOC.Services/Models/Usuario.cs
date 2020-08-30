using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingPOC.Services.Models
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Nome deve ser informado")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O nome deve conter entre 4 e 50 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O login deve ser informado")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "O login  deve conter entre 8 e 50 caracteres")]
        public string Login { get; set; }
        [Required(ErrorMessage = "A senha deve ser informado")]
        [StringLength(255, MinimumLength = 8, ErrorMessage = "A senha  deve conter entre 8 e 20 caracteres")]
        public string Password { get; set; }
    }
}
