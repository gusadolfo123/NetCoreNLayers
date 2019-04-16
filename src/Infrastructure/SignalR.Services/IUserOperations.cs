namespace SignalR.Services
{
    using SignalR.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IUserOperations
    {
        User Create(User user);
        bool Delete(int userID);
        bool DeleteWithLog(int userID);
        Task<IEnumerable<User>> GetBy(QueryParameters<User> queryParameters = null);
        bool Update(User user); 
    }
}
