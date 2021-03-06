namespace SignalR.Entities.DTO
{
    using System.Collections.Generic;

    public class UserDTO
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public decimal LastName { get; set; }
        public int Code { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Request> Requests { get; set; }

    }
}