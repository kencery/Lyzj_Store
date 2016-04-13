using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using DBUtility;

public partial class admin_HelpInfo_AddHelper : System.Web.UI.Page
{ 
    longyuan_HelpInfo help = new longyuan_HelpInfo();

    private int helpID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["helpID"] != null && Request.QueryString["helpID"] != "")
                {
                    helpID = Int32.Parse(Request.QueryString["helpID"]);
                    lblShow.Text = "修改网站帮助信息";
                    btnAddHelp.Visible = false;
                    btnUpdateHelp.Visible = true;
                    BindUpdateHelp();
                }
                else
                {
                    lblShow.Text = "添加网站帮助信息";
                    btnAddHelp.Visible = true;
                    btnUpdateHelp.Visible = false;
                }
            }
        }
    }


    private void BindUpdateHelp()
    {
        L_ShowHelpInfo helpinfo = help.GetBindHelp(helpID);
        if (helpinfo == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("帮助主题不存在，请您重新选择！"));
        }
        txtHelpTitle.Text = helpinfo.HelpTitle;
        txtContent.Text = helpinfo.HelpCntent;
    }

    protected void btnAddHelp_Click(object sender, EventArgs e)
    {
        L_ShowHelpInfo helpinfo = new L_ShowHelpInfo();
        helpinfo.HelpTitle = txtHelpTitle.Text.Trim();
        helpinfo.ClassID = ddlhelpClassName.SelectedIndex;
        helpinfo.ClassName = ddlhelpClassName.SelectedItem.ToString();
        helpinfo.HelpCntent = txtContent.Text.Trim();
        helpinfo.ParentIDRoute = "1";
        helpinfo.ParentNameRoute = "买家帮助";
        helpinfo.PostTime = DateTime.Now;
        helpinfo.IsPost = 1;

        if (help.AddHelpInfo(helpinfo) == 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("添加网站帮助成功！"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("添加网站帮助失败，请您检查！"));
        }
        txtHelpTitle.Text = "";
        txtContent.Text = "";
    }

    protected void btnUpdateHelp_Click(object sender, EventArgs e)
    {
        L_ShowHelpInfo helpinfo = new L_ShowHelpInfo();
        helpinfo.HelpTitle = txtHelpTitle.Text.Trim();
        helpinfo.ClassID = ddlhelpClassName.SelectedIndex;
        helpinfo.ClassName = ddlhelpClassName.SelectedItem.ToString();
        helpinfo.HelpCntent = txtContent.Text.Trim();
        helpinfo.ParentIDRoute = "1";
        helpinfo.ParentNameRoute = "买家帮助";
        helpinfo.PostTime = DateTime.Now;
        helpinfo.IsPost = 1;

        helpinfo.HelpID = Int32.Parse(Request.QueryString["helpID"]);
        if (help.ModifyHelpInfo(helpinfo) == 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("修改网站帮助成功！", "ManageHelpInfo.aspx"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("修改网站帮助失败！"));
        }
    }

    protected void btnRegest_Click(object sender, EventArgs e)
    {
        txtHelpTitle.Text = "";
        txtContent.Text = "";
    }

}
