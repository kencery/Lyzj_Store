using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class L_OrderListInfo
    {
        #region  ---字段---
        private string _orderid;
        private int _userid;
        private string _acceptname;
        private string _acceptAddr;
        private string _handset;
        private string _tel;
        private string _zipcode;
        private DateTime _ordertime;
        private DateTime _shippedtime;
        private Int16 _orderstate;
        private Int16 _isnew;
        private int _adminid;
        #endregion

        #region  ---属性---
        public string OrderID
        {
            get { return _orderid; }
            set { _orderid = value; }
        }
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public string AcceptName
        {
            get { return _acceptname; }
            set { _acceptname = value; }
        }
        public string AcceptAddr
        {
            get { return _acceptAddr; }
            set { _acceptAddr = value; }
        }
        public string HandSet
        {
            get { return _handset; }
            set { _handset = value; }
        }
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        public string ZipCode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }
        public DateTime OrderTime
        {
            get { return _ordertime; }
            set { _ordertime = value; }
        }
        public DateTime ShippedTime
        {
            get { return _shippedtime; }
            set { _shippedtime = value; }
        }
        public Int16 OrderState
        {
            get { return _orderstate; }
            set { _orderstate = value; }
        }
        public Int16 IsNew
        {
            get { return _isnew; }
            set { _isnew = value; }
        }
        public int AdminID
        {
            get { return _adminid; }
            set { _adminid = value; }
        }
        #endregion

        #region  ---默认构造函数---
        public L_OrderListInfo()
        {

        }
        #endregion

        #region  ---自己写的构造函数---
        public L_OrderListInfo(string orderID, int userID, string acceptName, string acceptAddr, string HandSet, string Tel, string ZipCode, DateTime orderTime, DateTime shippedTime, Int16 orderState, Int16 isNew, int adminID)
        {
            this._orderid = orderID;
            this._userid = userID;
            this._acceptname = acceptName;
            this._acceptAddr = acceptAddr;
            this._handset = HandSet;
            this._tel = Tel;
            this._zipcode = ZipCode;
            this._ordertime = orderTime;
            this._shippedtime = shippedTime;
            this._orderstate = orderState;
            this._isnew = isNew;
            this._adminid = adminID;
        }
        #endregion
    }
}
