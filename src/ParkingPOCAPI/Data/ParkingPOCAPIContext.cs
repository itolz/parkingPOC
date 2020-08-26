using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ParkingPOC.Services.Models;

namespace ParkingPOCAPI.Data
{
    public class ParkingPOCAPIContext : DbContext
    {
        public ParkingPOCAPIContext (DbContextOptions<ParkingPOCAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingPOC.Services.Models.Estabelecimento> Estabelecimento { get; set; }

        public DbSet<ParkingPOC.Services.Models.Veiculo> Veiculo { get; set; }
    }
}
