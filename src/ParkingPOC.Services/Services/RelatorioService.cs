using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Interfaces.Repository;
using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPOC.Services.Services
{
    public class RelatorioService : IRelatorioService
    {
        private readonly IOcorrenciaRepository _ocorrenciaRepository;

        public RelatorioService(IOcorrenciaRepository ocorrenciaRepository)
        {
            _ocorrenciaRepository = ocorrenciaRepository; 
        }
        public IEnumerable<EstabelecimentoReport> Listar()
        {
           return _ocorrenciaRepository.Listar().Result; 
        }
    }
}
