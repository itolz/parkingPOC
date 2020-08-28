using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Services
{
    public class EstabelecimentoService : IEstabelecimentoService
    {
        private readonly IGenericRepository<Estabelecimento> _estabelecimentoRepository;
        public EstabelecimentoService(IGenericRepository<Estabelecimento> estabelecimentoRepository)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }
        public Task<Estabelecimento> Atualizar(object id, Estabelecimento Estabelecimento)
        {
            return _estabelecimentoRepository.Atualizar(id, Estabelecimento);
        }

        public Task<Estabelecimento> Delete(Estabelecimento estabelecimento)
        {
            return _estabelecimentoRepository.Delete(estabelecimento);
        }

        public Task<Estabelecimento> Incluir(Estabelecimento estabelecimento)
        {
            return _estabelecimentoRepository.Incluir(estabelecimento);
        }

        public Task<IEnumerable<Estabelecimento>> Listar()
        {
            return _estabelecimentoRepository.Listar();
        }

        public Task<Estabelecimento> Selecionar(object id)
        {
            return _estabelecimentoRepository.Selecionar(id);
        }
    }
}
