using MobileApp.Dtos;
using MobileApp.Models;
//using MobileApp.Models;
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
    public class SignUpController : ApiController
    {
        [HttpPost]
        
        public HttpResponseMessage SignUp(SignUpDto model)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();

                if(db.AppUsers.Any(x=>x.Email==model.Email))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Email already exist");
                }

                AppUser App = new AppUser();
                App.Id = Guid.NewGuid();
                App.FirstName = model.FirstName;
                App.LastName = model.LastName;
                App.Password = model.Password;
                App.Email = model.Email;
                App.CreatedDate = DateTime.Now;
                App.UpdatedDate = DateTime.Now;
                db.AppUsers.Add(App);
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, App);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
            

        }

    }
}