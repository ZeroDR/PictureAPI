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
    public class OthersController : ApiController
    {
        private OthersHandle _handle = null;

        public OthersController()
        {
            if (_handle == null)
            {
                _handle = new OthersHandle();
            }
        }
    }
}
