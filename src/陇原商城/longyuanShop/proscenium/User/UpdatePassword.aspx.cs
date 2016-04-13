using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DBUtility;

public partial class proscenium_User_UpdatePassword : System.Web.UI.Page
{
    longyuan_userInfo user = new longyuan_userInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckUserLogin("-1"))
        {
            if (!IsPostBack)
            {
                lblUserName.Text = "hyl";
            }
        }
    }
    protected void btnOK_Click(object sender, EventArgs e)
    {
        if (user.ChangePwd(lblUserName.Text.Trim(), Stringhelp.MD5String(txtNewPwd.Text.Trim()), Stringhelp.MD5String(txtOldPwd.Text.Trim())) > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("用户修改密码成功，请您重新登录", "../../user/UserLogin.aspx"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("用户修改密码失败"));
        }
    }
}
