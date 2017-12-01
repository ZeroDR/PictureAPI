using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureAPI.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Instate { get; set; }

        public string Description { get; set; }

        public string Pathname { get; set; }
    }
}