namespace SignalR.BLL
{
    using SignalR.DAL;
    using SignalR.Entities;
    using SignalR.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class AreaOperations: IAreaOperations
    {
        public Area Create(Area area)
        {
            using (var repository = RepositoryFactory<Area>.GetRepository())
            {
                return repository.Add(area);
            }
        }

        public bool Delete(int areaID)
        {
            using (var repository = RepositoryFactory<Area>.GetRepository())
            {
                return repository.Delete(areaID);
            }
        }

        public bool DeleteWithLog(int areaID)
        {
            using (var repository = RepositoryFactory<Area>.GetRepository())
            {
                return repository.Delete(areaID);
            }
        }
         
        public Task<IEnumerable<Area>> GetBy(QueryParameters<Area> queryParameters = null)
        {
            using (var repository = RepositoryFactory<Area>.GetRepository())
            {
                return repository.GetByFilter(queryParameters);
            }
        }

        public bool Update(Area area)
        {
            using (var repository = RepositoryFactory<Area>.GetRepository())
            {
                return repository.Update(area);
            }
        }
    }
}
