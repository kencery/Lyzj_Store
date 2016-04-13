using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using Model;
using System.Text;
using BLL;
using System.Data;

public partial class admin_orderlist_orderSuccendfahuo : System.Web.UI.Page
{
    private int adminID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            adminID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517Admin", "adminType"));
            if (!IsPostBack)
            {
                BindIndexyifahuo();
            }
        }
    }

    private void BindIndexyifahuo()
    {
        StringBuilder sb=new StringBuilder();
        int currPage=WebUnitily.CheckInt(Request["p"]);
        if (currPage == 0)
        {
            currPage = 1;
        }

        L_PageList pl = new L_PageList();
        pl.Currpage = currPage;
        pl.PageSize = 15;

        plist8571.CurPage = currPage;

        pl.TableName = "(OrderList as a Left Join (Select orderID,sum(memberPrice*BugNum*DisCount) as PriceTotal,sum(freign) as freightTotal From OrderDeTail Group by orderID) as b on b.orderID=a.orderID) ";
        pl.PKey = "a.orderID ";
        pl.FieldList = "a.orderID,a.userID,isNew,orderState,acceptName,acceptAddr,handSet,tel,zipCode,orderTime,ISNULL(b.priceTotal,0) as priceTotal,ISNULL(b.freightTotal,0) as freightTotal ";
        pl.Conditon = "and orderState=30 ";
        pl.OrderBy = "orderTime Desc ";

        longyuan_TableUpDateFieldsInfo tb = new longyuan_TableUpDateFieldsInfo();
        DataSet set = tb.GetPageList(pl);

        if (set.Tables.Count > 0)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                gvBindyifahuo.DataSource = set.Tables[0];
                gvBindyifahuo.DataKeyNames = new string[] { "orderID" };
                gvBindyifahuo.DataBind();
            }
            else
            {
                gvBindyifahuo.DataBind();
            }
        }
        else
        {
            gvBindyifahuo.DataBind();
        }
    }
    protected void gvBindyifahuo_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView drv = (DataRowView)e.Row.DataItem;  //获取要创建或数据绑定的行
            Label lbOrderState = (Label)e.Row.FindControl("lbOrderState");
            Int16 OrderState = Int16.Parse(drv.Row["orderState"].ToString());
            //状态    0取消    10等待付款   20已付款 30已发货
            switch (OrderState)
            {
                case 10:
                    lbOrderState.Text = "等待付款";
                    break;
                case 0:
                    lbOrderState.Text = "订单已取消";
                    break;
                case 20:
                    lbOrderState.Text = "已付款，等待发货";
                    break;
                case 30:
                    lbOrderState.Text = "已发货";
                    break;
                default:
                    lbOrderState.Text = "未知状态";
                    break;
            }
            Label lbOrderPT = (Label)e.Row.FindControl("lbOrderPT");
            lbOrderPT.Text = string.Format("{0:C2}", decimal.Parse(drv.Row["priceTotal"].ToString()) + decimal.Parse(drv.Row["freightTotal"].ToString()));
        }
    }
}
