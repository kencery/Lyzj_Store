using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace DBUtility
{
    public static class WebUnitily
    {
        public static string CheckStr(String text)
        {
            if (text == null || text == "")
            {
                return "";
            }
            else
            {
                text = text.Replace(">", "");
                text = text.Replace("<", "");
                text = text.Replace("'", "&#39;");
                return text;
            }
        }

        public static string AlertUrl(string Message)
        {
            string js = "<script language='javascript'>alert('" + Message + "');</script>";
            return js;
        }

        public static string AlertUrl(string Message, string url)
        {
            string js = "<script language='javascript'>alert('" + Message + "');window.location='" + url + "';</script>";
            return js;
        }

        public static string GetName()
        {
            string strTimeNow = "";
            int iRandom;
            long lTimeNow;
            strTimeNow = DateTime.Now.ToString();
            strTimeNow = strTimeNow.Replace("-", "");
            strTimeNow = strTimeNow.Replace(":", "");
            strTimeNow = strTimeNow.Replace("/", "");
            strTimeNow = strTimeNow.Replace(" ", "");
            //创建一个随机数
            Random rand = new Random();
            iRandom = rand.Next(1, 100000);
            lTimeNow = long.Parse(strTimeNow) + iRandom;
            //lTimeNow = Convert.ToInt64(strTimeNow) + iRandom;
            return lTimeNow.ToString();
        }

        public static int CheckInt(string text)
        {
            //此方法的作用是转换整形，把别的各种形式调用此方法则转换为整形
            if (text == null || text == "" || (!IsNumeric(text)))
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(text);
            }
        }

        public static bool IsNumeric(string text)
        {
            try
            {
                int var = Convert.ToInt32(text);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static int CheckInt(object obj)
        {
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return CheckInt(obj.ToString());
            }
        }

        public static decimal CheckMoney(string text)
        {
            if (text == null || text == "")
            {
                return 0;
            }
            else
            {
                try
                {
                    return Convert.ToDecimal(text);
                }
                catch
                {
                    return 0;
                }
            }
        }

        /// <summary>
        /// 邮件单一发送获取用户的密码
        /// </summary>
        /// <param name="subject">主题</param>
        /// <param name="bodyContent">内容</param>
        /// <param name="mailfrom">发件邮箱地址</param>
        /// <param name="pwd">发件邮箱密码</param>
        /// <param name="mailto">收件人邮箱地址</param>
        /// <returns></returns>
        public static bool SendEmailEasy(string subject, string bodyContent, string mailfrom, string pwd, string mailto)
        {
            MailAddress from = new MailAddress(mailfrom);
            MailAddress to = new MailAddress(mailto);
            MailMessage mailObj = new MailMessage(from, to);
            mailObj.Subject = subject;    //主题
            mailObj.IsBodyHtml = true;
            mailObj.Body = bodyContent;
            mailObj.BodyEncoding = System.Text.Encoding.UTF8;
            mailObj.SubjectEncoding = System.Text.Encoding.UTF8;
            SmtpClient smtp = new SmtpClient();
            try
            {
                smtp.Host = "smtp.QQ.com";
                smtp.Credentials = new System.Net.NetworkCredential(mailfrom, pwd);
                smtp.Timeout = 1200000;
                mailObj.To.Clear();
                mailObj.To.Add(mailto);
                smtp.Send(mailObj);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                mailObj.Dispose();
            }
        }

    }
}