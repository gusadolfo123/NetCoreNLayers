using SignalR.Entities;
using SignalR.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DAL
{
    /// <summary>
    /// Implementacion Servicio Repositorio para manejo de acceso a datos mediante ODP
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class RepositoryOracle<T> : IRepository<T> where T : class
    {
        public RepositoryOracle()
        {
        }

        public T Add(T entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetByFilter(QueryParameters<T> queryParameters)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public bool Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
