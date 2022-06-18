using MobileApp.Dtos;
using MobileApp.Helper;
using MobileApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace MobileApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {

        [HttpPost]
        public HttpResponseMessage CreateProduct(Product product1)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                if (product1.Id == Guid.Empty)
                {
                    product1.Id = Guid.NewGuid();
                    product1.CreatedDate = DateTime.Now;
                    product1.UpdatedDate = DateTime.Now;
                    product1.IsDeleted = false;
                    db.Products.Add(product1);
                    db.SaveChanges();
                }
                else
                {
                    product1.UpdatedDate = DateTime.Now;
                    db.Entry(product1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, product1);
            }
            catch (Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }
        }
        [HttpGet]
        public HttpResponseMessage DeleteProduct(Guid ProductId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Product = db.Products.FirstOrDefault(x => x.Id == ProductId);
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
        [HttpGet]
        public HttpResponseMessage GetProductById(Guid ProductId)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();
                var _Product = db.Products.FirstOrDefault(x => x.Id == ProductId);
                return Request.CreateResponse(HttpStatusCode.OK, _Product);
            }
            catch (Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }
        }

        private string Filetr1(List<filter> items)
        {
            var strItems = items.Where(x => x.value == true).Select(x => x.name).ToList();
            return string.Join(",", strItems);
        }

        [HttpPost]
        public HttpResponseMessage SearchProduct(SearchProductDto model)
        {
            try
            {
                MobileStoreEntities1 db = new MobileStoreEntities1();

                var Products = db.SearchAllProduct(model.pageno, model.recordperpage, model.Price,
                    Filetr1(model.Ram),
                    Filetr1(model.Brand), Filetr1(model.internalStorage), Filetr1(model.OpratingSystem), model.search);
                return Request.CreateResponse(HttpStatusCode.OK, Products);
            }
            catch (Exception ex1)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex1.Message);
            }
        }

        public byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
        public HttpResponseMessage ProductMultipartSave()
        {
            try
            {
                var httpRequest = HttpContext.Current.Request;
                //var filesToDelete =  HttpContext.Current.Request.Params["Product"];
                var product1 = JsonConvert.DeserializeObject<Product>(HttpContext.Current.Request.Params["Product"]);
                if (httpRequest.Files.Count > 0)
                {
                    var base64Img = new Base64Image
                    {
                        FileContents = ReadFully(httpRequest.Files[0].InputStream),
                        ContentType = httpRequest.Files[0].ContentType
                    };
                    product1.ImageUrl = base64Img.ToString();
                }

                MobileStoreEntities1 db = new MobileStoreEntities1();
                if (product1.Id == Guid.Empty)
                {
                    product1.Id = Guid.NewGuid();
                    product1.CreatedDate = DateTime.Now;
                    product1.UpdatedDate = DateTime.Now;
                    product1.IsDeleted = false;
                    db.Products.Add(product1);
                    db.SaveChanges();
                }
                else
                {
                    product1.UpdatedDate = DateTime.Now;
                    db.Entry(product1).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                return Request.CreateResponse(HttpStatusCode.OK, product1);
            }
            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
