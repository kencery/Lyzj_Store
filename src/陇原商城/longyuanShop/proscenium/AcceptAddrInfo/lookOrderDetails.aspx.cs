using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using System.Data;
using BLL;

public partial class proscenium_AcceptAddrInfo_lookOrderDetails : System.Web.UI.Page
{
    private int userID;

    longyuan_OrderListInfo orderListInfo = new longyuan_OrderListInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckUserLogin("-1"))
        {
            userID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517User", "userID"));
            if (!IsPostBack)
            {
                BindIndexMinuter();
            }
        }
    }

    private void BindIndexMinuter()
    {
        string orderID = WebUnitily.CheckStr(Request["orderID"]);
        if (orderID != "")
        {
            DataSet Set = orderListInfo.GetOrderDetails(orderID);
            if (Set.Tables.Count > 0)
            {
                if (Set.Tables[0].Rows.Count > 0)
                {
                    gvMinuterOrderList.DataSource = Set.Tables[0];
                    gvMinuterOrderList.DataKeyNames = new string[] { "ID" };
                    gvMinuterOrderList.DataBind();
                }
                else
                {
                    gvMinuterOrderList.DataBind();
                }
            }
            else
            {
                gvMinuterOrderList.DataBind();
            }
        }
    }

    protected void gvMinuterOrderList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView set = (DataRowView)e.Row.DataItem;
            Image imgSmall = (Image)e.Row.FindControl("imgSmall");
            string ImagePath = "~/photo/" + set.Row["ProductImage"].ToString();

            if (ImagePath == "")
            {
                imgSmall.ImageUrl = "/images/Erro.png";
            }
            else
            {
                imgSmall.ImageUrl = ImagePath;
            }
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("OrderList.aspx", true);
    }
}