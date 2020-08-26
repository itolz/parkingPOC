using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingPOC.Services.Models
{
    public class Ocorrencia
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Guid do estabelecimento deve ser informado!")]
        public Guid EstabelecimentoId { get; set; }
        
        [Required(ErrorMessage = "Guid do veiculo deve ser informado!")]
        public Guid VeiculoId { get; set; }

        [Required(ErrorMessage = "TipoMovimento deve ser informado! (0:entrada; 1: saida;)")]
        public TipoMovimento Movimento { get; set; }

    }
}
