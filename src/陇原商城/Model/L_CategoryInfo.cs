using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class L_CategoryInfo
    {
        #region  ---字段---
        private int _productcategoryid;
        private string _productcategoryname;
        private int _parentid;
        private int _categorydepth;
        private string _categoryDetail;
        #endregion

        #region  ---属性---
        public int ProductCategoryID
        {
            get { return _productcategoryid; }
            set { _productcategoryid = value; }
        }
        public string ProductCategoryName
        {
            get { return _productcategoryname; }
            set { _productcategoryname = value; }
        }
        public int ParentID
        {
            get { return _parentid; }
            set { _parentid = value; }
        }
        public int CategoryDepth
        {
            get { return _categorydepth; }
            set { _categorydepth = value; }
        }
        public string CategoryDetail
        {
            get { return _categoryDetail; }
            set { _categoryDetail = value; }
        }
        #endregion

        #region  ---默认构造函数---
        public L_CategoryInfo()
        { 
            
        }
        #endregion

        #region  ---自己写的构造函数---
        public L_CategoryInfo(int productCategoryID, string productCategoryName, int parentID, int categoryDepth)
        {
            this._productcategoryid = productCategoryID;
            this._productcategoryname = productCategoryName;
            this._parentid = parentID;
            this._categorydepth = categoryDepth;
        }
        #endregion
    }
}
