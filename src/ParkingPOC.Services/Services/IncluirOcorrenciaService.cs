using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Interfaces.Repository;
using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPOC.Services.Services
{
    public class IncluirOcorrenciaService : IIncluirOcorrenciaService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;
        public IncluirOcorrenciaService(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository; 
        }
        public void Executar(Ocorrencia ocorrencia)
        {
            _ocorrenciaRepository.Incluir(ocorrencia);
        }
    }
}
