using System;
using System.Collections.Generic;

namespace Obligaciones.Models
{
    public class User
    {
        public User()
        {
        }
        public long UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public ICollection<WorkLoad> WorkLoads { get; set; }
    }

    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
