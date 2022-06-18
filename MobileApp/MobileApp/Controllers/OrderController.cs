using MobileApp.Dtos;
using MobileApp.Helper;
using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MobileApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        public HttpResponseMessage GetProductByOrderId(Guid OrderId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var Result = db.GetProductByOrderId(OrderId);
                return Request.CreateResponse(HttpStatusCode.OK, Result);

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
        [HttpPost]
        public HttpResponseMessage CreateOrder([FromUri] string token, [FromBody] OrderDto order1)
        {
            try
            {
                var userID = TokenManager.ValidateToken(token);
                var appUserId = Guid.Parse(userID);
                MobileStoreEntities1 db = new MobileStoreEntities1();

                order1.Order.userId = appUserId;
                if (order1.Order.Id == Guid.Empty)
                {
                    order1.Order.Id = Guid.NewGuid();
                    order1.Order.CreatedDate = DateTime.Now;
                    order1.Order.UpdatedDate = DateTime.Now;
                    db.Orders.Add(order1.Order);
                    db.SaveChanges();
                }

                order1.Order.UpdatedDate = DateTime.Now;
                db.Entry(order1.Order).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                foreach (var Product in order1.OrderProduct)
                {
                    Product.Id = Guid.NewGuid();
                    Product.OrderId = order1.Order.Id;
                }
                db.OrderProducts.AddRange(order1.OrderProduct);
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
        public HttpResponseMessage GetOrderByUserId(string Token)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var users = TokenManager.ValidateTokenWithType(Token);
                var AppUser = Guid.Parse(users.FirstOrDefault());

                var userType = users.LastOrDefault();
                var _Order = db.GetOrderByUserIdAndUserType(userType, AppUser);
                //List<Order> _Order;
                //if (userType != "2")
                //{
                //    _Order = db.Orders.Where(x => x.userId == AppUser).OrderByDescending(x => x.CreatedDate).ToList();
                //}
                //else
                //{
                //    _Order = db.Orders.OrderByDescending(x => x.CreatedDate).ToList();
                //}

                return Request.CreateResponse(HttpStatusCode.OK, _Order);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }



}
