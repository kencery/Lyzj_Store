using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class L_ProductPhotoInfo
    {
        #region  ---字段---
        private int _id;
        private int _productid;
        private string _productimages;
        private string _productcontent;
        private DateTime _addtime;
        #endregion

        #region  ---属性---
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public int ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }
        public string ProductImages
        {
            get { return _productimages; }
            set { _productimages = value; }
        }
        public string ProductContent
        {
            get { return _productcontent; }
            set { _productcontent = value; }
        }
        public DateTime AddTime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        #endregion

        #region  ---默认构造函数---
        public L_ProductPhotoInfo()
        { 
            
        }
        #endregion

        #region  ---自己写的构造函数---
        public L_ProductPhotoInfo(int ID, int ProductID, string ProductImages, string ProductContent, DateTime AddTime)
        {
            this._id = ID;
            this._productid = ProductID;
            this._productimages = ProductImages;
            this._productcontent = ProductContent;
            this._addtime = AddTime;
        }
        #endregion
    }
}
