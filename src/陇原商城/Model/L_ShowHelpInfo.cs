using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class L_ShowHelpInfo
    {
        #region ---字段---
        private int _helpid;
        private string _helptitle;
        private int _classid;
        private string _classname;
        private string _parentidroute;
        private string _parentnameroute;
        private string _helpContent;
        private DateTime _posttime;
        private Int16 _isPost;
        #endregion

        #region ---属性---
        public int HelpID
        {
            get { return _helpid; }
            set { _helpid = value; }
        }
        public string HelpTitle
        {
            get { return _helptitle; }
            set { _helptitle = value; }
        }
        public int ClassID
        {
            get { return _classid; }
            set { _classid = value; }
        }
        public string ClassName
        {
            get { return _classname; }
            set { _classname = value; }
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
        public string HelpCntent
        {
            get { return _helpContent; }
            set { _helpContent = value; }
        }
        public DateTime PostTime
        {
            get { return _posttime; }
            set { _posttime = value; }
        }
        public Int16 IsPost
        {
            get { return _isPost; }
            set { _isPost = value; }
        }
        #endregion

        #region ---默认构造函数---
        public L_ShowHelpInfo()
        { 
            
        }
        #endregion

        #region ---自己写的构造函数---
        public L_ShowHelpInfo(int HelpID, string HelpTitle, int ClassID, string ClassName,
            string parentIDRoute, string parentNameRoute, string helpContent,
            DateTime PostTime, Int16 isPost)
        {
            this._helpid = HelpID;
            this._helptitle = HelpTitle;
            this._classid = ClassID;
            this._classname = ClassName;
            this._parentidroute = parentIDRoute;
            this._parentnameroute = parentNameRoute;
            this._helpContent = helpContent;
            this._posttime = PostTime;
            this._isPost = isPost;
        }
        #endregion
    }
}
