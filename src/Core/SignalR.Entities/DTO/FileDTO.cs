namespace SignalR.Entities.DTO
{
    using System;

    public class FileDTO
    {
        public int FileID { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public DateTime UploadDate { get; set; }

        public int RequestID { get; set; }
        public Request Request { get; set; }
    }
}