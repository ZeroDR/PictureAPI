using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using PictureAPI.Handle;
using Newtonsoft.Json;
using PictureAPI.Models;

namespace PictureAPI.Controllers
{
    public class AboutController : ApiController
    {
        private AboutHandle _handle = null;

        private AboutController()
        {
            if (_handle == null)
            {
                _handle = new AboutHandle();
            }
        }


        [CrossSite]
        public ResponseModel GetAboutInfo(string uid = "1")
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetAboutInfo(uid);
                if (dt != null)
                {
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "aliasname|display";
                    features.primaryFieldName = "id";
                    features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dt));//(Contact[])ls.ToArray();
                    responseModel.response = features;
                }
            }
            catch (Exception ex)
            {
                responseModel.description = ex.Message.ToString();
                responseModel.success = false;
                responseModel.response = JsonConvert.DeserializeObject("{}");
            }
            return responseModel;
        }
    }
}
