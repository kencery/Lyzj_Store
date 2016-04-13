using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class admin_AdminInfo_AddAdminInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            if (!this.IsPostBack)
            {
                btnAddAdmin.Attributes.Add("onclick", "return jsCheck();");
            }
        }
    }
    protected void btnAddAdmin_Click(object sender, EventArgs e)
    {
        L_AdminInfo admininfo = new L_AdminInfo();
        admininfo.AdminName = txtAdminName.Text.Trim();
        admininfo.AdminPwd = Stringhelp.MD5String(txtAdminPwd.Text.Trim());
        admininfo.AdminType = Int16.Parse(ddlAdminType.SelectedValue);
        admininfo.AdminGroupID = 0;
        admininfo.LastLoginIP = Stringhelp.GetClientUp();
        admininfo.LastLoginTime = Convert.ToDateTime(DateTime.Now.ToString());
        admininfo.IsEnabled = 1;

        int result = new longyuan_AdminInfo().Insert(admininfo);

        switch (result)
        {
            case 1:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('管理员添加成功！');</script>");
                break;
            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('该管理员已经存在，请重新输入！');</script>");
                break;
            default:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('管理员添加失败，请检查');</script>");
                break;
        }
        txtAdminName.Text = "";
    }
}
