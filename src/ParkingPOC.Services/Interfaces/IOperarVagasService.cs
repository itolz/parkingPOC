﻿using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Interfaces
{
    public interface IOperarVagasService
    {
        public OcorrenciaResultado Executar(Ocorrencia ocorrencia); 
    }
}
