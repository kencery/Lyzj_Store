using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 为了实现管理商品分组操作数据库的中作用
    /// </summary>
    public class L_PageList
    {
        private Int32 _currpage = -1;
        private Int32 _recordcount = -1;
        private Int32 _pageSize = 10;
        private Int32 _pagecount = 0;

        private String _tablename = "";
        private String _fieldlist = "*";
        private String _condition = " where 1=1";
        private String _pkey = "Id";
        private String _orderby = null;
        private String _sql = "";
        private String _sqlgetrc = "";

        public L_PageList()
        { 
            
        }

        public Int32 Currpage
        {
            get { return this._currpage; }
            set { 
                if(value<1)
                {
                    value=1;
                }
                this._currpage = value;
            }
        }

        public Int32 RecordCount
        {
            get { return this._recordcount; }
            set { this._recordcount = value; }
        }

        public Int32 PageSize
        {
            get { return this._pageSize; }
            set { this._pageSize = value; }
        }

        public Int32 PageCount
        {
            get { return this._pagecount; }
            set { this._pagecount = value; }
        }

        public String TableName
        {
            get { return this._tablename; }
            set { this._tablename = value; }
        }

        public String FieldList
        {
            get { return this._fieldlist; }
            set { this._fieldlist = value; }
        }

        public String Conditon
        {
            get
            {
                if (this._condition == " where 1=1")
                    return "";
                else
                    return this._condition;
            }
            set { this._condition += value; }
        }

        public String PKey
        {
            get { return this._pkey; }
            set { this._pkey = value; }
        }

        public String OrderBy
        {
            get
            {
                if (this._orderby == null)
                    return " Order By " + this._pkey;
                else
                    return this._orderby;
            }
            set { this._orderby = "Order By " + value; }
        }

        public String Sql
        {
            get { return this._sql; }
            set { this._sql = value; }
        }

        public String SqlGetRc
        {
            get { return this._sqlgetrc; }
            set { this._sqlgetrc = value; }
        }
    }
}
