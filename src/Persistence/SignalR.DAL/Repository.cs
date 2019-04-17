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
    /// Implementacion Servicio Repositorio para manejo de acceso a datos mediante EntityFramework con proveedor SqlServer
    /// </summary>
    /// <typeparam name="T">Tipo de entidad a la cual realizar las operaciones</typeparam>
    public class RepositorySqlServer<T> : IRepository<T> where T : class
    {
        #region Propiedades
        protected readonly DbContext _Context;
        protected readonly bool IsUnitOfWork;
        #endregion

        #region Constructores
        public RepositorySqlServer(bool isUnitOfWork = false)
        {
            this._Context = new SignalRContext();
            this.IsUnitOfWork = isUnitOfWork;
        }
        #endregion

        #region Metodos con las Operaciones del Repositorio
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
            List<T> list = null;
            var query = _Context.Set<T>().AsQueryable();
            if (queryParameters.Includes != null)
            {
                foreach (var include in queryParameters.Includes)
                {
                    query = query.Include(include);
                }
            }

            if (queryParameters.Where != null)
                list = await query.Where(queryParameters.Where).ToListAsync();
            else
                list = await query.ToListAsync();

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
        #endregion
    }
}