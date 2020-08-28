using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Interfaces
{
    public interface IEstabelecimentoService
    {

        public Task<Estabelecimento> Atualizar(object id, Estabelecimento Estabelecimento);

        public Task<Estabelecimento> Delete(Estabelecimento estabelecimento);

        public Task<Estabelecimento> Incluir(Estabelecimento estabelecimento);

        public Task<IEnumerable<Estabelecimento>> Listar();

        public Task<Estabelecimento> Selecionar(object id);
    }
}
