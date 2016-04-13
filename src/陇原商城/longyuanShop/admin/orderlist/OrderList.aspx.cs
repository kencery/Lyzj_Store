using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using System.Text;
using Model;
using BLL;
using System.Data;

public partial class admin_orderlist_OrderList : System.Web.UI.Page
{
    private int adminID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            adminID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517Admin", "adminID"));
        }
        if (!IsPostBack)
        {
            BindAdminManagerOrderList();
        }
    }

    private void BindAdminManagerOrderList()
    {
        StringBuilder sb = new StringBuilder();
        int currpage = WebUnitily.CheckInt(Request["p"]);
        if (currpage == 0)
        {
            currpage = 1;
        }
        L_PageList pl = new L_PageList();
        pl.Currpage = currpage;
        pl.PageSize = 10;

        pList8517.CurPage = currpage;

        pl.TableName = "(OrderList as a Left Join (Select orderID,sum(memberPrice*BugNum*DisCount) as PriceTotal,sum(freign) as freightTotal From OrderDeTail Group by orderID) as b on b.orderID=a.orderID) ";
        pl.PKey = "a.orderID ";
        pl.FieldList = "a.orderID,a.userID,isNew,orderState,acceptName,acceptAddr,handSet,tel,zipCode,orderTime,ISNULL(b.priceTotal,0) as priceTotal,ISNULL(b.freightTotal,0) as freightTotal ";
        pl.Conditon = "and orderState=10 ";
        pl.OrderBy = "orderTime Desc ";

        longyuan_TableUpDateFieldsInfo tb = new longyuan_TableUpDateFieldsInfo();
        DataSet set = tb.GetPageList(pl);
        if (set.Tables.Count > 0)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                gvBindAdminOrderList.DataSource = set.Tables[0];
                gvBindAdminOrderList.DataKeyNames = new string[] { "orderID" };
                gvBindAdminOrderList.DataBind();
                pList8517.TotalPage = int.Parse(tb.PageCount.ToString());
            }
            else
            {
                gvBindAdminOrderList.DataBind();
            }
        }
        else
        {
            gvBindAdminOrderList.DataBind();
        }
    }

    protected void gvBindAdminOrderList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView set = (DataRowView)e.Row.DataItem;
            Label lblOrderState = (Label)e.Row.FindControl("lblOrderState");
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
                    lblOrderState.Text = "位置状态";
                    break;
            }
            Label lblOrderPT = (Label)e.Row.FindControl("lblOrderPT");
            lblOrderPT.Text = string.Format("{0:C2}", decimal.Parse(set.Row["priceTotal"].ToString()) + decimal.Parse(set.Row["freightTotal"].ToString()));
        }
    }

    protected void gvBindAdminOrderList_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cName = e.CommandName;
        int rowID;
        switch (cName)
        {
            case "del":
                rowID = int.Parse(e.CommandArgument.ToString());
                AdminUpdateOrderList(gvBindAdminOrderList.DataKeys[rowID]["orderID"].ToString());
                break;
            default:
                break;
        }
    }

    private void AdminUpdateOrderList(string orderID)
    {
        if (orderID != "")
        {
            L_OrderLogInfo logeinfo = new L_OrderLogInfo();
            logeinfo.OrderID = orderID;
            logeinfo.OperateUserID = adminID;
            logeinfo.ClientIP = Stringhelp.GetClientUp();
            logeinfo.UserType = 20;
            logeinfo.OperateType = 0;
            logeinfo.OperateTime = DateTime.Now;

            string updateField = " orderState=0";
            if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("orderList", updateField, " and OrderID='" + orderID + "'") == 1)
            {
                logeinfo.OperateDepict = "管理员取消订单成功";
                new longyuan_orderloginfo().InsertOrderLog(logeinfo);
                BindAdminManagerOrderList();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("取消订单成功！"));
                return;
            }
            else
            {
                logeinfo.OperateDepict = "管理员取消订单失败";
                new longyuan_orderloginfo().InsertOrderLog(logeinfo);
                BindAdminManagerOrderList();
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("取消订单失败，请您检查！"));
                return;
            }
        }
    }
}
