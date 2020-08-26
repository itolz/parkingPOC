using System;

namespace ParkingPOC.Models
{
    public class Veiculo
    {
        public Veiculo()
        {

        }

        public string Marca { get; set; }

        public string Modelo { get; set; }

        public string Cor { get; set; }

        public string Placa { get; set; }

        public VeiculoTipo MyProperty { get; set; }

    }

}

