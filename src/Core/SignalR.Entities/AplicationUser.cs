using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace SignalR.Entities
{
    public class AplicationUser: ClaimsIdentity
    {
        public string Id { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }

    }
}
