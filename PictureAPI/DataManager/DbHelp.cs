using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbHelper;

namespace PictureAPI.DataManager
{
    public class DbHelp
    {
        //数据哭连接字符串
        public string _Constr { get; set; }
        //数据库类型
        public string _DbType { get; set; }

        private DBHelper _DHelp { get; set; }
        //构造函数
        public DbHelp() { }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="con">数据库连接字符串</param>
        /// <param name="type">数据库类型</param>
        public DbHelp(string con,string type)
        {
            this._Constr = con;
            this._DbType = type;
            if (this._DHelp == null)
            {
                this._DHelp = new DBHelper(this._Constr, this._DbType);
            }
        }
        
        //获取数据操作对象
        public DBHelper GetDBHelper() {
            return this._DHelp;
        }
    }
}