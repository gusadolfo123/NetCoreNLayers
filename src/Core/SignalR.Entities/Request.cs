namespace SignalR.Entities
{
    using System;
    using System.Collections.Generic;

    public class Request
    {
        public int RequestID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InternalCode { get; set; }
        public DateTime CreationDate { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int AreaID { get; set; }
        public Area Area { get; set; }

        public int RequestTypeID { get; set; }
        public RequestType RequestType { get; set; }

        public List<File> Files { get; set; }
        public List<Comment> Comments { get; set; }

    }
}