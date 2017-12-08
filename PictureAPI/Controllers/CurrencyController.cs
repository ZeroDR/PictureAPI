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
    /// 各项描述信息接口
    /// </summary>
    public class CurrencyController : ApiController
    {
        //操作对象
        private CurrencyHandle _handle = null;

        /// <summary>
        /// 构造函数并实现操作对象实例化
        /// </summary>
        public CurrencyController()
        {
            if (_handle == null)
            {
                _handle = new CurrencyHandle();
            }
        }

        /// <summary>
        /// 根据模块标识和子项标识获取描述信息
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
                    List<DescriptionModel> lsDescription = dt.DataTableToList<DescriptionModel>();
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "name";
                    features.primaryFieldName = "id";
                    features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(lsDescription));//(Contact[])ls.ToArray();
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
