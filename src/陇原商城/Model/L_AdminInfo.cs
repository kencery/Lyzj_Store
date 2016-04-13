using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 管理员表的信息
    /// </summary>
    public class L_AdminInfo
    {
        #region  ---字段---
        private int _adminid;
        private string _adminname;
        private string _adminpwd;
        private Int16 _admintype;
        private int _admingroupid;
        private string _lastloginip;
        private DateTime _lastlogintime;
        private Int16 _isenabled;
        private string _message;  //
        #endregion

        #region  ---属性---
        public int AdminID
        {
            get { return _adminid; }
            set { _adminid = value; }
        }
        public string AdminName
        {
            get { return _adminname; }
            set { _adminname = value; }
        }
        public string AdminPwd
        {
            get { return _adminpwd; }
            set { _adminpwd = value; }
        }
        public Int16 AdminType
        {
            get { return _admintype; }
            set { _admintype = value; }
        }
        public int AdminGroupID
        {
            get { return _admingroupid; }
            set { _admingroupid = value; }
        }
        public string LastLoginIP
        {
            get { return _lastloginip; }
            set { _lastloginip = value; }
        }
        public DateTime LastLoginTime
        {
            get { return _lastlogintime; }
            set { _lastlogintime = value; }
        }
        public Int16 IsEnabled
        {
            get { return _isenabled; }
            set { _isenabled = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        #endregion

        #region  ---默认构造函数---
        public L_AdminInfo()
        { 
        
        }
        #endregion

        #region  --- 自己写的构造函数 ---
        public L_AdminInfo(int adminID, string adminName, string adminPwd, Int16 adminType, int AdminGroupID, string lastLoginIP, DateTime lastLoginTime, Int16 isEnabled)
        {
            this._adminid = adminID;
            this._adminname = adminName;
            this._adminpwd = adminPwd;
            this._admintype = adminType;
            this._admingroupid = AdminGroupID;
            this._lastlogintime = lastLoginTime;
            this._isenabled = isEnabled;
        }
        #endregion
    }
}
