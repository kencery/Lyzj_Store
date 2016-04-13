using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class L_ProductInfo
    {
        #region  ---字段---
        private int _productid;
        private string _pronumber;
        private string _productname;
        private string _keyword;
        private int _productcategoryid;
        private string _categoryname;
        private string _parentidroute;
        private string _parentnameroute;
        private string _productimage;
        private Decimal _currentprice;
        private Decimal _price;
        private Decimal _menberprince;
        private string _danwei;
        private int _productstore;
        private string _productdesc;
        private int _remainday;
        private int _clicknum;
        private int _isreviewenable;
        private Int16 _ispost;
        private Int16 _iscommend;
        private DateTime _addtime;
        private string _linkqqid;
        private string _linkqqname;
        private string _freighttype;
        private decimal _freight;
        private int _adminid;
        #endregion

        #region  --属性---
        public int ProductID
        {
            get { return _productid; }
            set { _productid = value; }
        }
        public string Pronumber
        {
            get { return _pronumber; }
            set { _pronumber = value; }
        }
        public string ProductName
        {
            get { return _productname; }
            set { _productname = value; }
        }
        public string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }
        public int ProductCategoryID
        {
            get { return _productcategoryid; }
            set { _productcategoryid = value; }
        }
        public string CategoryName
        {
            get { return _categoryname; }
            set { _categoryname = value; }
        }
        public string ParentIDRoute
        {
            get { return _parentidroute; }
            set { _parentidroute = value; }
        }
        public string ParentNameRoute
        {
            get { return _parentnameroute; }
            set { _parentnameroute = value; }
        }
        public string ProductImage
        {
            get { return _productimage; }
            set { _productimage = value; }
        }
        public Decimal CurrentPrice
        {
            get { return _currentprice; }
            set { _currentprice = value; }
        }
        public Decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public Decimal MenberPrince
        {
            get { return _menberprince; }
            set { _menberprince = value; }
        }
        public string Danwei
        {
            get { return _danwei; }
            set { _danwei = value; }
        }
        public int ProducStore
        {
            get { return _productstore; }
            set { _productstore = value; }
        }
        public string ProductDesc
        {
            get { return _productdesc; }
            set { _productdesc = value; }
        }
        public int RemainDay
        {
            get { return _remainday; }
            set { _remainday = value; }
        }
        public int ClickNum
        {
            get { return _clicknum; }
            set { _clicknum = value; }
        }
        public int Isreviewenable
        {
            get { return _isreviewenable; }
            set { _isreviewenable = value; }
        }
        public Int16 Ispost
        {
            get { return _ispost; }
            set { _ispost = value; }
        }
        public Int16 Iscommend
        {
            get { return _iscommend; }
            set { _iscommend = value; }
        }
        public DateTime Addtime
        {
            get { return _addtime; }
            set { _addtime = value; }
        }
        public string LinkQQID
        {
            get { return _linkqqid; }
            set { _linkqqid = value; }
        }
        public string LinkQQName
        {
            get { return _linkqqname; }
            set { _linkqqname = value; }
        }
        public string FreightType
        {
            get { return _freighttype; }
            set { _freighttype = value; }
        }
        public decimal Freight
        {
            get { return _freight; }
            set { _freight = value; }
        }
        public int AdminID
        {
            get { return _adminid; }
            set { _adminid = value; }
        }
        #endregion

        #region  ---默认构造函数---
        public L_ProductInfo()
        { 
            
        }
        #endregion

        #region  ---自己写的构造函数---
        public L_ProductInfo(int productID, string proNumber, string productName, string keyWord, int productCategoryID, string CategoryName, string parentIdRoute,
            string parentNameRoute, string productImage, Decimal currentPrince, Decimal Prince, Decimal menberPrince, string danwei,
            int productStore, string productDesc, int remainDay, int clickNum,int isReviewEnable, Int16 isPost, Int16 isCommend, DateTime addTime,
            string linkQQID, string linkQQName, string freightType, Decimal freight,
            int adminID)
        {
            this._productid = productID;
            this._pronumber = proNumber;
            this._productname = productName; 
            this._keyword = keyWord;
            this._productcategoryid = productCategoryID;
            this._categoryname = CategoryName;
            this._parentidroute = parentIdRoute; 
            this._parentnameroute = parentNameRoute;
            this._productimage = productImage; 
            this._currentprice = currentPrince;
            this._price = Prince;
            this._menberprince = menberPrince; 
            this._danwei = danwei;
            this._productstore = productStore; 
            this._productdesc = productDesc;
            this._remainday = remainDay; 
            this._clicknum = clickNum;
            this._isreviewenable = isReviewEnable;
            this._ispost = isPost;
            this._iscommend = isCommend; 
            this._addtime = addTime;
            this._linkqqid = linkQQID;
            this._linkqqname = linkQQName;
            this._freighttype = freightType;
            this._freight = freight;
            this._adminid = adminID;
        }

        #endregion
    }
}
