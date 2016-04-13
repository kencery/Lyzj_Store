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

public partial class proscenium_product_ProductList : System.Web.UI.Page
{
    private int classID;
    string order = String.Empty;

    protected void Page_Load(object sender, EventArgs e)
    {
        classID = WebUnitily.CheckInt(Request["ClassId"]);
        bindClassList();
        if (Request.QueryString["Order"] == null)
        {
        }
        else
        {
            order = Request.QueryString["Order"].ToString();
        }
    }

    private void bindClassList()
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

        pl.TableName = "Product ";
        pl.PKey = "productID ";
        pl.FieldList = "productID,ProductName,ProductImage,Price,CurrentPrice,MenberPrice,Danwei,RemainDay,AddTime,LinkQQId,LinkQQName ";
        pl.OrderBy = " AddTime Desc ";

        longyuan_TableUpDateFieldsInfo tb = new longyuan_TableUpDateFieldsInfo();
        DataSet set = tb.GetPageList(pl);
        if (set.Tables.Count > 0)
        {
            if (set.Tables[0].Rows.Count > 0)
            {

                rpDataList.DataSource = set.Tables[0];
                rpDataList.DataBind();
                plList8531.TotalPage = int.Parse(tb.PageCount.ToString());
            }
            else
            {
                rpDataList.DataBind();
            }
        }
        else
        {
            rpDataList.DataBind();
        }
    }
}
