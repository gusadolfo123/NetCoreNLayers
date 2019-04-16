namespace SignalR.Services
{
    using SignalR.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IRequestTypeOperations
    {
        RequestType Create(RequestType requestType); 
        bool Delete(int requestTypeID);
        bool DeleteWithLog(int requestTypeID);
        Task<IEnumerable<RequestType>> GetBy(QueryParameters<RequestType> queryParameters = null);
        bool Update(RequestType requestType);
    }
}
