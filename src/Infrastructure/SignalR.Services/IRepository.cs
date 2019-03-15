using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalR.Services
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        bool Add(T entity);
        bool Delete(int id);
        bool Update(T entity);
        Task<IEnumerable<T>> GetByFilter(Entities.QueryParameters<T> queryParameters);
        int SaveChanges();
    }
}