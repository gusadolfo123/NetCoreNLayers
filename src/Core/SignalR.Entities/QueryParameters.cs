using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace SignalR.Entities
{
    public class QueryParameters<T> where T : class
    {
        public List<Expression<Func<T, object>>> Includes { get; set; }
        public Expression<Func<T, bool>> Where { get; set; }
    }
}