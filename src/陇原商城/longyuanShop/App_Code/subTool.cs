using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DBUtility;
using Model;

/// <summary>
///subTool 的摘要说明
/// </summary>
public class subTool
{
    public subTool()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static bool CheckAdminLogin(string userType)
    {

        HttpCookie newcookie = HttpContext.Current.Request.Cookies["shop8517Admin"];

        if (HttpContext.Current.Session["shop8517Admin"] == null || newcookie == null)
        {
            if (newcookie != null)
            {
                newcookie.Expires = DateTime.Now.AddDays(-1);
            }
            string backUrl = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Url.AbsolutePath.ToString());//登录后返回的URL地址
            HttpCookie cookieUrl = new HttpCookie("Url");
            cookieUrl.Expires = DateTime.Now.AddDays(1);
            cookieUrl.Values["BackUrl"] = backUrl;
            cookieUrl.Path = "/";
            HttpContext.Current.Response.AppendCookie(cookieUrl);

            HttpContext.Current.Response.Write(WebUnitily.AlertUrl("您还没有登录,请先登录!!", "../AdminInfo/AdminLogin.aspx"));
            HttpContext.Current.Response.End();
            return false;
        }
        else
        {
            if (userType == "-1")
            {
                return true;
            }
            if (userType == mycookie.getCookiesValue("shop8517Admin", "AdminType"))
            {
                return true;
            }
            else
            {
                HttpContext.Current.Response.Write(WebUnitily.AlertUrl("您的权限不够!!", "../Default/Default.aspx"));
                HttpContext.Current.Response.End();
                return false;
            }
        }
    }

    public static bool CheckUserLogin(string usertype)
    {
        HttpCookie newcookie = HttpContext.Current.Request.Cookies["shop8517User"];

        if (HttpContext.Current.Session["shop8517User"] == null || newcookie == null)
        {
            if (newcookie != null)
            {
                newcookie.Expires = DateTime.Now.AddDays(-1);
            }
            string backUrl = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Url.AbsolutePath.ToString());  //登陆后返回的URL地址
            HttpCookie cookieUrl = new HttpCookie("Url");  //创建一个新的Cookie
            cookieUrl.Expires = DateTime.Now.AddDays(1);
            cookieUrl.Values["BackUrl"] = backUrl;
            cookieUrl.Path = "/";

            HttpContext.Current.Response.AppendCookie(cookieUrl);
            HttpContext.Current.Response.Write(WebUnitily.AlertUrl("您还没有登录，请您先登录", "../../user/UserLogin.aspx"));
            HttpContext.Current.Response.End();  //清楚缓存
            return false;
        }
        else
        {
            if (usertype == "-1")
            {
                return true;
            }
            if (usertype == mycookie.getCookiesValue("shop8517User", "UserTye"))
            {
                return true;
            }
            else
            {
                HttpContext.Current.Response.Write(WebUnitily.AlertUrl("您的权限不够!!", "../Index.aspx"));
                HttpContext.Current.Response.End();
                return false;
            }
        }
    }

    //订单支付
    public static void userToPay(L_OrderListInfo olistInfo, string moneyTotal)
    {
        //支付网关参数
        string Amount = string.Format("{0:C2}", moneyTotal).Replace("￥", "");			//订单金额
        string Mer_code = System.Configuration.ConfigurationManager.AppSettings["MerchantID"].ToString();	// 6位	商户编号
        string Billno = olistInfo.OrderID;		// 商户订单编号
        string Date = olistInfo.OrderTime.ToString("yyyyMMdd");// 8位 订单日期
        string Currency_Type = "RMB";			//币种
        string Gateway_Type = "01";				//支付卡种
        string Merchanturl = "http://shop.8517.com/OrderInfo/PayResult.aspx";
        string Attach = olistInfo.OrderID + "," + olistInfo.UserID;
        string OrderEncodeType = "0";				// 订单支付接口加密方式 订单支付采用Md5的摘要认证方式
        string RetEncodeType = "12";				// 交易返回采用Md5的摘要认证方式
        string cert = "BjC34p6hPko9f0gXZaxBqGPq7z3L9YIJlNQXbHV7b5oXZg79wLnJomiUuwVfLK7R25yrAiWsfQ9L1Rq1RTzOKY5ZFVCFMPLrXx54IpZnPVExCw23f4oSuJg3ZyCE6r5p";//IPS证书
        string SignMD5 = Billno + Amount + Date + Currency_Type + cert;//Sigmd5=订单号+金额(保留2位小数)+日期+支付币种+IPS证书

        HttpContext.Current.Response.Write("<form name='pareq' method='post'  action='https://pay.ips.com.cn/ipayment.aspx'/>" +
            "<input type='hidden' name='mer_code'  id='mer_code' value='" + Mer_code +
            "'><input type='hidden' name='Billno'id='Billno' value='" + Billno +
            "'><input type='hidden' name='Gateway_type' id='Gateway_type' value='" + Gateway_Type +
            "'><input type='hidden' name='Currency_Type' id='Currency_Type' value='" + Currency_Type +
            "'><input type='hidden' name='amount' id='amount' value='" + Amount +
            "'><input type='hidden' name='date' id='date' value='" + Date +
            "'><input type='hidden' name='attach' id='attach' value='" + Attach +
            "'><input type='hidden' name='OrderEncodeType'  id='OrderEncodeType' value='" + OrderEncodeType +
            "'><input type='hidden' name='RetEncodeType' id='RetEncodeType' value='" + RetEncodeType +
            "'><input type='hidden' name='SignMD5' id='SignMD5'  value='" + SignMD5 +
            "'><input type='hidden' name='Merchanturl' id='Merchanturl' value='" + Merchanturl +
            "'></form><script language=javascript>document.getElementById('pareq').submit();</script>");
    }
}
