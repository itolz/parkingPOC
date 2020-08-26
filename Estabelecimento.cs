namespace ParkingPOC.Models
{

    public class Estabelecimento
    {
        public Estabelecimento()
        {

        }
        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Endereco { get; set; }

        public string Telefone { get; set; }

        public int PosicoesVagasMotos { get; set; }

        public int PosicoesVagasCarros { get; set; }
    }

}