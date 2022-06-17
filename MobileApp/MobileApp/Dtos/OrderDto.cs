using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MobileApp.Models;
namespace MobileApp.Dtos
{
    public class OrderDto
    {
        public Order Order { get; set; }
        public List<OrderProduct> OrderProduct { get; set; }
        
    }
}