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
    public class longyuan_AcceptAddr
    {
        public int InsertAcceptAddr(L_AcceptAddrInfo acceptinfo)
        {
            SqlParameter[] param = new SqlParameter[15];
            param[0] = new SqlParameter("@userID", acceptinfo.UserID);
            param[1]=new SqlParameter("@realityName",acceptinfo.RealityName);
            param[2]=new SqlParameter("@rowAddr",acceptinfo.RowAddr);
            param[3]=new SqlParameter("@provinceID",acceptinfo.ProvinceID);
            param[4]=new SqlParameter("@province",acceptinfo.Province);
            param[5]=new SqlParameter("@cityID",acceptinfo.CityID);
            param[6]=new SqlParameter("@city",acceptinfo.City);
            param[7]=new SqlParameter("@countryID",acceptinfo.CountryID);
            param[8]=new SqlParameter("@country",acceptinfo.Country);
            param[9]=new SqlParameter("@tel",acceptinfo.Tel);
            param[10]=new SqlParameter("@handSet",acceptinfo.HandSet);
            param[11]=new SqlParameter("@zipCode",acceptinfo.zipCode);
            param[12]=new SqlParameter("@qqNum",acceptinfo.QQNum);
            param[13]=new SqlParameter("@postTime",acceptinfo.PostTime);
            param[14]=new SqlParameter("@result",SqlDbType.Int);
            param[14].Direction=ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"P_AcceptAddrInsert",param);

            return Int32.Parse(param[14].Value.ToString());
        }

        public L_AcceptAddrInfo GetBindUpdateAcceptAddr(int id, int userID)
        {
            L_AcceptAddrInfo acceptaddrinfo = null;
            string sqlStr = "Select * from AcceptAddr where id=" + id + " and userID=" + userID;
            DataSet set = SqlHelper.ExecuteDateSet(CommandType.Text, sqlStr, null);

            if (set.Tables[0].Rows.Count > 0)
            {
                DataRow drv = set.Tables[0].Rows[0];
                acceptaddrinfo = new L_AcceptAddrInfo(
                        Int32.Parse(drv["id"].ToString()),
                        Int32.Parse(drv["userID"].ToString()),
                        drv["realityName"].ToString(),
                        drv["rowAddr"].ToString(),
                        Int32.Parse(drv["provinceID"].ToString()),
                        drv["province"].ToString(),
                        Int32.Parse(drv["cityID"].ToString()),
                        drv["city"].ToString(),
                        Int32.Parse(drv["countryID"].ToString()),
                        drv["country"].ToString(),
                        drv["tel"].ToString(),
                        drv["handSet"].ToString(),
                        drv["zipCode"].ToString(),
                        drv["qqNum"].ToString(),
                        DateTime.Parse(drv["postTime"].ToString())
                    );
            }
            return acceptaddrinfo;
        }

        public int UpdateAcceptAddr(L_AcceptAddrInfo acceptinfo)
        {
            SqlParameter[] param = new SqlParameter[16];
            param[0] = new SqlParameter("@ID", acceptinfo.ID);
            param[1] = new SqlParameter("@userID", acceptinfo.UserID);
            param[2] = new SqlParameter("@realityName", acceptinfo.RealityName);
            param[3] = new SqlParameter("@rowAddr", acceptinfo.RowAddr);
            param[4] = new SqlParameter("@provinceID", acceptinfo.ProvinceID);
            param[5] = new SqlParameter("@province", acceptinfo.Province);
            param[6] = new SqlParameter("@cityID", acceptinfo.CityID);
            param[7] = new SqlParameter("@city", acceptinfo.City);
            param[8] = new SqlParameter("@countryID", acceptinfo.CountryID);
            param[9] = new SqlParameter("@country", acceptinfo.Country);
            param[10] = new SqlParameter("@tel", acceptinfo.Tel);
            param[11] = new SqlParameter("@handSet", acceptinfo.HandSet);
            param[12] = new SqlParameter("@zipCode", acceptinfo.zipCode);
            param[13] = new SqlParameter("@qqNum", acceptinfo.QQNum);
            param[14] = new SqlParameter("@postTime", acceptinfo.PostTime);
            param[15] = new SqlParameter("@result", SqlDbType.Int);
            param[15].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "P_AcceptAddrUpdate", param);

            return Int32.Parse(param[15].Value.ToString());
        }
    }
}
