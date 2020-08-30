using Microsoft.EntityFrameworkCore;
using ParkingPOC.Services.Interfaces.Repository;
using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Infra
{
    public class OcorrenciaRepository : IOcorrenciaRepository
    {
        private readonly ParkingPOCAPIContext _context;
      

        public OcorrenciaRepository(ParkingPOCAPIContext context)
        {
            _context = context;
        }

        public async void Incluir(Ocorrencia ocorrencia)
        {
            _context.Ocorrencia.Add(ocorrencia);
            await _context.SaveChangesAsync(); 
        }

        public  Task<List<EstabelecimentoReport>> Listar()
        {
            throw new NotImplementedException(); 
        }
    }
}
