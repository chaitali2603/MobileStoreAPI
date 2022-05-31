using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApp.Dtos
{
    public class SignUpDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}