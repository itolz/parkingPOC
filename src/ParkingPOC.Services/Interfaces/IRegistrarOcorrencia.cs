using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPOC.Services.Interfaces
{
    public interface IRegistrarOcorrencia
    {
        public Estabelecimento Executar(Ocorrencia ocorrencia);
    }
}
