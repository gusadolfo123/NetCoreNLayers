namespace SignalR.Entities
{
    using System.Collections.Generic;

    public class CommentType
    {
        public int CommentTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Comment> Comments { get; set; }
    }
}