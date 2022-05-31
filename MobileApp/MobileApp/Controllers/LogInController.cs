using MobileApp.Dtos;
using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileApp.Controllers
{
    public class LogInController : ApiController
    {

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
                if(user.Password!=model.Password)
                {
                   
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Password invalid");
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);

            }
        }
    }
}
