using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;
using System.Data;

namespace BLL
{
    public class longyuan_AdminInfo
    {
        longyuan_Admin admin = new longyuan_Admin();

        public int Insert(L_AdminInfo adminInfo)
        {
            return admin.InsertAdmin(adminInfo);
        }

        public DataSet GetBindAdmin(string sqlstr)
        {
            return admin.GetDataAdmin(sqlstr);
        }

        public int DeleteAdmin(string adminID)
        {
            return admin.DeleteAdmin(adminID);
        }

        public L_AdminInfo LoginAdmin(string adminName, string adminPwd, string adminIP)
        {
            return admin.LoginAdmin(adminName, adminPwd, adminIP);
        }

    }
}
