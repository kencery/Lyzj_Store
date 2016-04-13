using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using Model;
using BLL;
using System.Data;
using System.Text;
using System.IO;
using System.Data.OleDb;

public partial class admin_Product_manageProduct : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            if (!this.IsPostBack)
            {
                BindProduct();
            }
        }
    }

    private void BindProduct()
    {
        int currPage = WebUnitily.CheckInt(Request["p"]);  //获取所请求页的索引
        if (currPage == 0)
        {
            currPage = 1;
        }

        L_PageList p1 = new L_PageList();
        p1.Currpage = currPage;
        p1.PageSize = 15;

        //获取分页的用户控件
        pList8517.CurPage = currPage;

        p1.TableName = "Product";
        p1.PKey = "productID";
        p1.FieldList = "productID,productName,categoryName,productImage,currentPrice,menberPrice,danwei,productStore,remainDay,addTime,isPost,isCommend";
       // p1.Conditon = " and isPost=1";
        p1.OrderBy = " addTime Desc";
        
        longyuan_TableUpDateFieldsInfo tb = new longyuan_TableUpDateFieldsInfo();
        DataSet dsSet = tb.GetPageList(p1);
        if (dsSet.Tables.Count > 0)
        {
            if (dsSet.Tables[0].Rows.Count > 0)
            {
                gvProduct.DataSource = dsSet.Tables[0];
                gvProduct.DataKeyNames = new string[] { "ProductID" };
                gvProduct.DataBind();
                pList8517.TotalPage = int.Parse(tb.PageCount.ToString());
            }
            else
            {
                gvProduct.DataBind();
            }
        }
        else
        {
            gvProduct.DataBind();
        }
    }
    protected void gvProduct_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView set = (DataRowView)e.Row.DataItem; //表示自定义视图

            Label lbState = (Label)e.Row.FindControl("lbState");
            int ispost = Int16.Parse(set.Row["IsPost"].ToString());
            if (ispost == 1)
            {
                lbState.Text = "已上架";
            }
            else
            {
                lbState.Text = "<font color='Red'>已下架</font>";
                lbState.ForeColor = System.Drawing.Color.Red;
            }
            Label lbtuijian = (Label)e.Row.FindControl("lbtuijian");
            int isCommend = Int16.Parse(set.Row["isCommend"].ToString());
            if (isCommend == 1)
            {
                lbtuijian.Text = "推荐";
            }
            else
            {
                lbtuijian.Text = "<font Color='red'>无</font>";
            }
             DateTime dtOverTime;
             TimeSpan howDays;
             Label lbHowDay = (Label)e.Row.FindControl("lbHowDay");
             dtOverTime = DateTime.Parse(DateTime.Now.ToShortDateString());
             DateTime postTime = DateTime.Parse(set.Row["AddTime"].ToString());
             int HowDay = Int32.Parse(set.Row["RemainDay"].ToString());
             howDays = dtOverTime.Subtract(DateTime.Parse(postTime.ToShortDateString()));

             lbHowDay.Text = "还剩<font Color='red'>" + (HowDay - howDays.Days) + "</font>天";
        }
    }
    protected void btnDel_Click(object sender, EventArgs e)
    {
        string str = "", sqlStr = "", delFileName = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择要删除的商品"));
            return;
        }

        sqlStr = "select ProductID from Product where productID in(" + str + ")";
        DataSet set = new longyuan_TableUpDateFieldsInfo().getDeleteShop(sqlStr);

        for (int i = 0; i < set.Tables[0].Rows.Count; i++)
        {
            if (delFileName.Length > 1)
            {
                delFileName = delFileName.Substring(1);
            }
            else
            {
                delFileName = "";
            }
        }
        if (new longyuan_TableUpDateFieldsInfo().Deleteproject("product", " and ProductID in(" + str + ")") > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品删除成功！！"));
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品删除失败！！"));
        }
        BindProduct();
    }
    protected void btnIsPost_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择需要上架的商品"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("product", "isPost=1", " and isPost=0 and productID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的产品上架成功！"));
        }
        else 
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品上架失败，请检查！"));
        }
        BindProduct();
    }
    protected void btnNotIsPost_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择需要上架的商品"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("product", "isPost=0", " and isPost=1 and productID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的产品上架成功！"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品上架失败，请检查！"));
        }
        BindProduct();
    }
    protected void btnIsCommend_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择需要推荐的商品"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("product", "isCommend=1", " and isPost=1 and productID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的产品推荐成功！"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品推荐失败，请检查！"));
        }
        BindProduct();
    }
    protected void btnCanceltuijian_Click(object sender, EventArgs e)
    {
        string str = "";
        if (Request["cbName"] != null)
        {
            str = Request["cbName"];
        }
        if (str.Trim().Length < 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择需要取消推荐的商品"));
            return;
        }
        if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("product", "isCommend=0", " and isPost=1 and productID in(" + str + ")") > 0)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您的产品推荐取消成功！"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品推荐取消失败，请检查！"));
        }
        BindProduct();
    }
    protected void lblexcel_Click(object sender, EventArgs e)
    {
        Export("application/ms-excel", "产品货物管理表.xls");
    }

    private void Export(string FileType, string FileName)
    {
        Response.Charset = "GB2312";  //获取或者设置输出流的http字符集
        Response.ContentEncoding = Encoding.UTF7;
        Response.AppendHeader("Content-Disposition", "attachment;filename=" + HttpUtility.UrlEncode(FileName, Encoding.UTF8).ToString());
        Response.ContentType = FileType;
        this.EnableViewState = false;
        StringWriter tw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(tw);
        gvProduct.RenderControl(hw);
        Response.Write(tw.ToString());
        Response.End();
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        //base.VerifyRenderingInServerForm(control);
    }
    protected void lbldaoru_Click(object sender, EventArgs e)
    {
        //gvProduct.DataSource = CreateDataSource();
        //gvProduct.DataBind();
    }
    //private DataSet CreateDataSource()
    //{
    //    string strCon;
    //    strCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Server.MapPath("excel.xls") + "; Extended Properties=Excel 8.0;";
    //    OleDbConnection olecon = new OleDbConnection();
    //    OleDbDataAdapter myda = new OleDbDataAdapter("Select * From [Sheet1$]", strCon);
    //    DataSet myds = new DataSet();
    //    myda.Fill(myds);
    //    return myds;
    //}
}