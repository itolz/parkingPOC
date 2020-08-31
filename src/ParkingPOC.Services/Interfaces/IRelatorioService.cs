using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingPOC.Services.Interfaces
{
    public interface IRelatorioService
    {
        IEnumerable<EstabelecimentoReport> Listar();
    }
}
