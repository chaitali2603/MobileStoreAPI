﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using MobileApp.Models;

namespace MobileApp.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        //public IEnumerable<Product> Get()
        //{
        //    MobileStoreEntities db = new MobileStoreEntities();
        //    return db.Products.ToList();
        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
