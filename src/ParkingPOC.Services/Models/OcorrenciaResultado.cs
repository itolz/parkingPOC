using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPOC.Services.Models
{
    public class OcorrenciaResultado
    {
        public Guid EstabelecimentoId { get; set; }

        public OcorrenciaStatus Status { get; set; }
    }
}
