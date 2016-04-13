using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 集成表 为了实现购买商品而设置
    /// </summary>
    public class L_CartInfo
    {
        #region  ---字段---
        private int _id;
        private int _userid;
        private string _cartid;
        private int _productid;
        private int _bugnum;
        private DateTime _bugtime;
        #endregion

        #region  ---属性---
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int UserID
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public string CartID
        {
            get { return _cartid; }
            set { _cartid = value; }
        }
        public int ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }
        public int BugNum
        {
            get { return _bugnum; }
            set { _bugnum = value; }
        }
        public DateTime bugTime
        {
            get { return _bugtime; }
            set { _bugtime = value; }
        }
        #endregion

        #region  ---默认构造函数---
        public L_CartInfo()
        {

        }
        #endregion

        #region  ---自己写的构造函数---
        public L_CartInfo(int ID, int userID, string CartID, int ProductID, int BugNum, DateTime BugTime)
        {
            this._id = ID;
            this._userid = userID;
            this._cartid = CartID;
            this._productid = ProductID;
            this._bugnum = BugNum;
            this._bugtime = BugTime;
        }
        #endregion
    }
}
