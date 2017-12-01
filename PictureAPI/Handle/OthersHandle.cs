using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using PictureAPI.Handle.Util;

namespace PictureAPI.Handle
{
    public class OthersHandle
    {
        private DBHandle _handle = null;

        public OthersHandle()
        {
            if (_handle == null)
            {
                _handle = new DBHandle();
            }
        }
    }
}