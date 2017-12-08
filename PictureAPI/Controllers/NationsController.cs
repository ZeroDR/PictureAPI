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
    /// 名族Controller
    /// </summary>
    public class NationsController : ApiController
    {
        //操作对象
        private NationsHandle _handle = null;

        /// <summary>
        /// 构造函数并实例化操作对象
        /// </summary>
        public NationsController()
        {
            if (_handle == null)
            {
                _handle = new NationsHandle();
            }
        }

        /// <summary>
        /// 获取56个民族列表
        /// </summary>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetListFamily()
        {
            if (_handle == null)
            {
                _handle = new NationsHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetListFamily();
                if (dt != null)
                {
                    List<FamilyModel> lsFamily = dt.DataTableToList<FamilyModel>();
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "name";
                    features.primaryFieldName = "id";
                    features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(lsFamily));//(Contact[])ls.ToArray();
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
