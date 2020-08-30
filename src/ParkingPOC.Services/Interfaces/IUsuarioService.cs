using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Interfaces
{
    public interface IUsuarioService
    {
      
        public Task<Usuario> Incluir(Usuario estabelecimento);

        public Task<IEnumerable<Usuario>> Listar();

        public Task<Usuario> Selecionar(object id);
    }
}
