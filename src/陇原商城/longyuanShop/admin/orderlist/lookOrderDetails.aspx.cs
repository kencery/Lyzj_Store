using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using System.Data;
using BLL;

public partial class admin_orderlist_lookOrderDetails : System.Web.UI.Page
{
    private int AdminID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            AdminID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517Admin", "adminID"));
            if (!IsPostBack)
            {
                BindLookOrderDetails();
            }
        }
    }

    private void BindLookOrderDetails()
    {
        string orderID = WebUnitily.CheckStr(Request["orderID"]);
        if (orderID != "")
        {
            DataSet set = new longyuan_OrderListInfo().GetOrderDetails(orderID);
            if (set.Tables.Count > 0)
            {
                if (set.Tables[0].Rows.Count > 0)
                {
                    gvMinuterOrderList.DataSource = set.Tables[0];
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
            string imagePath = "~/photo/" + set.Row["ProductImage"].ToString();
            
            if (imagePath == "")
            {
                imgSmall.ImageUrl = "/images/Erro.png";
            }
            else
            {
                imgSmall.ImageUrl = imagePath;
            }
        }
    }
    protected void btnResent_Click(object sender, EventArgs e)
    {
        Response.Redirect("orderConsignMent.aspx",true);
    }
}
