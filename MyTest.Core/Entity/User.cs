using System;
using System.Collections.Generic;
using System.Text;

namespace MyTest.Core.Enitity
{    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool IsLoggedIn { get; set; }
    }
}
