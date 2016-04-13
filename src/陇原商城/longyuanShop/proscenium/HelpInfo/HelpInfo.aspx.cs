using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Model;
using DBUtility;
using BLL;

public partial class proscenium_HelpInfo_HelpInfo : System.Web.UI.Page
{
    protected L_ShowHelpInfo hInfo;
    longyuan_HelpInfo helpinfo = new longyuan_HelpInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int infoID = WebUnitily.CheckInt(Request["helpID"]);
            if (infoID == 0)
            {
                Response.Write(WebUnitily.AlertUrl("请您选择帮助主题", "HelpList.aspx"));
                Response.End();
            }
            BindIndexHelpTitle();
            BindHelpInfo(infoID);
        }

    }

    private void BindHelpInfo(int InfoID)
    {
        hInfo = helpinfo.GetBindHelp(InfoID);
        if (hInfo == null)
        {
            Response.Write(WebUnitily.AlertUrl("您所所选择的帮助信息暂无，请您先看别的吧", "HelpList.aspx"));
        }
    }

    private void BindIndexHelpTitle()
    {
        if (HttpContext.Current.Application["helpInfoList"] != null)
        {
            DataSet ds3 = (DataSet)Application["helpInfoList"];
            ddlBindex.DataSource = ds3.Tables[0];
            ddlBindex.DataBind();
        }
    }
}
