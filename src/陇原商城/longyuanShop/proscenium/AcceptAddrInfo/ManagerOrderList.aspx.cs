using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using Model;
using System.Text;
using DBUtility;

public partial class proscenium_AcceptAddrInfo_ManagerOrderList : System.Web.UI.Page
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
                BindIndexOrderListInfo();
            }
        }
    }

    private void BindIndexOrderListInfo()
    {
        StringBuilder sb = new StringBuilder();

        int currPage = WebUnitily.CheckInt(Request["p"]);
        if (currPage == 0)
        {
            currPage = 1;
        }

        L_PageList pl = new L_PageList();
        pl.Currpage = currPage;
        pl.PageSize = 16;
        pList8517.CurPage = currPage;

        pl.TableName = " (OrderList as a Left Join (Select orderID,Sum(memberPrice*discount) as PriceTotal,Sum(freign) as FreightTotal From orderDetail group by orderID) as b On b.orderID=a.orderID) ";
        pl.PKey = " a.orderID ";
        pl.FieldList = " a.orderID,a.userID,isNew,orderState,orderTime,ISNULL(b.PriceTotal,0) as PriceTotal,ISNULL(b.FreightTotal,0) as FreightTotal ";
        pl.Conditon = " and orderState!=10 and userID= " + userID;
        pl.OrderBy = " orderTime Desc ";

        longyuan_TableUpDateFieldsInfo tb = new longyuan_TableUpDateFieldsInfo();
        DataSet dSet = tb.GetPageList(pl);
        if (dSet.Tables.Count > 0)
        {
            if (dSet.Tables[0].Rows.Count > 0)
            {
                gvBindDetails.DataSource = dSet.Tables[0];
                gvBindDetails.DataKeyNames = new string[] { "orderID" };
                gvBindDetails.DataBind();

                pList8517.TotalPage = int.Parse(tb.PageCount.ToString());
            }
            else
            {
                gvBindDetails.DataBind();
            }
        }
        else
        {
            gvBindDetails.DataBind();
        }
    }

    protected void gvBindDetails_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView set = (DataRowView)e.Row.DataItem;
            Label lblOrderState = (Label)e.Row.FindControl("lbOrderState");
            Int16 orderState = Int16.Parse(set.Row["orderState"].ToString());

            switch (orderState)
            {
                case 10:
                    lblOrderState.Text = "等待付款";
                    break;
                case 20:
                    lblOrderState.Text = "已付款，等待发货";
                    break;
                case 30:
                    lblOrderState.Text = "已发货";
                    break;
                case 0:
                    lblOrderState.Text = "订单已取消";
                    break;
                default:
                    lblOrderState.Text = "未知状态";
                    break;
            }

            Label lblorderpt = (Label)e.Row.FindControl("lbOrderPT");

            lblorderpt.Text = string.Format("{0:C2}", decimal.Parse(set.Row["PriceTotal"].ToString()) + decimal.Parse(set.Row["FreightTotal"].ToString()));
        }
    }
    
    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string strID = "";  //验证的ID
        if (Request["cbName"] != null)
        {
            strID = Request["cbName"];
        }
        if (strID.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请你选择你要删除数据"));
            return;
        }

        string conditions = " and userID=" + userID + " and orderID in(" + strID + ")";

        if (table.Deleteproject("OrderList", conditions) > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您删除订单信息成功"));
            BindIndexOrderListInfo();
            return;
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您删除订单信息失败，请您检查"));
            BindIndexOrderListInfo();
            return;
        }
    }
}