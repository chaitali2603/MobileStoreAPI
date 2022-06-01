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
                OrderProduct1.UpdatedDate = DateTime.Now;
                db.Entry(OrderProduct1).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, OrderProduct1);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage DeleteOrderProduct(Guid orderProductId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Orderproduct = db.Orders.FirstOrDefault(x => x.Id == orderProductId);
                if (_Orderproduct == null)
                {
                    throw new Exception("There Is No Order Product Like This");
                }
                _Orderproduct.IsDeleted = true;
                _Orderproduct.CreatedDate = DateTime.Now;
                _Orderproduct.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetOrderProductById(Guid orderProductId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _OrderProduct = db.Addresses.FirstOrDefault(x => x.Id == orderProductId && x.IsDated != true);
                return Request.CreateResponse(HttpStatusCode.OK, _OrderProduct);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetOrderProductByUserId(Guid userId)
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
