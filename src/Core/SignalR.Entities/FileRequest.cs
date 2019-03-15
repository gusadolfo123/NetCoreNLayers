using System;

namespace SignalR.Entities
{
    public class FileRequest
    {
        public int FileRequestID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public DateTime CreationDate { get; set; }

        public int AreaID { get; set; }
        public Area Area { get; set; }

    }
}