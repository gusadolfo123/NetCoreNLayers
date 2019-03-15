using System;
using System.Collections.Generic;

namespace SignalR.Entities
{
    public class Request
    {
        public int RequestID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string InternalCode { get; set; }
        public DateTime CreationDate { get; set; }

        public int AreaID { get; set; }
        public Area Area { get; set; }

        public List<FileRequest> Files { get; set; }

    }
}