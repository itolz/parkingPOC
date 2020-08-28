using Microsoft.EntityFrameworkCore;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingPOC.Infra
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ParkingPOCAPIContext _context;
        private DbSet<T> table = null;

        public GenericRepository(ParkingPOCAPIContext context)
        {
            _context = context;
            table = _context.Set<T>();
        }

        public async Task<T> Atualizar(object id, T entidade)
        {
            _context.Entry(entidade).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateConcurrencyException)
            {
                if (!EntidadeExists(id))
                {
                    return null;
                }
                else
                    throw;
            }

            return entidade;
        }

        public async Task<T> Delete(T entidade)
        {
            table.Remove(entidade);
            await _context.SaveChangesAsync();
            return entidade;
        }

        public bool EntidadeExists(object id)
        {
            T existente = table.Find(id);

            return (existente != null); 

        }

        public async Task<T> Incluir(T entidade)
        {
            table.Add(entidade);
            await _context.SaveChangesAsync();

            return entidade;
        }

        public async Task<IEnumerable<T>> Listar()
        {
            return await table.ToListAsync();
        }

        public async Task<T> Selecionar(object id)
        {
            return await table.FindAsync(id);
        }
    }
}
