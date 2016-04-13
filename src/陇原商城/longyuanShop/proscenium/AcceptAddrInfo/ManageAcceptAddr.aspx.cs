using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using System.Data;
using BLL;

public partial class proscenium_AcceptAddrInfo_ManageAcceptAddr : System.Web.UI.Page
{
    private int userID;

    longyuan_TableUpDateFieldsInfo table = new longyuan_TableUpDateFieldsInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckUserLogin("-1"))
        {
            userID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517User", "userID"));
            if (!IsPostBack)
            {
                BindAcceptAddr();
            }
        }
    }

    private void BindAcceptAddr()
    {
        string SqlStr = "select id,realityName,rowAddr,province,city,country,handset,qqNum,postTime from acceptAddr where userID=" + userID;
        DataSet set = table.GetBindAddr(SqlStr);
        if (set.Tables[0].Rows.Count > 0)
        {
            gvDataListBindAccept.DataSource = set.Tables[0];
            gvDataListBindAccept.DataBind();
        }
        else
        {
            gvDataListBindAccept.DataBind();
        }
    }

    protected void gvDataListBindAccept_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView dset = (DataRowView)e.Row.DataItem;
            Label lbDetailsAddr = (Label)e.Row.FindControl("lbDetailsAddr");
            lbDetailsAddr.Text = dset.Row["province"].ToString() + dset.Row["city"].ToString() + dset.Row["country"].ToString() + dset.Row["rowAddr"].ToString();
        }
    }

    protected void gvDataListBindAccept_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvDataListBindAccept.PageIndex = e.NewPageIndex;
        BindAcceptAddr();
    }

    protected void btnDel_Click(object sender, EventArgs e)
    {
        string strID = "";
        if (Request["cbName"] != null)
        {
            strID = Request["cbName"];
        }
        if (strID.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择你所要操作的数据"));
            return;
        }
        string conditionStr = " and userID=" + userID + " and id in(" + strID + ")";
        if (table.Deleteproject("AcceptAddr", conditionStr) > 0)
        {
            BindAcceptAddr();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("删除收货地址成功"));
            return;
        }
        else
        {
            BindAcceptAddr();
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("删除收货地址失败"));
            return;
        }
    }
}
