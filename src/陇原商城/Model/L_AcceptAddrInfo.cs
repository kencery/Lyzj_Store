using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户填写的收获地址信息表
    /// </summary>
    public class L_AcceptAddrInfo
    {
        #region  ---字段---
        private int _id;
        private int _userid;
        private string _realityname;
        private string _rowaddr;
        private int _provinceid;
        private string _province;
        private int _cityid;
        private string _city;
        private int _countryid;
        private string _country;
        private string _tel;
        private string _handset;
        private string _zipcode;
        private string _qqnum;
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
        public string RealityName
        {
            get { return _realityname; }
            set { _realityname = value; }
        }
        public string RowAddr
        {
            get { return _rowaddr; }
            set { _rowaddr = value; }
        }
        public int ProvinceID
        {
            get { return _provinceid; }
            set { _provinceid = value; }
        }
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        public int CityID
        {
            get { return _cityid; }
            set { _cityid = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public int CountryID
        {
            get { return _countryid; }
            set { _countryid = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string Tel
        {
            get { return _tel; }
            set { _tel = value; }
        }
        public string HandSet
        {
            get { return _handset; }
            set { _handset = value; }
        }
        public string zipCode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }
        public string QQNum
        {
            get { return _qqnum; }
            set { _qqnum = value; }
        }
        public DateTime PostTime
        {
            get { return _posttime; }
            set { _posttime = value; }
        }
        #endregion

        #region  --- 默认构造函数 ---
        public L_AcceptAddrInfo()
        { 
            
        }
        #endregion

        #region  ---自己写的构造函数  ---
        public L_AcceptAddrInfo(int ID,int userID,string realityName, string rowAddr,int provinceID,string province,int cityID, string city,int countryID,string country,string tel, string handSet,string zipCode,string qqNum,DateTime postTime)
        {
            this._id = ID;
            this._userid = userID;
            this._realityname = realityName;
            this._rowaddr = rowAddr;
            this._provinceid = provinceID;
            this._province=province;
            this._cityid = cityID;
            this._city = city;
            this._countryid = countryID;
            this._country = country;
            this._tel = tel;
            this._handset = handSet;
            this._zipcode = zipCode;
            this._qqnum = qqNum;
            this._posttime = postTime;

        }
        #endregion
    }
}
