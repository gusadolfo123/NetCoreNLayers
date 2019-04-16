namespace SignalR.Entities.DTO
{
    using System;

    public class CommentDTO
    {
        public int CommentID { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ModifDate { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

        public int RequestID { get; set; }
        public Request Request { get; set; }

        public int CommentTypeID { get; set; }
        public CommentType CommentType { get; set; }

    }
}