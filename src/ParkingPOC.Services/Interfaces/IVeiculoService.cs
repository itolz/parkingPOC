using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Interfaces
{
    public interface IVeiculoService
    {
        public Task<Veiculo> Atualizar(object id, Veiculo Estabelecimento);

        public Task<Veiculo> Delete(Veiculo estabelecimento);

        public Task<Veiculo> Incluir(Veiculo estabelecimento);

        public Task<IEnumerable<Veiculo>> Listar();

        public Task<Veiculo> Selecionar(object id);
    }
}
