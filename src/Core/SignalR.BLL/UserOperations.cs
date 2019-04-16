namespace SignalR.BLL
{
    using SignalR.DAL;
    using SignalR.Entities;
    using SignalR.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class UserOperations : IUserOperations
    {
        public User Create(User user)
        {
            using (var repository = RepositoryFactory<User>.GetRepository())
            {
                return repository.Add(user);
            }
        }

        public bool Delete(int userID)
        {
            using (var repository = RepositoryFactory<User>.GetRepository())
            {
                return repository.Delete(userID);
            }
        }

        public bool DeleteWithLog(int userID)
        {
            using (var repository = RepositoryFactory<User>.GetRepository())
            {
                return repository.Delete(userID);
            }
        }

        public Task<IEnumerable<User>> GetBy(QueryParameters<User> queryParameters = null)
        {
            using (var repository = RepositoryFactory<User>.GetRepository())
            {
                return repository.GetByFilter(queryParameters);
            }
        }

        public bool Update(User user)
        {
            using (var repository = RepositoryFactory<User>.GetRepository())
            {
                return repository.Update(user);
            }
        }
    }
}
