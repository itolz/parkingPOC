using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> Atualizar(object id, T entidade);

        public Task<T> Delete(T entidade);

        public Task<T> Incluir(T entidade);

        public Task<IEnumerable<T>> Listar();

        public Task<T> Selecionar(object id);

        public bool EntidadeExists(object id);
    }
}
