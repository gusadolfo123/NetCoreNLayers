using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SignalR.Services;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SignalR.Entities;

namespace SignalR.DAL
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly DbContext _Context;

        public Repository(DbContext context)
        {
            this._Context = context;
        }

        public Repository() : this(new SignalRContext())
        {
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _Context.Set<T>().ToListAsync();
        }
        public async Task<T> GetById(int id)
        {
            return await _Context.Set<T>().FindAsync(id);
        }
        public bool Add(T entity)
        {
            var result = _Context.Add(entity);
            return result.State == EntityState.Added;
        }
        public bool Delete(int id)
        {
            var product = _Context.Set<T>().Find(id);
            var result = _Context.Set<T>().Remove(product);
            return result.State == EntityState.Deleted;
        }
        public bool Update(T entity)
        {
            var result = _Context.Set<T>().Update(entity);

            return result.State == EntityState.Modified;
        }
        public async Task<IEnumerable<T>> GetByFilter(QueryParameters<T> queryParameters)
        {
            var query = _Context.Set<T>().AsQueryable();
            if (queryParameters.Includes != null)
            {
                foreach (var include in queryParameters.Includes)
                {
                    query = query.Include(include);
                }
            }

            var list = await query.Where(queryParameters.Where).ToListAsync();
            return list;
        }

        public int SaveChanges()
        {
            var result = 0;
            result = _Context.SaveChanges();
            return result;
        }
    }
}