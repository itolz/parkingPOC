using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace ParkingPOC.Infra
{
   
        public class ParkingPOCAPIContext : Microsoft.EntityFrameworkCore.DbContext
    {
            public ParkingPOCAPIContext(DbContextOptions<ParkingPOCAPIContext> options)
                : base(options)
            {
            }

            public Microsoft.EntityFrameworkCore.DbSet<ParkingPOC.Services.Models.Estabelecimento> Estabelecimento { get; set; }

            public Microsoft.EntityFrameworkCore.DbSet<ParkingPOC.Services.Models.Veiculo> Veiculo { get; set; }
        }
    

}
