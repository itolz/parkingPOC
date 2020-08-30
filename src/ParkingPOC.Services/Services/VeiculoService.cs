using ParkingPOC.Services.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Models
{
    public class VeiculoService : IVeiculoService
    {
        private readonly IGenericRepository<Veiculo> _veiculoRepository;

        public VeiculoService(IGenericRepository<Veiculo> veiculoRepository)
        {
            _veiculoRepository = veiculoRepository; 
        }
        public Task<Veiculo> Atualizar(object id, Veiculo veiculo)
        {
            return _veiculoRepository.Atualizar(id, veiculo);
        }

        public Task<Veiculo> Delete(Veiculo veiculo)
        {
            return _veiculoRepository.Delete(veiculo);
        }

        public Task<Veiculo> Incluir(Veiculo veiculo)
        {
            return _veiculoRepository.Incluir(veiculo);
        }

        public Task<IEnumerable<Veiculo>> Listar()
        {
            return _veiculoRepository.Listar();
        }

        public Task<Veiculo> Selecionar(object id)
        {
            return _veiculoRepository.Selecionar(id);
        }
    }
}
