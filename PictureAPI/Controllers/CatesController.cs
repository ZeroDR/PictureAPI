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
using PictureAPI.Handle.Util;

namespace PictureAPI.Controllers
{
    /// <summary>
    /// 美食Controller
    /// </summary>
    public class CatesController : ApiController
    {
        private CatesHandle _handle = null;

        public CatesController()
        {
            if (_handle == null)
            {
                _handle = new CatesHandle();
            }
        }

        /// <summary>
        /// 获取菜系列表
        /// </summary>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetListCate()
        {
            if (_handle == null)
            {
                _handle = new CatesHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetListCate();
                if (dt != null)
                {
                    List<CateModel> lsCate = dt.DataTableToList<CateModel>();
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "name";
                    features.primaryFieldName = "id";
                    features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(lsCate));//(Contact[])ls.ToArray();
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
