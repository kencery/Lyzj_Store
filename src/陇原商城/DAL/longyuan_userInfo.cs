using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Model;

namespace BLL
{
    public class longyuan_userInfo
    {
        longyuan_User user = new longyuan_User();
        public string RegNewUser(L_UserAccountInfo userinfo)
        {
            return user.RegisterUser(userinfo);
        }
        public L_UserAccountInfo LoginUser(string loginName, string userPwd, int loginType, string userIP)
        {
            return user.LoginUser(loginName, userPwd, loginType, userIP);
        }
    }
}
