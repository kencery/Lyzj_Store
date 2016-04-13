using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using Model;

/// <summary>
///Loginhelp 的摘要说明
/// </summary>
public class Loginhelp
{

    public Loginhelp()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static string GetUserLogin(string LoginName, string userPwd, int userType, string userIP)
    {
        longyuan_userInfo user = new longyuan_userInfo();
        L_UserAccountInfo userinfo = user.LoginUser(LoginName, userPwd, userType, userIP);
        if (userinfo == null)
        {
            return "用户不存在!!";
        }
        else
        {
            if (string.IsNullOrEmpty(userinfo.Message))
            {
                HttpContext.Current.Session["shop8517User"] = userinfo.Userid.ToString();
                HttpCookie newcookie = new HttpCookie("shop8517User");
                newcookie.Values["userID"] = userinfo.Userid.ToString();
                newcookie.Values["userName"] = HttpContext.Current.Server.UrlEncode(userinfo.Username);
                newcookie.Values["email"] = userinfo.Email;
                newcookie.Values["userType"] = userinfo.Usertype.ToString();
                newcookie.Values["userCartNum"] = "";  //订单编号
                newcookie.Path = "/";
                HttpContext.Current.Response.AppendCookie(newcookie);
                return "";
            }
            else
            {
                return userinfo.Message;
            }
        }

    }

    public static string GetAdminLogin(string adminName, string adminPwd, string adminIP)
    {
        L_AdminInfo admininfo = new longyuan_AdminInfo().LoginAdmin(adminName,adminPwd,adminIP);

        if (admininfo == null)
        {
            return "用户不存在";
        }
        else
        {
            if (string.IsNullOrEmpty(admininfo.Message))
            {
                HttpContext.Current.Session["shop8517Admin"] = admininfo.AdminID.ToString();
                HttpCookie newcookie = new HttpCookie("shop8517Admin");
                newcookie.Values["adminID"] = admininfo.AdminID.ToString();
                newcookie.Values["adminName"] = admininfo.AdminName;
                newcookie.Values["adminType"] = admininfo.AdminType.ToString();
                newcookie.Path = "/";
                HttpContext.Current.Response.AppendCookie(newcookie);
                return "";
            }
            else
            {
                return admininfo.Message;
            }
        }
    }
}
