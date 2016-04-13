using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 用户表的信息
    /// </summary>
    public class L_UserAccountInfo
    {
        #region  ---字段---
        private int _id;
        private int _userid;
        private string _username;
        private string _password;
        private int _usertype;
        private string _moneypwd;  //
        private int _headid;     //
        private string _sex;
        private string _age;
        private string _country;
        private string _province;
        private string _phone;
        private string _mobile;
        private string _email;
        private string _qq;
        private string _note;
        private int _onlinenum;    //
        private int _userleavel;    //         
        private string _usermoney;     //       
        private DateTime _dateregist;   //

        private string _userip;  //用户登录IP
        private int _giftvalue;  //
        private int _money;
        private string _message;
        #endregion

        #region  ---属性---
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        public int Userid
        {
            get { return _userid; }
            set { _userid = value; }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public int Usertype
        {
            get { return _usertype; }
            set { _usertype = value; }
        }
        public string Moneypwd
        {
            get { return _moneypwd; }
            set { _moneypwd = value; }
        }
        public int Headid
        {
            get { return _headid; }
            set { _headid = value; }
        }
        public string Sex
        {
            get { return _sex; }
            set { _sex = value; }
        }
        public string Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string Province
        {
            get { return _province; }
            set { _province = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string QQ
        {
            get { return _qq; }
            set { _qq = value; }
        }
        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
        public int Onlinenum
        {
            get { return _onlinenum; }
            set { _onlinenum = value; }
        }
        public int Userleavel
        {
            get { return _userleavel; }
            set { _userleavel = value; }
        }
        public string Usermoney
        {
            get { return _usermoney; }
            set { _usermoney = value; }
        }
        public DateTime Dateregist
        {
            get { return _dateregist; }
            set { _dateregist = value; }
        }

        public string UserIP
        {
            get { return _userip; }
            set { _userip = value; }
        }
        public int GifValue
        {
            get { return _giftvalue; }
            set { _giftvalue = value; }
        }
        public int Money
        {
            get { return _money; }
            set { _money = value; }
        }
        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
        #endregion

        #region  ---默认构造函数
        public L_UserAccountInfo()
        {

        }
        #endregion

        #region ---自己写的构造函数---
        public L_UserAccountInfo(int ID, int userID, string userName, string Password, int userType, string moneyPwd, int headID, string Sex, string Age, string Country, string Province, string Phone, string Mobile, string Email, string QQ, string Note)
        {
            this._id = ID;
            this._userid = userID;
            this._username = userName;
            this._password = Password;
            this._usertype = userType;
            this._moneypwd = moneyPwd;
            this._headid = headID;
            this._sex = Sex;
            this._age = Age;
            this._country = Country;
            this._province = Province;
            this._phone = Phone;
            this._mobile = Mobile;
            this._email = Email;
            this._qq = QQ;
            this._note = Note;
        }
        #endregion

    }
}
