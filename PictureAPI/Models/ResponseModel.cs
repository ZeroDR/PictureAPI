using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace PictureAPI.Models
{
    public class ResponseModel
    {
        //请求是否成功
        public bool success { get; set; }

        //请求描述信息
        public string description { get; set; }

        public object response { get; set; }
    }
}