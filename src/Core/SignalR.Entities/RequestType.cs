using System;
using System.Collections.Generic;

namespace SignalR.Entities
{
    public class RequestType
    {
        public int RequestTypeID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<Request> Requests { get; set; }

    }
}