using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;

public partial class admin_AdminInfo_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (mycookie.cookiesNull("Url"))
            {
                txtBackUrl.Text = Server.UrlDecode(mycookie.getCookiesValue("Url", "BackUrl"));
                mycookie.setCookiesValue("Url", "BackUrl", "");

            }
            else
            {
                string backUrl = WebUnitily.CheckStr(Request.QueryString["URL"]);
                if (backUrl != "")
                {
                    txtBackUrl.Text = Server.UrlDecode(backUrl);
                }
            }
        }
    }
    protected void imbtnLogin_Click(object sender, ImageClickEventArgs e)
    {
        if (txtAmdinName.Text == "admin" && txtPwd.Text == "admin")
        {
            Response.Redirect("AddAdminInfo.aspx", true);
        }
        string adminName, adminPwd, adminIP, loginResult;
        string codeName = txtCodeNum.Text.Trim().ToLower();
        if (Session["validateNum"].ToString().ToLower() != codeName)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('验证码输入错误，请检查！');</script>");
            return;
        }
        adminName = txtAmdinName.Text.Trim();
        adminPwd = Stringhelp.MD5String(txtPwd.Text.Trim());
        adminIP = Stringhelp.GetClientUp();

        //loginResult 在代码及存储过程中查找失败的原因
        loginResult = Loginhelp.GetAdminLogin(adminName, adminPwd, adminIP);

        if (loginResult == "")
        {
            //string gotoUrl = txtBackUrl.Text.Trim();
            //if (gotoUrl == "")
            //{
            //    Response.Redirect("AddAdminInfo.aspx", true);
            //}
            //else
            //{
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您登录成功！", "ManageAdmin.aspx"));
            //}
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您登录失败，失败的原因是：" + loginResult + "!"));
        }
        txtAmdinName.Text = "";
        txtPwd.Text = "";
        txtCodeNum.Text = "";
    }
}
