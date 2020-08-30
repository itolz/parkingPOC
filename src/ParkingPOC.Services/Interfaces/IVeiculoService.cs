using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Interfaces
{
    public interface IVeiculoService
    {
        public Task<Veiculo> Atualizar(object id, Veiculo veiculo);

        public Task<Veiculo> Delete(Veiculo veiculo);

        public Task<Veiculo> Incluir(Veiculo veiculo);

        public Task<IEnumerable<Veiculo>> Listar();

        public Task<Veiculo> Selecionar(object id);
    }
}
