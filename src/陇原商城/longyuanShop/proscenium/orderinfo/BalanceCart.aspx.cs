using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Data;
using DBUtility;
using Model;

public partial class proscenium_orderinfo_BalanceCart : System.Web.UI.Page
{
    longyuan_TableUpDateFieldsInfo datefields = new longyuan_TableUpDateFieldsInfo();

    longyuan_productinfo productInfo = new longyuan_productinfo();

    longyuan_OrderListInfo order = new longyuan_OrderListInfo();

    private int userID;
    protected string moneyTotal;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckUserLogin("-1"))
        {
            userID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517User", "userID"));
            if (!IsPostBack)
            {
                BindIndexHotShopping();
                BindDataListShoppingRar();
                BindAcceptAddrList();
            }
        }
    }

    private void BindIndexHotShopping()
    {
        ddlBindIndextuijianShopping.DataSource = productInfo.GetIndexBindtuiJian(0, 1, " top 10 ");
        ddlBindIndextuijianShopping.DataBind();
    }

    private void BindDataListShoppingRar()
    {
        DataSet set = new longyuan_CartInfo().GetShoppingCartList(userID);
        if (set.Tables.Count > 0)
        {
            if (set.Tables[0].Rows.Count > 0)
            {
                ddlBindIndexShoppingCartInfo.DataSource = set.Tables[0];
                ddlBindIndexShoppingCartInfo.DataBind();
            }
            else
            {
                Response.Write(WebUnitily.AlertUrl("您的购物车中还没有产品，不能进行结算", "UserCard.aspx"));
                Response.End();
            }

            decimal proMoneyTotal, freightTotal;

            proMoneyTotal = WebUnitily.CheckMoney(set.Tables[1].Rows[0]["MoneyTotle"].ToString());
            freightTotal = WebUnitily.CheckMoney(set.Tables[1].Rows[0]["FreightTotal"].ToString());

            moneyTotal = string.Format("{0:C2}", proMoneyTotal + freightTotal);
            txtMoneyTotal.Text = moneyTotal.ToString();
        }
    }

    private void BindAcceptAddrList()
    {
        string detailsAddr;
        string sqlStr = " Select id,province,city,ISNULL(Country,'') as country,rowAddr From AcceptAddr Where userID=" + userID;
        DataSet Set = datefields.GetBindAddr(sqlStr);
        if (Set.Tables.Count > 0 && Set.Tables[0].Rows.Count > 0)
        {
            rbListAddr.Items.Clear();
            for (int i = 0; i < Set.Tables[0].Rows.Count; i++)
            {
                DataRow drv = Set.Tables[0].Rows[i];
                if (drv["country"].ToString() != "")
                {
                    detailsAddr = drv["province"].ToString() + drv["city"].ToString() + drv["country"].ToString() + drv["rowAddr"].ToString();
                }
                else
                {
                    detailsAddr = drv["province"].ToString() + drv["city"].ToString() + drv["rowAddr"].ToString();
                }
                rbListAddr.Items.Add(new ListItem(detailsAddr, drv["id"].ToString()));
            }
            lblInfo.Text = "<a href=\"../AcceptAddrInfo/AddAcceptAddr.aspx\" title=\"添加新收货地址\" target=\"_blank\">添加新收货地址！！</a>";
        }
        else
        {
            lblInfo.Text = "<a href=\"../AcceptAddrInfo/AddAcceptAddr.aspx\" title=\"请先添加新收货地址\" target=\"_blank\">请先添加新收货地址！！</a>";
        }
    }

    protected void btnAdd_Click(object sender, ImageClickEventArgs e)
    {
        int addrID = WebUnitily.CheckInt(rbListAddr.SelectedValue);
        if(addrID==0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择收货地址！"));
            return;
        }
        L_AcceptAddrInfo addrinfo = new longyuan_AcceptAddrInfo().GetBindUpdateAcceptAddr(addrID, userID);
        if (addrinfo == null)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您所选择的收货地址不存在！"));
            return;
        }

        L_OrderListInfo olistinfo = new L_OrderListInfo();
        olistinfo.UserID = userID;
        olistinfo.AcceptName = addrinfo.RealityName;
        olistinfo.AcceptAddr = addrinfo.Province + addrinfo.City + addrinfo.Country + addrinfo.RowAddr;
        olistinfo.HandSet = addrinfo.HandSet;
        olistinfo.Tel = addrinfo.Tel;
        olistinfo.ZipCode = addrinfo.zipCode;

        olistinfo.OrderTime = DateTime.Now;
        olistinfo.ShippedTime = DateTime.Now;
        olistinfo.OrderState = 10;  //0代表取消订单  10代表等待付款  20代表已付款 30代表已发货
        olistinfo.IsNew = 0;  //0 新订单 1一查看
        olistinfo.AdminID = 0;
        olistinfo.OrderID = userID.ToString() + DateTime.Now.ToString("yyyyMMddmm");

        int exeResult = order.AddUserOrderItem(olistinfo);
        switch (exeResult)
        {
            case 10:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的订单提交成功,你需要付款"));
                break;
            case 0:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的订单提交成功,你需要付款"));
                break;
            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的购物车中没有产品，请您选择产品", "UserCard.aspx"));
                break;
            case -3:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您还没有购物车呢，请您先选择产品", "UserCard.aspx"));
                break;
            default:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的订单提交失败"));
                break;
        }
        BindDataListShoppingRar();
    }
}
