using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using System.Data.SqlClient;
using DBUtility;
using System.Data;

namespace DAL
{
    public class longyuan_orderLog
    {
        public int InsertOrderLog(L_OrderLogInfo orderloginfo)
        {
            SqlParameter[] param = new SqlParameter[7];
            param[0]=new SqlParameter("@orderID",orderloginfo.OrderID);
            param[1]=new SqlParameter("@operateUserID",orderloginfo.OperateUserID);
            param[2]=new SqlParameter("@userType",orderloginfo.UserType);
            param[3]=new SqlParameter("@operateType",orderloginfo.OperateType);
            param[4]=new SqlParameter("@clientIP",orderloginfo.ClientIP);
            param[5]=new SqlParameter("@operateDepict",orderloginfo.OperateDepict);
            param[6]=new SqlParameter("@operateTime",orderloginfo.OperateTime);

            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_orderLogUpdate", param);
        }
    }
}
