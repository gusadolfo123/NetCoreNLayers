namespace SignalR.Entities.DTO
{
    using System.Collections.Generic;

    public class RequestTypeDTO
    {
        public int RequestTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Request> Requests { get; set; }

    }
}