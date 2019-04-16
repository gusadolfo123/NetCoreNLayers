namespace SignalR.DAL
{
    using SignalR.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class RepositoryFactory<T> where T : class
    {
        public static IRepository<T> GetRepository(bool isUnitOfWork = false)
        {
            return new Repository<T>(isUnitOfWork: isUnitOfWork);
        }
    }
}
