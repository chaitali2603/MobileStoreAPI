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
    public class LogInController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetUserByToken(string Token)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var userID = TokenManager.ValidateToken(Token);
                var appUserId = Guid.Parse(userID);
                var user = db.AppUsers.FirstOrDefault(x => x.Id == appUserId);
                user.Password = "";
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public HttpResponseMessage LogIn(LogInDto model)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var user = db.AppUsers.FirstOrDefault(x => x.Email == model.Email);
                if (user == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "No User Found");
                }
                if (user.Password != model.Password)
                {

                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Password invalid");
                }
                LogInResponceDto logInResponce = new LogInResponceDto();
                logInResponce.Token = TokenManager.GenerateToken(user.Id);

                logInResponce.User = user;

                return Request.CreateResponse(HttpStatusCode.OK, logInResponce);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
}
