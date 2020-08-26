using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingPOC.Services.Models
{
    public class Veiculo
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "A marca do veículo deve ser informada!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "A marca deve conter entre 4 e 50 caracteres")] 
        public string Marca { get; set; }

        [Required(ErrorMessage = "O modelo do veículo deve ser informada!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O modelo deve conter entre 4 e 50 caracteres")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "A cor do veículo deve ser informada!")]
        [StringLength(40, MinimumLength = 4, ErrorMessage = "A cor deve conter entre 4 e 50 caracteres")]
        public string Cor { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]{3}[0-9][A-Za-z0-9][0-9]{2}$", ErrorMessage = "Placa do veículo Invalida!")]
        public string Placa { get; set; }

        [Required(ErrorMessage = "O tipo do  veículo deve ser informada! (0: moto; 1: carro)")]
        public VeiculoTipo Tipo { get; set; }
    }
}
