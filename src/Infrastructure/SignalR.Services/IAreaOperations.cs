namespace SignalR.Services
{
    using SignalR.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IAreaOperations
    {
        Area Create(Area area);
        bool Delete(int areaID);
        bool DeleteWithLog(int areaID);
        Task<IEnumerable<Area>> GetBy(QueryParameters<Area> queryParameters = null);  
        bool Update(Area area);
    }
}
