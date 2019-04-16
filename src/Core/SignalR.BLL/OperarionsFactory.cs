namespace SignalR.BLL
{
    using SignalR.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class OperarionsFactory
    {
        public static IAreaOperations GetAreaOperations() 
        {
            return new AreaOperations();
        }

        public static ICommentTypeOperations GetCommentTypeOperations()
        {
            return new CommentTypeOperations();
        }

        public static IRequestTypeOperations GetRequestOperations()
        {
            return new RequestTypeOperations();
        }

        public static IUserOperations GetUserOperations()
        {
            return new UserOperations();
        }

    }
}
