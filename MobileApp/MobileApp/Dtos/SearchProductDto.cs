using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApp.Dtos
{
    public class SearchProductDto
    {
        public int pageno { get; set; }
        public int recordperpage { get; set; }
        public decimal? Price { get; set; }
        public List<filter> Ram { get; set; }
        public List<filter> Brand { get; set; }
        public List<filter> internalStorage { get; set; }
        public List<filter> OpratingSystem { get; set; }

        public string search { get; set; }

    }

    public class filter
    {
        public string name { get; set; }
        public bool value { get; set; }
    }
}