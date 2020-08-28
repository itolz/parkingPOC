using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Interfaces
{
    public interface IEstabelecimentoRepository
    {
        Task<IEnumerable<Estabelecimento>> Listar();

        Task<Estabelecimento> Selecionar(Guid id);

        Task Atualizar(Guid id, Estabelecimento estabelecimento);

        Task<Estabelecimento> Incluir(Estabelecimento estabelecimento);

        Task<Estabelecimento> Delete(Estabelecimento estabelecimento);

        public bool EstabelecimentoExists(Guid id);

    }
}
