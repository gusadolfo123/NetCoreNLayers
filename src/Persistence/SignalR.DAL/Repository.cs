namespace SignalR.DAL
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using SignalR.Services;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using SignalR.Entities;

    /// <summary>
    /// Implementacion Servicio Repositorio para manejo de acceso a datos mediante EntityFramework
    /// </summary>
    /// <typeparam name="T">Tipo de entidad a la cual realizar las operaciones</typeparam>
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _Context;
        protected readonly bool IsUnitOfWork;

        public Repository(DbContext context = null, bool isUnitOfWork = false)
        {
            this._Context = context;
            this.IsUnitOfWork = isUnitOfWork;
        }

        public Repository() : this(new SignalRContext(), false)
        {
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _Context.Set<T>().ToListAsync();
        }
        
        public T Add(T entity)
        {
            _Context.Add(entity);
            Save();
            return entity;
        }
        public bool Delete(int id)
        {
            var product = _Context.Set<T>().Find(id);
            var result = _Context.Set<T>().Remove(product);
            return Save();
        }
        public bool Update(T entity)
        {
            var result = _Context.Set<T>().Update(entity);
            return Save();
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
            if (_Context != null)
            {
                try
                {
                    result = _Context.SaveChanges();
                    // se implementa log personalizado
                    // LogHelper.Log(LogTarget.EventLog, _context.LogMessages);
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return result;
        }

        private bool Save() 
        {
            int changes = 0;
            if (!IsUnitOfWork)
            {
                changes = SaveChanges();
            }

            return changes == 1;
        }

        public void Dispose()
        {
            _Context.Dispose();
        }
    }
}