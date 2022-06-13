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
    public class AddressController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage CreateAddress([FromUri] string token, [FromBody] Address address1)
        {
            try
            {
                var userID = TokenManager.ValidateToken(token);
                var appUserId = Guid.Parse(userID);
                MobileStoreEntities1 db = new MobileStoreEntities1();
                if (address1.Id == Guid.Empty)
                {
                    address1.Id = Guid.NewGuid();
                    address1.CreatedDate = DateTime.Now;
                    address1.UpdatedDate = DateTime.Now;
                    address1.UserId = appUserId;
                    db.Addresses.Add(address1);
                    db.SaveChanges();
                }
                else
                {
                    address1.UpdatedDate = DateTime.Now;
                    db.Entry(address1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, address1);
            }
            catch (Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage DeleteAddress(Guid AddressId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Address = db.Addresses.FirstOrDefault(x => x.Id == AddressId);
                if (_Address == null)
                {
                    throw new Exception("There are no address availabale.");
                }
                _Address.IsDated = true;
                _Address.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);

            }
            catch (Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }

        }

        [HttpGet]
        public HttpResponseMessage GetAddressById(Guid AddressId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Address = db.Addresses.FirstOrDefault(x => x.Id == AddressId && x.IsDated != true);
                return Request.CreateResponse(HttpStatusCode.OK, _Address);
            }
            catch (Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage GetAddressByUserId(string Token)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var UserId = TokenManager.ValidateToken(Token);
                var AppUserId = Guid.Parse(UserId);
                var _Address = db.Addresses.Where(x => x.UserId == AppUserId && x.IsDated == false).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, _Address);
            }
            catch (Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }
        }
    }
}
