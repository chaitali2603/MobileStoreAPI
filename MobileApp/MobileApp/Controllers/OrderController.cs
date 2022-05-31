using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileApp.Controllers
{
    public class OrderController : ApiController
    {
        [HttpPost]
        public HttpRequestMessage CreateOrder(Order order1)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                if (order1.Id == Guid.Empty)
                {
                    order1.Id = Guid.NewGuid();
                    order1.CreatedDate = DateTime.Now;
                    order1.UpdatedDate = DateTime.Now;
                    db.Orders.Add(order1);
                    db.SaveChanges();
                }
               
                    order1.UpdatedDate = DateTime.Now;
                    db.Entry(order1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK, order1);
            }
             
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

    }
}
