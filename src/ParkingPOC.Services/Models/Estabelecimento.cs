using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkingPOC.Services.Models
{
    public class Estabelecimento
    {

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Nome do estabelecimento deve ser informado!")]
        [StringLength(50, MinimumLength = 4, ErrorMessage ="O nome deve conter entre 4 e 50 caracteres")]
        public string Nome { get; set; }


        [Required(ErrorMessage = "CNPJ deve ser informado!")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}\/\d{4}\-\d{2}$", ErrorMessage = "CNPJ Invalido!")]
        public string CNPJ { get; set; }

        [Required(ErrorMessage = "Endereço deve ser informado!")]
        [StringLength(100, MinimumLength = 20, ErrorMessage = "O endereço deve conter entre 20 e 100 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Telefone deve ser informado!")]
        [RegularExpression(@"(\(?\d{2}\)?\s)?(\d{4,5}\-\d{4})", ErrorMessage = "Telefone Invalido!")]
        public string Telefone { get; set; }


        [Required(ErrorMessage = "Capacidade de Vagas para motos do estabelecimento deve ser informado!")]
        public int PosicoesVagasMotos { get; set; }


        [Required(ErrorMessage = "Capacidade de Vagas para carros do estabelecimento deve ser informado!")]
        public int PosicoesVagasCarros { get; set; }
    }
}
