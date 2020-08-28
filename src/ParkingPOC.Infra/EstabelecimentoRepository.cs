using ParkingPOC.Services.Interfaces;
using ParkingPOC.Services.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Linq;

namespace ParkingPOC.Infra
{
    public class EstabelecimentoRepository : IEstabelecimentoRepository
    {
        private readonly ParkingPOCAPIContext _context;
        public EstabelecimentoRepository(ParkingPOCAPIContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Guid id, Estabelecimento estabelecimento)
        {
            _context.Entry(estabelecimento).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstabelecimentoExists(id))
                {
                    //TODO refatorar verificacao para retorno NOTFOUND
                    //return Task.FromResult(0);

                }
                else
                {
                    throw;
                }
            }
        }

        public async Task<Estabelecimento> Delete(Estabelecimento estabelecimento)
        {
            _context.Estabelecimento.Remove(estabelecimento);
            await _context.SaveChangesAsync();

            return estabelecimento;
        }

        public async Task<Estabelecimento> Incluir(Estabelecimento estabelecimento)
        {
            _context.Estabelecimento.Add(estabelecimento);
            await _context.SaveChangesAsync();

            return estabelecimento;
        }

        public async Task<IEnumerable<Estabelecimento>> Listar()
        {
            return await _context.Estabelecimento.ToListAsync();
        }

        public async Task<Estabelecimento> Selecionar(Guid id)
        {
            return await _context.Estabelecimento.FindAsync(id);
        }

        public bool EstabelecimentoExists(Guid id)
        {
            return _context.Estabelecimento.Any(e => e.Id == id);
        }
    }
}
