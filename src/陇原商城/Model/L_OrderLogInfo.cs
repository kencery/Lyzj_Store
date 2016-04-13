using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class L_OrderLogInfo
    {
        #region  ---字段---
        private int _id;
        private string _orderid;
        private int _operateuserid;
        private Int16 _usertype;
        private Int16 _operatetype;
        private string _clientip;
        private string _operatedepict;
        private DateTime _operatetime;
        #endregion

        #region  ---属性---
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        public int OperateUserID
        {
            get { return _operateuserid; }
            set { _operateuserid = value; }
        }
        public Int16 UserType
        {
            get { return _usertype; }
            set { _usertype = value; }
        }
        public Int16 OperateType
        {
            get { return _operatetype; }
            set { _operatetype = value; }
        }
        public string ClientIP
        {
            get { return _clientip; }
            set { _clientip = value; }
        }
        public string OperateDepict
        {
            get { return _operatedepict; }
            set { _operatedepict = value; }
        }
        public DateTime OperateTime
        {
            get { return _operatetime; }
            set { _operatetime = value; }
        }
        #endregion

        #region  ---默认构造函数---
        public L_OrderLogInfo()
        { 
            
        }
        #endregion

        #region  ---自己写的构造函数---
        public L_OrderLogInfo(int ID, string orderID, int operateUserID, Int16 userType, Int16 operateType, string clientIP, string operateDepict, DateTime operateTime)
        {
            this._id = ID;
            this._orderid = orderID;
            this._operateuserid = operateUserID;
            this._usertype = userType;
            this._operatetype = operateType;
            this._clientip = clientIP;
            this._operatedepict = operateDepict;
            this._operatetime = operateTime;
        }
        #endregion
    }
}
