using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 公布告示表，在前台显示网站告示
    /// </summary>

    public class L_BulletionInfo
    {
        #region  ---字段---
        private int _id;
        private string _bulletintitle;
        private string _bulletinContent;
        private Int16 _ispost;
        private int _orderNum;
        private DateTime _posttime;
        #endregion

        #region  ---属性---
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        public string BulletinTitle
        {
            get { return _bulletintitle; }
            set { _bulletintitle = value; }
        }
        public string BulletinContent
        {
            get { return _bulletinContent; }
            set { _bulletinContent = value; }
        }
        public Int16 IsPost
        {
            get { return _ispost; }
            set { _ispost = value; }
        }
        public int OrderNum
        {
            get { return _orderNum; }
            set { _orderNum = value; }
        }
        public DateTime PostTime
        {
            get { return _posttime; }
            set { _posttime = value; }
        }
        #endregion

        #region  ---默认构造函数---
        public L_BulletionInfo()
        {

        }
        #endregion

        #region  ---自己写的构造函数---
        public L_BulletionInfo(int ID, string bulletinTitle, string bulletinContent, Int16 isPost, int orderNum, DateTime PostTime)
        {
            this._id = ID;
            this._bulletintitle = bulletinTitle;
            this._bulletinContent = bulletinContent;
            this._ispost = isPost;
            this._orderNum = orderNum;
            this._posttime = PostTime;
        }
        #endregion
    }
}
