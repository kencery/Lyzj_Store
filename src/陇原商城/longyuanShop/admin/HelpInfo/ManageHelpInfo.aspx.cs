using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using Model;
using BLL;
using System.Data;

public partial class admin_HelpInfo_ManageHelpInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            if (!IsPostBack)
            {
                BindHelpInfo();
            }
        }
    }
    private void BindHelpInfo()
    {
        int currPage = WebUnitily.CheckInt(Request["p"]);
        if (currPage == 0)
        {
            currPage = 1;
        }
        L_PageList pl = new L_PageList();
        pl.Currpage = currPage;
        pl.PageSize = 10;
        pList8517.CurPage = currPage;

        pl.TableName = "ShopHelp";
        pl.PKey = "helpID";
        pl.FieldList = "helpID,helpTitle,classID,className,helpContent,postTime,isPost";
        pl.OrderBy = "postTime desc";

        longyuan_TableUpDateFieldsInfo tb = new longyuan_TableUpDateFieldsInfo();
        DataSet dsSet = tb.GetPageList(pl);
        if (dsSet.Tables.Count > 0)
        {
            if (dsSet.Tables[0].Rows.Count > 0)
            {
                gvHelpInfo.DataSource = dsSet.Tables[0];
                gvHelpInfo.DataKeyNames = new string[] { "helpID" };
                gvHelpInfo.DataBind();

                pList8517.TotalPage = Int32.Parse(tb.PageCount.ToString());
            }
            else
            {
                gvHelpInfo.DataBind();
            }
        }
        else
        {
            gvHelpInfo.DataBind();
        }
    }

    protected void gvHelpInfo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView set = (DataRowView)e.Row.DataItem;
            Label lbState = (Label)e.Row.FindControl("lbState");
            int isPost = Int32.Parse(set.Row["isPost"].ToString());
            if (isPost == 1)
            {
                lbState.Text = "显示";
            }
            else
            {
                lbState.Text = "<font color='red'>隐藏</font>";
            }
        }
    }

    protected void btnDeleteHelp_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择您要操作的数据"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().Deleteproject("ShopHelp", " and helpID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("删除网站帮助信息已经成功了哦！"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("删除网站帮助信息失败，请您检查！"));
        }
        BindHelpInfo();
    }

    protected void btnShowHelp_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择您要操作的数据"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("ShopHelp", "isPost=1", " and isPost=0 and helpID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的项目设置成功"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的项目设置失败"));
        }
        BindHelpInfo();
    }

    protected void btnCoverHelp_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择您要操作的数据"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("ShopHelp", "isPost=0", " and isPost=1 and helpID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的项目设置成功"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的项目设置失败"));
        }
        BindHelpInfo();
    }

}
