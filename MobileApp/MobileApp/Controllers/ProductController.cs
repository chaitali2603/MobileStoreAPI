using MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MobileApp.Controllers
{
    public class ProductController : ApiController
    {
        [HttpPost]
       public HttpResponseMessage CreateProduct(Product product1 )
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                if (product1.Id == Guid.Empty)
                {
                    product1.Id = Guid.NewGuid();
                    product1.CreatedDate = DateTime.Now;
                    product1.UpdatedDate = DateTime.Now;
                    db.Products.Add(product1);
                    db.SaveChanges();
                }
                else
                {
                    product1.UpdatedDate = DateTime.Now;
                    db.Entry(product1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK,product1);
            }
            catch(Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage DeleteProduct(Guid ProductId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
              var _Product=  db.Products.FirstOrDefault(x => x.Id == ProductId);
                if (_Product == null)
                {
                    throw new Exception("There are no products availabale.");
                }
                _Product.IsDeleted = true;
                _Product.UpdatedDate = DateTime.Now;
                db.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }
        }
        [HttpPost]
        public HttpResponseMessage GetProductById( Guid ProductId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Product= db.Products.FirstOrDefault(x => x.Id == ProductId);
                return Request.CreateResponse(HttpStatusCode.OK, _Product);
            }
            catch (Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }
        }
    }
}
