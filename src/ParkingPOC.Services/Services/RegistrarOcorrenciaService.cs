using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPOC.Services.Services
{
    public class RegistrarOcorrenciaService : IRegistrarOcorrenciaService
    {
        private readonly IGenericRepository<Estabelecimento> _estabelecimentoRepository;
        public RegistrarOcorrenciaService(IGenericRepository<Estabelecimento> estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }
        public OcorrenciaStatus Executar(Ocorrencia ocorrencia)
        {
            throw new NotImplementedException();
        }
    }
}
