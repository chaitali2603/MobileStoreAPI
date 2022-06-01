using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileApp.Controllers
{
    public class OrderProductController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage CreateOrderProduct(OrderProduct OrderProduct1)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                if (OrderProduct1.Id == Guid.Empty)
                {
                    OrderProduct1.Id = Guid.NewGuid();
                    OrderProduct1.CreatedDate = DateTime.Now;
                    OrderProduct1.UpdatedDate = DateTime.Now;
                    db.OrderProducts.Add(OrderProduct1);
                    db.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
