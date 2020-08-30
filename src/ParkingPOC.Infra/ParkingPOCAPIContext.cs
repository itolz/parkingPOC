using Microsoft.EntityFrameworkCore;

namespace ParkingPOC.Infra
{

    public class ParkingPOCAPIContext : DbContext
    {
        public ParkingPOCAPIContext(DbContextOptions<ParkingPOCAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ParkingPOC.Services.Models.Estabelecimento> Estabelecimento { get; set; }
        public DbSet<ParkingPOC.Services.Models.Veiculo> Veiculo { get; set; }
        public DbSet<ParkingPOC.Services.Models.Ocorrencia> Ocorrencia { get; set; }


    }


}
