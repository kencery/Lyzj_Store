using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DAL;
using Model;

namespace BLL
{
    public class longyuan_TableUpDateFieldsInfo
    {
        longyuan_TableUpDateFields shop = new longyuan_TableUpDateFields();

        public int RecordCount
        {
            get { return shop.RecordCount; }
        }

        public int PageCount
        {
            get { return shop.PageCount; }
        }

        public DataSet GetPageList(L_PageList pl)
        {
            return shop.GetPageList(pl);
        }

        public DataSet getDeleteShop(string sqlStr)
        {
            return shop.getDeleteShop(sqlStr);
        }

        public int Deleteproject(string tablename, string conditions)
        {
            return shop.Deleteproject(tablename, conditions);
        }

        public int UpdateShoping(string tablename, string upDateFields, string conditions)
        {
            return shop.UpdateShoping(tablename, upDateFields, conditions);
        }

        public DataSet GetBindAddr(string sqlStr)
        {
            return shop.GetBindAddr(sqlStr);
        }
    }
}
