using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingPOC.Services.Models
{
    public class EstabelecimentoReport
    {
        public string Estabelecimento { get; set; }

        [Display(Name = "Por Hora")]
        public string Hora { get; set; }
        
        [Display(Name = "Quantidade de Entrada de Veículos")]
        public int QuantidadeEntradaVeiculos { get; set; }
        
        [Display(Name = "Quantidade de Saída de Veículos")]
        public int QuantidadeSaídaVeiculos { get; set; }


    }
}
