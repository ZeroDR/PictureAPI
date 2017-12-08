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
using PictureAPI.Handle.Util;

namespace PictureAPI.Controllers
{
    /// <summary>
    /// 关于Controller
    /// </summary>
    public class AboutController : ApiController
    {
        //操作对象
        private AboutHandle _handle = null;

        /// <summary>
        /// 构造函数并实例化操作对象
        /// </summary>
        private AboutController()
        {
            if (_handle == null)
            {
                _handle = new AboutHandle();
            }
        }


        /// <summary>
        /// 获取关于信息
        /// </summary>
        /// <param name="uid">用户ID，默认显示1</param>
        /// <returns></returns>
        [CrossSite]
        public ResponseModel GetAboutInfo(string uid = "1")
        {
            ResponseModel responseModel = new ResponseModel();
            try
            {
                responseModel.description = "请求数据成功！";
                responseModel.success = true;
                DataTable dt = _handle.GetUserInfo(uid);
                if (dt != null)
                {
                    //_handle.GetAboutInfo(uid);
                    List<UserModel> lsUser = dt.DataTableToList<UserModel>();
                    for (int i = 0; i < lsUser.Count; i++)
                    {
                        UserModel u = lsUser[i];
                        DataTable adt = _handle.GetAboutInfo(u.id);
                        DataTable odt = _handle.GetAboutOther(u.id);
                        if (adt != null)
                        {
                            lsUser[i].model = adt.DataTableToList<AboutModel>();
                        }
                        if (odt != null)
                        {
                            lsUser[i].othermodel = odt.DataTableToList<AboutOthersModel>();
                        }
                    }
                    FeatureModel features = new FeatureModel();
                    features.displayFieldName = "aliasname|display";   
                    features.primaryFieldName = "id";
                    features.features = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(lsUser));//(Contact[])ls.ToArray();
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
