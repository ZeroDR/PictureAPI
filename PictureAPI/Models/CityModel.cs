using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureAPI.Models
{
    public class CityModel
    {
        public int id { get; set; }

        public string city { get; set; }

        public string code { get; set; }

        public string lat { get; set; }

        public string lon { get; set; }
    }
}