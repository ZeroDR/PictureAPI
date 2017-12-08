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
using PictureAPI.Handle.Util;

namespace PictureAPI.Controllers
{
    /// <summary>
    /// 世界各洲操作Control
    /// </summary>
    public class TourismController : ApiController
    {
        //对象操作对象
        private TourismHandle _handle = null;

        /// <summary>
        /// 构造函数并实例化操作对象
        /// </summary>
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
                    List<StateModule> lsState = dt.DataTableToList<StateModule>();
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "name";
                    features.primaryFieldName = "id";
                    //features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(dt));//(Contact[])ls.ToArray();
                    features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(lsState));//(Contact[])ls.ToArray();
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
        /// 根据洲标识获取景点
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
                    List<TourismModel> lsTourism = dt.DataTableToList<TourismModel>();
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "name";
                    features.primaryFieldName = "id";
                    features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(lsTourism));//(Contact[])ls.ToArray();
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
