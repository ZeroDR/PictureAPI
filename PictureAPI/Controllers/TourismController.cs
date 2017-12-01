using PictureAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Data;
using PictureAPI.Handle;

namespace PictureAPI.Controllers
{
    public class TourismController : ApiController
    {
        //对象操作对象
        private TourismHandle _handle = null;

        public TourismController()
        {
            if(_handle == null)
            {
                _handle = new TourismHandle();
            }
        }

        /// <summary>
        /// 获取洲列表
        /// </summary>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetListState()
        {
            if (_handle == null)
            {
                _handle = new TourismHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetListState();
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
              
        /// <summary>
        /// /api/Contact
        /// </summary>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetListAll(int instate = -1)
        {
            if (_handle == null)
            {
                _handle = new TourismHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetSource(instate);
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
