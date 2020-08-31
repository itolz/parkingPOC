using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Interfaces.Repository
{
    public interface IOcorrenciaRepository
    {
        public void Incluir(Ocorrencia ocorrencia);

        public Task<IEnumerable<EstabelecimentoReport>> Listar();
    }
}
