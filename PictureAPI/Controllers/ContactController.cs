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
    public class ContactController : ApiController
    {
        //对象操作对象
        private ContactHandle _handle = null;

        public ContactController()
        {
            if(_handle == null)
            {
                _handle = new ContactHandle();
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
                _handle = new ContactHandle();
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
        /// 获取56个民族列表
        /// </summary>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetListFamily()
        {
            if (_handle == null)
            {
                _handle = new ContactHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetListFamily();
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
        /// 获取菜系列表
        /// </summary>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetListFood()
        {
            if (_handle == null)
            {
                _handle = new ContactHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetListFood();
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
                _handle = new ContactHandle();
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

        /// <summary>
        /// /api/Contact
        /// </summary>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetItemDescription(int m=-1, int c=-1)
        {
            if (_handle == null)
            {
                _handle = new ContactHandle();
            }
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetDescriptionById(m,c);
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
