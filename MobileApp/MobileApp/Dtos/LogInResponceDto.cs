using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApp.Dtos
{
    public class LogInResponceDto
    {
        public AppUser User { get; set; }
        public string Token { get; set; }

    }
}