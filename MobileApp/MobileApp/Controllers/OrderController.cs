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
        public HttpResponseMessage CreateOrder(Order order1)
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
        [HttpGet]
        public HttpResponseMessage DeleteOrder(Guid orderId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Order = db.Orders.FirstOrDefault(x => x.Id == orderId);
                if (_Order == null)
                {
                    throw new Exception("There Is No Order Like This");
                }
                _Order.IsDeleted = true;
                _Order.CreatedDate = DateTime.Now;
                _Order.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetOrderById(Guid orderId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Order = db.Addresses.FirstOrDefault(x => x.Id == orderId && x.IsDated != true);
                return Request.CreateResponse(HttpStatusCode.OK, _Order);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetOrderByUserId(Guid userId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Order = db.Orders.FirstOrDefault(x => x.userId == userId);
                return Request.CreateResponse(HttpStatusCode.OK, _Order);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
