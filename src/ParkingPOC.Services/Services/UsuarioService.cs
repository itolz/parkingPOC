using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Services.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IGenericRepository<Usuario> _usuarioRepository;

        public UsuarioService(IGenericRepository<Usuario> usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public Task<Usuario> Incluir(Usuario usuario)
        {
            return _usuarioRepository.Incluir(usuario); 
        }

        public Task<IEnumerable<Usuario>> Listar()
        {
            return _usuarioRepository.Listar();
        }

        public Task<Usuario> Selecionar(object id)
        {
            return _usuarioRepository.Selecionar(id); 
        }
    }
}
