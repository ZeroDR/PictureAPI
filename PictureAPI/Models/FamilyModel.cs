using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureAPI.Models
{
    /// <summary>
    /// 民族列表对象
    /// </summary>
    public class FamilyModel
    {
        public int id { get; set; }

        public string name { get; set; }

        public string aliasname { get; set; }
    }
}