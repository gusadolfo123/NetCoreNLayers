namespace SignalR.DAL
{
    using SignalR.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class RepositoryFactory<T> where T : class
    {
        /// <summary>
        /// Metodo encargado de crear instancia de una clase que implemente la interfaz IRepository<T> con proveedor Sql Server
        /// </summary>
        /// <param name="isUnitOfWork"></param>
        /// <returns></returns>
        public static IRepository<T> GetRepositorySqlServer(bool isUnitOfWork = false) 
        {
            return new RepositorySqlServer<T>(isUnitOfWork); 
        }

        /// <summary>
        /// Metodo encargado de crear instancia de una clase que implemente la interfaz IRepository<T> con proveedor Oracle
        /// </summary>
        /// <param name="isUnitOfWork"></param>
        /// <returns></returns>
        public static IRepository<T> GetRepositoryOracle(bool isUnitOfWork = false)
        {
            return null;
        }
    }
}
