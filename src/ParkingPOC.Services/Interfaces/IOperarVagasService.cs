using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Interfaces
{
    public interface IOperarVagasService
    {
        public Task<OcorrenciaResultado> Executar(Ocorrencia ocorrencia); 
    }
}
