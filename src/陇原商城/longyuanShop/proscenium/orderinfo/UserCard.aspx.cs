using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Text;
using System.Data;
using DBUtility;
using Model;

public partial class proscenium_orderinfo_UserCard : System.Web.UI.Page
{
    longyuan_productinfo productInfo = new longyuan_productinfo();
    longyuan_CartInfo cartinfo = new longyuan_CartInfo();
    private int userID;
    protected string moneyTotal;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckUserLogin("-1"))
        {
            userID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517User", "userID"));
            BindIndexShoppingCartInfo();
            if (!IsPostBack)
            {
                BindIndextuijian();
            }
        }
    }

    private void BindIndexShoppingCartInfo()
    {
        StringBuilder sb = new StringBuilder();
        DataSet set = cartinfo.GetShoppingCartList(userID);
        if (set.Tables.Count > 0)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                DataTable dt = set.Tables[0];
                ddlBindIndexShoppingCartInfo.DataSource = dt;
                ddlBindIndexShoppingCartInfo.DataBind();
            }
            if (set.Tables[1].Rows.Count == 1)
            {
                moneyTotal = string.Format("{0:C2}", set.Tables[1].Rows[0]["MoneyTotle"]);
            }
        }
    }

    private void BindIndextuijian()
    {
        ddlBindIndextuijianShopping.DataSource = productInfo.GetIndexBindHottuiJian(0, 1, " top 10 ");
        ddlBindIndextuijianShopping.DataBind();
    }

    protected void linkDelete_Click(object sender, EventArgs e)
    {
        L_CartInfo cart = new L_CartInfo();
        cart.UserID = userID;
        cart.CartID = WebUnitily.CheckStr(Request["CardID"]);
        cart.ProductID = WebUnitily.CheckInt(Request["PId"]);
        if (cartinfo.GetCartListDelete(cart) == 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("购物车中的商品删除成功！"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("商品删除失败！"));
        }
        BindIndexShoppingCartInfo();
    }
}
