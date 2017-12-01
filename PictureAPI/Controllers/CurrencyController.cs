using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using Newtonsoft.Json;
using PictureAPI.Models;
using PictureAPI.Handle;

namespace PictureAPI.Controllers
{
    public class CurrencyController : ApiController
    {
        private CurrencyHandle _handle = null;

        public CurrencyController()
        {
            if (_handle == null)
            {
                _handle = new CurrencyHandle();
            }
        }

        /// <summary>
        /// /api/Contact
        /// </summary>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetItemDescription(int m = -1, int c = -1)
        {
            if (_handle == null)
            {
                _handle = new CurrencyHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetDescriptionById(m, c);
                if (dt != null)
                {
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "name";
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
