namespace SignalR.Entities
{
    using System.Collections.Generic;

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