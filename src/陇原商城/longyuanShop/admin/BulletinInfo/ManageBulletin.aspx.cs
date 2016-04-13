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

public partial class admin_BulletinInfo_ManageBulletin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            if (!IsPostBack)
            {
                BindBulletin();
            }
        }
    }

    private void BindBulletin()
    {
        int currPage = WebUnitily.CheckInt(Request["p"]);
        if (currPage == 0)
        {
            currPage = 1;
        }
        L_PageList pl = new L_PageList();
        pl.Currpage = currPage;

        pl.PageSize = 2;
        pList8517.CurPage = currPage;
        pl.TableName = "Bulletin";
        pl.PKey = "ID";
        pl.FieldList = "ID,bulletinTitle,bulletinContent,isPost,orderNum,postTime";
        pl.OrderBy = "postTime desc";

        longyuan_TableUpDateFieldsInfo tb = new longyuan_TableUpDateFieldsInfo();
        DataSet Dset = tb.GetPageList(pl);
        if (Dset.Tables.Count > 0)
        {
            if (Dset.Tables[0].Rows.Count > 0)
            {
                gvBulletin.DataSource = Dset.Tables[0];
                gvBulletin.DataKeyNames = new string[] { "ID" };
                gvBulletin.DataBind();

                pList8517.TotalPage = int.Parse(tb.PageCount.ToString());
            }
            else
            {
                gvBulletin.DataBind();
            }
        }
    }

    protected void gvBulletin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView set = (DataRowView)e.Row.DataItem;
            Label lbState = (Label)e.Row.FindControl("lbState");
            int isPost = Int16.Parse(set.Row["isPost"].ToString());
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

    protected void btnDel_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择您要操作的数据"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().Deleteproject("Bulletin", " and ID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("删除网站公告信息已经成功了哦！"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("删除网站公告信息失败，请您检查！"));
        }
        BindBulletin();
    }

    protected void btnIsPost_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择您要操作的数据"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("Bulletin", "isPost=1", " and isPost=0 and ID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的项目设置成功"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的项目设置失败"));
        }
        BindBulletin();
    }
    protected void btnNotIsPost_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择您要操作的数据"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("Bulletin", "isPost=0 ", " and isPost=1 and ID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的项目设置成功"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的项目设置失败"));
        }
        BindBulletin();
    }
}
