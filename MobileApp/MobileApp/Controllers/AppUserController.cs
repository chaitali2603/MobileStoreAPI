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
    public class AppUserController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage CreateAppUser(AppUser Appuser1)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                if(Appuser1.Id == Guid.Empty)
                {
                    Appuser1.Id = Guid.NewGuid();
                    Appuser1.CreatedDate = DateTime.Now;
                    Appuser1.UpdatedDate = DateTime.Now;
                    db.AppUsers.Add(Appuser1);
                    db.SaveChanges();
                }
                else
                {
                    Appuser1.UpdatedDate = DateTime.Now;
                    db.Entry(Appuser1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, Appuser1);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage DeleteAppUser(Guid AppuserId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Appuser = db.AppUsers.FirstOrDefault(x => x.Id == AppuserId);
                if(_Appuser == null)
                {
                    throw new Exception("There are no user available");
                }
                _Appuser.IsDeleted = true;
                _Appuser.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAppUserById (string Token)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var UserId = TokenManager.ValidateToken(Token);
                var AppUserId = Guid.Parse(UserId);
                var _Appuser = db.AppUsers.FirstOrDefault(x => x.Id == AppUserId && x.IsDeleted != true);
                
                return Request.CreateResponse(HttpStatusCode.OK, _Appuser);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
