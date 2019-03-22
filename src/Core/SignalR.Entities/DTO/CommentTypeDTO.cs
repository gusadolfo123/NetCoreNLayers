using System;
using System.Collections.Generic;

namespace SignalR.Entities.DTO
{
    public class CommentTypeDTO
    {
        public int CommentTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Comment> Comments { get; set; }
    }
}