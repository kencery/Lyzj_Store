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
    public class longyuan_Help
    {
        public int AddHelpInfo(L_ShowHelpInfo helpinfo)
        {
            StringBuilder sqlStr = new StringBuilder();
            SqlParameter[] param = new SqlParameter[8];
            param[0] = new SqlParameter("@helpTitle", helpinfo.HelpTitle);
            param[1] = new SqlParameter("@classID", helpinfo.ClassID);
            param[2] = new SqlParameter("@className", helpinfo.ClassName);
            param[3] = new SqlParameter("@parentIDRoute", helpinfo.ParentIDRoute);
            param[4] = new SqlParameter("@parentNameRoute", helpinfo.ParentNameRoute);
            param[5] = new SqlParameter("@helpContent", helpinfo.HelpCntent);
            param[6] = new SqlParameter("@postTime", helpinfo.PostTime);
            param[7] = new SqlParameter("isPost", helpinfo.IsPost);

            sqlStr.Append("Insert Into ShopHelp(");
            sqlStr.Append("helpTitle,classID,className,parentIDRoute,parentNameRoute,helpContent,postTime,isPost)");
            sqlStr.Append("values(");
            sqlStr.Append("@helpTitle,@classID,@className,@parentIDRoute,@parentNameRoute,@helpContent,@postTime,@isPost)");

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlStr.ToString(), param);
        }

        public L_ShowHelpInfo GetBindHelp(int HelpID)
        {

            L_ShowHelpInfo shopinfo = null;
            string sqlstr = "";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@helpID", HelpID);

            sqlstr = "Select * from ShopHelp where helpID=@helpID";

            DataSet dSet = SqlHelper.ExecuteDateSet(CommandType.Text, sqlstr, param);
            if (dSet.Tables[0].Rows.Count > 0)
            {
                DataRow drv = dSet.Tables[0].Rows[0];
                shopinfo = new L_ShowHelpInfo(
                        Int32.Parse(drv["helpID"].ToString()),
                        drv["helpTitle"].ToString(),
                        Int32.Parse(drv["classID"].ToString()),
                        drv["className"].ToString(),
                        drv["parentIDRoute"].ToString(),
                        drv["parentNameRoute"].ToString(),
                        drv["helpContent"].ToString(),
                        DateTime.Parse(drv["postTime"].ToString()),
                        Int16.Parse(drv["isPost"].ToString())
                    );
            }
            return shopinfo;
        }

        public int UpdateHelpInfo(L_ShowHelpInfo helpinfo)
        {
            StringBuilder sqlStr = new StringBuilder();
            SqlParameter[] param = new SqlParameter[9];
            param[0] = new SqlParameter("@helpID", helpinfo.HelpID);
            param[1] = new SqlParameter("@helpTitle", helpinfo.HelpTitle);
            param[2] = new SqlParameter("@classID", helpinfo.ClassID);
            param[3] = new SqlParameter("@className", helpinfo.ClassName);
            param[4] = new SqlParameter("@parentIDRoute", helpinfo.ParentIDRoute);
            param[5] = new SqlParameter("@parentNameRoute", helpinfo.ParentNameRoute);
            param[6] = new SqlParameter("@helpContent", helpinfo.HelpCntent);
            param[7] = new SqlParameter("@postTime", helpinfo.PostTime);
            param[8] = new SqlParameter("@isPost", helpinfo.IsPost);

            sqlStr.Append("Update ShopHelp Set ");
            sqlStr.Append("helpTitle=@helpTitle,classID=@classID,className=@className,parentIDRoute=@parentIDRoute,parentNameRoute=@parentNameRoute,helpContent=@helpContent,postTime=@postTime,isPost=@isPost");
            sqlStr.Append(" Where helpID=@helpID");

            return SqlHelper.ExecuteNonQuery(CommandType.Text, sqlStr.ToString(), param);
        }
    }
}
