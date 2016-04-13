using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class user_UserRegister : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }
    protected void btnreg_Click(object sender, EventArgs e)
    {
        string validateNumCode = this.txtCode.Text.Trim().ToLower();
        if (Session["validateNum"].ToString().ToLower() == validateNumCode)
        {
            if (cbAccept.Checked == true)
            {
                L_UserAccountInfo userinfo = new L_UserAccountInfo();
                userinfo.Username = txtUserName.Text.Trim();
                userinfo.Password = Stringhelp.MD5String(txtPassword.Text.Trim());
                userinfo.Headid = 0;
                userinfo.Sex = "";
                userinfo.Age = "";
                userinfo.Country = "";
                userinfo.Province = "";
                userinfo.Phone = "";
                userinfo.Mobile = "";
                userinfo.Email = txtEmail.Text.Trim();
                userinfo.QQ = "";
                userinfo.Note = "";
                longyuan_userInfo user = new longyuan_userInfo();
                string userID = "";
                userID = user.RegNewUser(userinfo);
                Response.Redirect("../proscenium/Index.aspx?userID=" + userID, true);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('只有接受陇原网上商城协议用户才能注册');</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('验证码输入错误，请检查！');</script>");
        }
        txtCode.Text = "";
    }
}
