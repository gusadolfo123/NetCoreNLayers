namespace SignalR.Services
{
    using SignalR.Entities;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommentTypeOperations
    {
        CommentType Create(CommentType commentType);
        bool Delete(int commentTypeID); 
        bool DeleteWithLog(int commentTypeID);
        Task<IEnumerable<CommentType>> GetBy(QueryParameters<CommentType> queryParameters = null);
        bool Update(CommentType commentType); 
    }
}
