using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class L_ProductCollectionInfo
    {
        #region  ---字段---
        private int _id;
        private int _userid;
        private int _productid;
        private DateTime _posttime;
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
        public int ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }
        public DateTime PostTime
        {
            get { return _posttime; }
            set { _posttime = value; }
        }
        #endregion

        #region  ---默认构造函数---
        public L_ProductCollectionInfo()
        { 
            
        }
        #endregion

        #region  ---自己写的构造函数---
        public L_ProductCollectionInfo(int ID, int UserID, int ProductID, DateTime PostTime)
        {
            this._id = ID;
            this._userid = UserID;
            this._productid = ProductID;
            this._posttime = PostTime;
        }
        #endregion
    }
}
