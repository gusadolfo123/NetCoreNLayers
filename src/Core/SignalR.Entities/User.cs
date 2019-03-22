using System.Collections.Generic;

namespace SignalR.Entities
{
    public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public decimal LastName { get; set; }
        public string Code { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Request> Requests { get; set; }

    }
}