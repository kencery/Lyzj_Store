using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using System.Data;
using DBUtility;

namespace DAL
{
    public class longyuan_Admin
    {
        public int InsertAdmin(L_AdminInfo adminInfo)
        {
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@adminName", adminInfo.AdminName);
            param[1]=new SqlParameter("@adminPwd",adminInfo.AdminPwd);
            param[2]=new SqlParameter("@adminType",adminInfo.AdminType);
            param[3]=new SqlParameter("@adminGroupID",adminInfo.AdminGroupID);
            param[4]=new SqlParameter("@lastLoginIP",adminInfo.LastLoginIP);
            param[5]=new SqlParameter("@lastLoginTime",adminInfo.LastLoginTime);
            param[6]=new SqlParameter("@isEnabled",adminInfo.IsEnabled);
            param[7]=new SqlParameter("@result",SqlDbType.Int);
            param[7].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "P_ReguisterAdmin", param);

            return Int32.Parse(param[7].Value.ToString());
        }

        public DataSet GetDataAdmin(string sqlStr)
        {
            return SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, sqlStr, null);
        }

        public int DeleteAdmin(string adminID)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@adminID", adminID);
            try
            {
                return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_DeleteAdmin", param);
            }
            catch
            {
                return -1;
            }
        }

        public L_AdminInfo LoginAdmin(string adminName, string adminPwd, string adminIP)
        {
            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@adminName", adminName);
            param[1] = new SqlParameter("@adminPwd", adminPwd);
            param[2] = new SqlParameter("@lastLoginIP", adminIP);
            param[3] = new SqlParameter("@error", SqlDbType.VarChar, 50);
            param[3].Direction = ParameterDirection.Output;

            DataSet set = SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "P_AdminLogin", param);

            L_AdminInfo admininfo = new L_AdminInfo();
            if (set.Tables.Count == 2)
            {
                if (set.Tables[1].Rows.Count > 0)
                {
                    DataRow drv = set.Tables[1].Rows[0];
                    admininfo.AdminID = Convert.ToInt32(drv["adminID"]);
                    admininfo.AdminName = drv["adminName"].ToString();
                    admininfo.AdminType = Convert.ToInt16(drv["adminType"].ToString());
                }
            }
            admininfo.Message = param[3].Value.ToString();
            return admininfo;
        }
    }
}
