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
    public class MapController : ApiController
    {
        private MapHandle _handle = null;

        public MapController()
        {
            if (_handle == null)
            {
                _handle = new MapHandle();
            }
        }
    }
}
