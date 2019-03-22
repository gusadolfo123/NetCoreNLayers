using System.Collections.Generic;

namespace SignalR.Entities.DTO
{
    public class AreaDTO
    {
        public int AreaID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }

        public List<Request> Requests { get; set; }
    }
}