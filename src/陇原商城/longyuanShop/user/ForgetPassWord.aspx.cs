using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;

public partial class user_ForgetPassWord : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
        }
    }

    protected void btnzhaohuiPassword_Click(object sender, EventArgs e)
    {
        //List<Users> li = UserFunction.ExistUser(txtUserName.Text.Trim());
        //if (li.Count == 0)
        //{
        //    ClientScriptManager cs = ((Page)HttpContext.Current.CurrentHandler).ClientScript;
        //    cs.RegisterClientScriptBlock(this.GetType(), "divError", "<script type=\"text/javascript\">$(document).ready(function(){$.XYTipsWindow({___title:\"&nbsp;&nbsp;&nbsp;<span style='font-size:14px;'>系统提示</span>\",___content:\"text:</br></br></br></br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='font-size:14px;'>对不起，您所填写的信箱与该会员的联系信箱不符！!</span>\",___width:\"411\",___height:\"194\",___dray:\"___boxTitle\",___time:\"3000\",___showbg:true});});</script>");
        //}
        //else
        //{
        //    if (txtEmail.Text.Trim() != li[0].Email)
        //    {
        //        ClientScriptManager cs = ((Page)HttpContext.Current.CurrentHandler).ClientScript;
        //        cs.RegisterClientScriptBlock(this.GetType(), "divError", "<script type=\"text/javascript\">$(document).ready(function(){$.XYTipsWindow({___title:\"&nbsp;&nbsp;&nbsp;<span style='font-size:14px;'>系统提示</span>\",___content:\"text:</br></br></br></br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='font-size:14px;'>对不起，您所填写的信箱与该会员的联系信箱不符！</span>\",___width:\"411\",___height:\"194\",___dray:\"___boxTitle\",___time:\"3000\",___showbg:true});});</script>");
        //    }
        //    else
        //    {
        //        if (Common.SendEmailEasy("家教网密码找回", "<p><span style=\"font-size: 16px;\">感谢您使用家教网<br /><br />您已注册了以下的信息:<br /><br />您的电子信箱地址: <a href=\"mailto:757360725@qq.com\" target=\"_blank\">757360725@qq.com</a><br />密码: zxcZXC123<br /><br />如果您从未在家教网上加入过我们从而误收了这封电子邮件，那麽这说明有人试图用您的电子邮箱地址来进行注册。<br /><br />如果是这样的话，您可以不理睬这个邮件。。。 但是，为什么不试试加入我们呢？现在就登录到<a href=\"http://www.dot.tk\" target=\"_blank\">XXXX</a>上看看。<br />希望在家教网上能很快看到您。</span><br />&nbsp;</p>", "757360725@qq.com", "zxc123ZXC", li[0].Email))
        //        {
        //            OperationRecord o = new OperationRecord();
        //            o.UserName = Session["UserName"].ToString();
        //            o.LoginAddress = Common.getIP(this.Context);
        //            o.OperationRecordID = 13;
        //            UserFunction.InsertOperationRecord(o);
        //            ClientScriptManager cs = ((Page)HttpContext.Current.CurrentHandler).ClientScript;
        //            cs.RegisterClientScriptBlock(this.GetType(), "divError", "<script type=\"text/javascript\">$(document).ready(function(){$.XYTipsWindow({___title:\"&nbsp;&nbsp;&nbsp;<span style='font-size:14px;'>系统提示</span>\",___content:\"text:</br></br></br></br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='font-size:14px;'>密码已发送至您的邮箱，请注意查收！</span>\",___width:\"411\",___height:\"194\",___dray:\"___boxTitle\",___time:\"3000\",___showbg:true,___fnd:function(){window.location.href='default.aspx';}});});</script>");
        //        }
        //        else
        //        {
        //            OperationRecord o = new OperationRecord();
        //            o.UserName = Session["UserName"].ToString();
        //            o.LoginAddress = Common.getIP(this.Context);
        //            o.OperationRecordID = 14;
        //            UserFunction.InsertOperationRecord(o);
        //            ClientScriptManager cs = ((Page)HttpContext.Current.CurrentHandler).ClientScript;
        //            cs.RegisterClientScriptBlock(this.GetType(), "divError", "<script type=\"text/javascript\">$(document).ready(function(){$.XYTipsWindow({___title:\"&nbsp;&nbsp;&nbsp;<span style='font-size:14px;'>系统提示</span>\",___content:\"text:</br></br></br></br>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span style='font-size:14px;'>对不起，邮件发送失败，详细信息请联系客服!</span>\",___width:\"411\",___height:\"194\",___dray:\"___boxTitle\",___time:\"3000\",___showbg:true,___fnd:function(){window.location.href='default.aspx';}});});</script>");
        //        }
        //    }
      // }
    }
}