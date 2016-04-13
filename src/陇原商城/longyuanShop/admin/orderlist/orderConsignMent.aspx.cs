using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using BLL;
using System.Data;
using Model;
using System.Text;

public partial class admin_orderlist_orderConsignMent : System.Web.UI.Page
{
    private int adminID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            adminID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517Admin", "adminType"));
            if (!IsPostBack)
            {
                BindAdminManagerOrderList();
            }
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

        plList8531.CurPage = currpage;

        pl.TableName = "(OrderList as a Left Join (Select orderID,sum(memberPrice*BugNum*DisCount) as PriceTotal,sum(freign) as freightTotal From OrderDeTail Group by orderID) as b on b.orderID=a.orderID) ";
        pl.PKey = "a.orderID ";
        pl.FieldList = "a.orderID,a.userID,isNew,orderState,acceptName,acceptAddr,handSet,tel,zipCode,orderTime,ISNULL(b.priceTotal,0) as priceTotal,ISNULL(b.freightTotal,0) as freightTotal ";
        pl.Conditon = "and orderState=20 ";
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
                plList8531.TotalPage = int.Parse(tb.PageCount.ToString());
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
            case "post":
                rowID = Int32.Parse(e.CommandArgument.ToString());  //获取命令的参数
                BindfahuoInfo(gvBindAdminOrderList.DataKeys[rowID]["orderID"].ToString());
                break;
            default:
                break;
        }
    }

    private void BindfahuoInfo(string orderID)//管理员给用户购买的东西发货
    {
        if (orderID != "")   
        {
            L_OrderLogInfo orderloginfo = new L_OrderLogInfo();
            orderloginfo.OrderID = orderID;
            orderloginfo.OperateUserID = adminID;
            orderloginfo.ClientIP = Stringhelp.GetClientUp();
            orderloginfo.UserType = 20;
            orderloginfo.OperateType = 30;
            orderloginfo.OperateTime = DateTime.Now;

            string UpdateField = " orderState=30,shippedTime='" + DateTime.Now + "'";
            if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("orderList", UpdateField, " and orderID='" + orderID + "'") == 2)
            {
                orderloginfo.OperateDepict = "管理员发货成功";
                new longyuan_orderloginfo().InsertOrderLog(orderloginfo);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("管理员发货成功"));
                return;
            }
            else
            {
                orderloginfo.OperateDepict = "管理员发货失败";
                new longyuan_orderloginfo().InsertOrderLog(orderloginfo);
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("管理员发货失败，请您检查"));
                return;
            }
        }
        BindAdminManagerOrderList();
    }
}
