using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;

public partial class user_UserLogin : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        linkReset.Attributes.Add("onclick", "if(Confirm('您确认是否退出本系统吗？')){ window.close();} else{return false}");
    }

    protected void ibtnlogin_Click(object sender, ImageClickEventArgs e)
    {
        string LoginName, userPwd, userIP, loginResult;
        Int32 LoginType;
        string codeValue = txtCodeNum.Text.Trim().ToLower();
        if (Session["validateNum"].ToString().ToLower() != codeValue)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您的验证码有误，请重新输入！');</script>");
        }
        else
        {
            userPwd = Stringhelp.MD5String(txtPassword.Text.Trim());
            LoginType = Int32.Parse(ddlLoginType.SelectedValue);
            userIP = Stringhelp.GetClientUp();
            switch (LoginType)
            {
                case 1:
                    LoginName = txtUserName.Text.Trim();
                    break;
                case 2:
                    LoginName = txtUserName.Text.Trim();
                    break;
                default:
                    LoginName = txtUserName.Text.Trim();
                    break;
            }


            loginResult = Loginhelp.GetUserLogin(LoginName, userPwd, LoginType, userIP);
            if (string.IsNullOrEmpty(loginResult))
            {
                string gotoUrl = txtbackUrl.Text.Trim();
                if (gotoUrl == "")
                {
                    Response.Redirect("~/proscenium/Index.aspx", true);
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("登录成功！", gotoUrl));
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("登录失败，原因是：" + loginResult + "!"));
            }

        }
        this.txtCodeNum.Text = "";
        this.txtUserName.Text = "";
    }

    protected void linkReset_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript(" ", " <script   LANGUAGE=JavaScript   > " +"window.parent.opener=null;window.parent.close(); " + " </script> ");
    }
}
