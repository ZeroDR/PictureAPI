using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PictureAPI.Models
{
    public class FeatureModel
    { 
        public string primaryFieldName { get; set; }

        public string displayFieldName { get; set; }

        public object features { get; set; }
    }
}