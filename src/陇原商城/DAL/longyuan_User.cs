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
    public class longyuan_User
    {
        /// <summary>
        /// 实现用户注册信息
        /// </summary>
        /// <param name="userinfo"></param>
        /// <returns>返回所添加的字符差u那个</returns>
        public string RegisterUser(L_UserAccountInfo userinfo)
        {
            SqlParameter[] para = new SqlParameter[14];
            para[0] = new SqlParameter("@nickName", userinfo.Username);
            para[1] = new SqlParameter("@loginPassWord", userinfo.Password);
            para[2] = new SqlParameter("@faceID", userinfo.Headid);
            para[3] = new SqlParameter("@sex", userinfo.Sex);
            para[4] = new SqlParameter("@age", userinfo.Age);
            para[5] = new SqlParameter("@country", userinfo.Country);
            para[6] = new SqlParameter("@provicnce", userinfo.Province);
            para[7] = new SqlParameter("@phone", userinfo.Phone);
            para[8] = new SqlParameter("@mobile", userinfo.Mobile);
            para[9] = new SqlParameter("@email", userinfo.Email);
            para[10] = new SqlParameter("@qq", userinfo.QQ);
            para[11] = new SqlParameter("@note", userinfo.Note);
            para[12] = new SqlParameter("@userID", SqlDbType.Int);
            para[12].Direction = ParameterDirection.Output;
            para[13] = new SqlParameter("@error", SqlDbType.Int);
            para[13].Direction = ParameterDirection.Output;

            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_RegisterUserLogin", para);
            if (para[13].Value.ToString() == "0")
            {
                return userinfo.Username.ToString();
            }
            else
            {
                return string.Empty;
            }
        }

        public L_UserAccountInfo LoginUser(string LoginName, string userPwd, int userType, string userIP)
        {
            SqlParameter[] param = new SqlParameter[5];
            param[0] = new SqlParameter("@nickName", LoginName);
            param[1] = new SqlParameter("@loginPassWord", userPwd);
            param[2] = new SqlParameter("@lastLoginIP", userIP);
            param[3] = new SqlParameter("@userType", userType);
            param[4] = new SqlParameter("@error", SqlDbType.VarChar, 50);
            param[4].Direction = ParameterDirection.Output;

            DataSet set = SqlHelper.ExecuteDateSet(CommandType.StoredProcedure, "p_UserLogin", param);

            L_UserAccountInfo userinfo = new L_UserAccountInfo();
            if (set.Tables.Count == 2)
            {
                if (set.Tables[1].Rows.Count > 0)
                {
                    DataRow drv = set.Tables[1].Rows[0];
                    userinfo.Userid = Convert.ToInt32(drv["userID"]);
                    if (userType == 1)
                    {
                        userinfo.Username = drv["nickName"].ToString();
                    }
                    else
                    {
                        userinfo.Username = drv["email"].ToString();
                    }
                    userinfo.Usertype = Convert.ToInt32(drv["userType"]);
                }
            }
            userinfo.Message = param[4].Value.ToString();
            return userinfo;
        }

        public int ChangePwd(string UserName, string OldPwd, string NewPwd)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@nickName", UserName);
            param[1] = new SqlParameter("@loginPassWord",NewPwd);
            return SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "p_ChangePwd", param);
        }
    }
}