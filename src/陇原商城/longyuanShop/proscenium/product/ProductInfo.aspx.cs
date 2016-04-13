using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using DBUtility;
using BLL;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

public partial class proscenium_product_ProductInfo : System.Web.UI.Page
{
    protected L_ProductInfo pInfo;
    protected int remainDayNum;

    longyuan_productinfo product = new longyuan_productinfo();

    longyuan_CartInfo cartinfo = new longyuan_CartInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int PId = WebUnitily.CheckInt(Request["PId"]);
            ViewState["PID"] = PId;
            if (PId == 0)
            {
                Response.Write(WebUnitily.AlertUrl("请选择产品", "ProductList.aspx"));
                Response.End();
            }
            txtId.Text = PId.ToString();
            GetBindTuiJian();
            BindProductInfoByProductID(PId);
        }
    }

    private void GetBindTuiJian()
    {
        rpIsCommendDress_001.DataSource = product.GetIndexBindHottuiJian(0, 1, "top 20 ");
        rpIsCommendDress_001.DataBind();
    }

    private void BindProductInfoByProductID(int pId)
    {
        pInfo = product.GetProductInfoByProductID(pId);
        if (pInfo == null)
        {
        }
        else
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<li>首页＞</li>" + pInfo.CategoryName + "＞" + pInfo.ProductName);
            liClass.Text = sb.ToString();
            //计算还剩几天，产品过期
            DateTime dtOverTime;
            TimeSpan howDays;
            dtOverTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            DateTime postTime = pInfo.Addtime;
            int HowDay = pInfo.RemainDay;
            howDays = dtOverTime.Subtract(DateTime.Parse(postTime.ToShortDateString()));

            remainDayNum = HowDay - howDays.Days;
        }
    }

    protected void imgBuyProduct_Click(object sender, ImageClickEventArgs e)
    {
        if (subTool.CheckUserLogin("-1"))
        {
            int userID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517User", "userID"));
            L_CartInfo cInfo = new L_CartInfo();
            cInfo.UserID = userID;
            cInfo.CartID = userID.ToString() + DateTime.Now.ToString("yyyyMMddmm");
            cInfo.ProductID = WebUnitily.CheckInt(ViewState["PID"]);
            cInfo.BugNum = WebUnitily.CheckInt(txtBuyNum.Text);
            cInfo.bugTime = DateTime.Now;

            if (cInfo.ProductID == 0)
            {
                Response.Write("你需要加入购物车的商品不存在，请您检查！！");
                Response.End();
            }
            if (cInfo.BugNum == 0)
            {
                Response.Write("请检查你要购买的商品数！");
                Response.End();
            }

            int exresult = cartinfo.addCart(cInfo);
            switch (exresult)
            {
                case 20:
                    Response.Write("<script>alert('商品添加购物车成功');</script>");
                    Server.Transfer("../orderinfo/UserCard.aspx");
                    break;
                case 10:
                    Response.Write("<script>alert('商品添加收藏夹成功');</script>");
                    Server.Transfer("../orderinfo/UserCard.aspx");
                    break;
                default:
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("加入购物车失败，请您检查"));
                    break;
            }
        }
    }
}