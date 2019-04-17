namespace SignalR.BLL
{
    using SignalR.DAL;
    using SignalR.Entities;
    using SignalR.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class RequestTypeOperations : IRequestTypeOperations
    {
        public RequestType Create(RequestType requestType)
        {
            using (var repository = RepositoryFactory<RequestType>.GetRepositorySqlServer())
            {
                return repository.Add(requestType);
            }
        }

        public bool Delete(int requestTypeID)
        {
            using (var repository = RepositoryFactory<RequestType>.GetRepositorySqlServer())
            {
                return repository.Delete(requestTypeID);
            }
        }

        public bool DeleteWithLog(int requestTypeID)
        {
            using (var repository = RepositoryFactory<RequestType>.GetRepositorySqlServer())
            {
                return repository.Delete(requestTypeID);
            }
        }

        public Task<IEnumerable<RequestType>> GetBy(QueryParameters<RequestType> queryParameters = null)
        {
            using (var repository = RepositoryFactory<RequestType>.GetRepositorySqlServer())
            {
                return repository.GetByFilter(queryParameters);
            }
        }

        public bool Update(RequestType requestType)
        {
            using (var repository = RepositoryFactory<RequestType>.GetRepositorySqlServer())
            {
                return repository.Update(requestType);
            }
        }
    }
}
