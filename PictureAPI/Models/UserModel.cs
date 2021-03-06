﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureAPI.Models
{
    public class UserModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public string aliasname { get; set; }

        public string description { get; set; }
        
        public List<AboutModel> model { get; set; }

        public List<AboutOthersModel> othermodel { get; set; }
    }
}