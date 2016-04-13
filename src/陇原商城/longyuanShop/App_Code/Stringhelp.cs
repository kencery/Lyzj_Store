using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;  //
using System.Text;  //

/// <summary>
///网站帮助类
/// </summary>
public class Stringhelp
{
    public Stringhelp()
    {
        //
        //TODO: 在此处添加构造函数逻辑
        //
    }

    public static string MD5String(string input)
    {
        MD5 md5hasher = MD5.Create();   //创建哈希算法
        byte[] date = md5hasher.ComputeHash(Encoding.Default.GetBytes(input));
        StringBuilder stringbuilder = new StringBuilder();
        for (int i = 0; i < date.Length; i++)
        {
            stringbuilder.Append(date[i].ToString("x2"));
        }
        return stringbuilder.ToString();
    }

    public static string GetClientUp()
    {
        string result;
        if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)  //判断是否设置了代理
        {
            result = "代理IP";
        }
        else
        {
            result = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
        }
        return result;
    }
}
