using SignalR.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SignalR.Helpers
{
    public static class IdentityConfig
    {
        public static IEnumerable<User> GetUsers()
        {
            return new List<User>
            {
                new User
                {
                    FirstName: 
                }
            };
        }
    }
}
