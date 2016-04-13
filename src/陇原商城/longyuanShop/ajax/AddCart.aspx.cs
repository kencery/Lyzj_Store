using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using Model;
using BLL;
using System.Text;
using System.Data;

public partial class ajax_AddCart : System.Web.UI.Page
{
    longyuan_CartInfo cartinfo = new longyuan_CartInfo();
    private int userID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckUserLogin("-1"))
        {
            userID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517User","userID"));
            string requestType = WebUnitily.CheckStr(Request.Form["RequestType"]);  //获取窗体变量的集合

            switch (requestType)
            {
                case "add":
                    userAddCart();
                    break;
                case "change":
                    break;
            }
        }
    }
    private void userAddCart()
    {
        L_CartInfo cInfo = new L_CartInfo();
        cInfo.UserID = userID;
        cInfo.CartID = userID.ToString() + DateTime.Now.ToString("yyyyMMddmm");
        cInfo.ProductID = WebUnitily.CheckInt(Request.Form["PId"]);
        cInfo.BugNum = WebUnitily.CheckInt(Request.Form["BuyNum"]);
        cInfo.bugTime = DateTime.Now;

        if (cInfo.ProductID == 0)
        {
            Response.Write("-1");
            Response.End();
        }
        if (cInfo.BugNum == 0)
        {
            Response.Write("-1");
            Response.End();
        }

        int extResult = cartinfo.addCart(cInfo);

        switch (extResult)
        {
            case 20:
                Response.Write("产品已经在购物车中");
                Response.End();
                break;
            case 10:
                Response.Write("产品加入购物车成功");
                Response.End();
                break;
            default:
                Response.Write("加入购物车失败");
                Response.End();
                break;
        }
    }

    private void changeBuyNum()
    {
        StringBuilder sb = new StringBuilder();
        L_CartInfo cInfo = new L_CartInfo();
        cInfo.UserID = userID;
        cInfo.CartID = WebUnitily.CheckStr(Request["cartID"]);
        cInfo.ProductID = WebUnitily.CheckInt(Request["PId"]);
        cInfo.BugNum = WebUnitily.CheckInt(Request["BuyNum"]);

        DataSet Set = cartinfo.GetUpdateShoppingNumMoney(cInfo);

        sb.Append("<table style=\" width:100%; margin-top:5px; padding:5px; border:none;\" cellpadding=\"0\" cellspacing=\"0\">");
        if (Set.Tables.Count > 0)
        {
            string proName;
            sb.Append("<tr class=\"cartListTitle\"><td>商品名称/图片</td><td class=\"FieldName100\">单价</td><td class=\"FieldName120\">数量</td><td class=\"FieldName120\">本商品合计</td><td class=\"FieldName80\"> 操作</td></tr>");
            for (int i = 0; i < Set.Tables[0].Rows.Count; i++)
            {
                DataRow drv = Set.Tables[0].Rows[i];
                sb.Append("<tr>");
                sb.Append("<tr class=\"cartListRow\">");
                if (drv["ProSmallPath"].ToString() != "")
                {
                    sb.Append("<td><img src=\"" + "../photo/" + drv["ProSmallPath"] + "\" alt=\"产品图片\" />");
                }
                else
                {
                    sb.Append("<td><img src=\"/Images/Erro.png\" alt=\"产品图片\" />");
                }
                proName = drv["ProductName"].ToString();
                if (proName.Length > 20)
                {
                    proName = proName.Substring(0, 20);
                }
                sb.Append("<p class=\"wenzi\"><a href=\"../product/ProductInfo.aspx?PId=" + drv["ProductID"] + "\" title=" + drv["ProductName"] + "\" target=\"_blank\">" + proName + "</a></p></td>");
                sb.Append("<td class=\"FieldName100\">" + string.Format("{0:C2}", drv["MenberPrince"]) + "</td>");
                sb.Append("<td class=\"FieldName120\"><input id=\"txtBuyNum_" + drv["ProductId"] + "\" type=\"text\" class=\"input\" maxlength=\"5\" style=\"width:50px;\" onblur=\"Cart8517.ChangeBuyNum('" + drv["CartID"] + "'," + drv["ProductID"] + ");\" value=\"" + drv["BuyNum"] + "\" /></td>");
                sb.Append("<td class=\"FieldName120\"><span class=\"red\">" + string.Format("{0:C2}", drv["MoneyAmount"]) + "</span></td>");
                sb.Append("<td class=\"FieldName80\"><a href=\"javascript:void(0);\" onclick=\"Cart8517.DelCartProduct('" + drv["CartID"] + "','" + drv["ProductID"] + "');\" title=\"删除\">删除</a></td>");
                sb.Append("</tr>");
            }
            sb.Append("<tr class=\"cartListRow\"><td colspan=\"5\" style=\"text-align:right;\">总价(包含运费):<span class=\"red\">" + string.Format("{0:C2}", Set.Tables[1].Rows[0]["MoneyTotal"]) + "</span>元</td></tr>");
        }
        else
        {
            sb.Append("<tr class=\"cartListRow\"><td colspan=\"5\" style=\"text-align:right;\"><div class=\"NoInfo\">您还没有购买产品!!</div></td></tr>");
        }
        sb.Append("</table>");

        Response.Write(sb.ToString());
        Response.End();
    }
}
