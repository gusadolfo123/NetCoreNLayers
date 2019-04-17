namespace SignalR.BLL
{
    using SignalR.DAL;
    using SignalR.Entities;
    using SignalR.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public class CommentTypeOperations : ICommentTypeOperations
    {
        public CommentType Create(CommentType commentType)
        {
            using (var repository = RepositoryFactory<CommentType>.GetRepositorySqlServer())
            {
                return repository.Add(commentType);
            }
        }

        public bool Delete(int commentTypeID)
        {
            using (var repository = RepositoryFactory<CommentType>.GetRepositorySqlServer())
            {
                return repository.Delete(commentTypeID);
            }
        }

        public bool DeleteWithLog(int commentTypeID)
        {
            using (var repository = RepositoryFactory<CommentType>.GetRepositorySqlServer())
            {
                return repository.Delete(commentTypeID);
            }
        }

        public Task<IEnumerable<CommentType>> GetBy(QueryParameters<CommentType> queryParameters = null)
        {
            using (var repository = RepositoryFactory<CommentType>.GetRepositorySqlServer())
            {
                return repository.GetByFilter(queryParameters);
            }
        }

        public bool Update(CommentType commentType)
        {
            using (var repository = RepositoryFactory<CommentType>.GetRepositorySqlServer())
            {
                return repository.Update(commentType);
            }
        }
    }
}
