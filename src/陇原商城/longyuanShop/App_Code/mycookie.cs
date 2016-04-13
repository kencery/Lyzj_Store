using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///mycookie 的摘要说明
/// </summary>
public class mycookie
{
    public mycookie()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static bool cookiesNull(string cookiename)
    {
        HttpCookie cookiesnull = HttpContext.Current.Request.Cookies[cookiename];
        if (cookiesnull == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static string getCookiesValue(string cookieName, string cookieKeyName)
    {
        HttpCookie cookieIsNull = HttpContext.Current.Request.Cookies[cookieName];
        if (cookieIsNull != null)
        {
            return cookieIsNull.Values[cookieKeyName].ToString();
        }
        else
        {
            return "";
        }
    }
    public static bool setCookiesValue(string cookieName, string cookieKeyName, string cookieValue)
    {
        HttpCookie cookieIsNull = HttpContext.Current.Request.Cookies[cookieName];
        if (cookieIsNull != null)
        {
            cookieIsNull.Values[cookieKeyName] = cookieValue;
            HttpContext.Current.Response.AppendCookie(cookieIsNull);

            return true;
        }
        else
        {
            return false;
        }
    }
}
