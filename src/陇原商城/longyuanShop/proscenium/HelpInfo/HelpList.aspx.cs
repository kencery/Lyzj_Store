using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using DBUtility;
using Model;
using BLL;
using System.Data;

public partial class proscenium_HelpInfo_HelpList : System.Web.UI.Page
{
    private string keyWord, orderBy;
    private int classID;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            classID = WebUnitily.CheckInt(Request["classID"]);
            keyWord = WebUnitily.CheckStr(Request["keyWord"]);
            orderBy = WebUnitily.CheckStr(Request["orderBy"]);
            BindIndexHelp();
            BindIndexHelpTitle();
        }
    }

    private void BindIndexHelp()
    {
        StringBuilder sb = new StringBuilder();
        int currPage = WebUnitily.CheckInt(Request["p"]);
        if (currPage == 0)
        {
            currPage = 1;
        }

        L_PageList pl = new L_PageList();
        pl.Currpage = currPage;
        pl.PageSize = 10;
        new8517PageList.CurPage = currPage;
        //select helpID,helptitle,postTime from ShopHelp where isPost=1
        pl.TableName = " ShopHelp";
        pl.PKey = " helpID";
        pl.FieldList = " helpID,helptitle,postTime";

        if (classID != 0)
        {
            pl.Conditon = " and classID=" + classID + " or ParentIDRoute like '%/,'+CAST(" + classID + " as varchar(10))+'/,%' ESCAPE '/'";
        }
        if (keyWord != "")
        {
            pl.Conditon = " and HelpTitle like '%" + keyWord + "%'";
        }
        pl.Conditon = " and isPost=1";
        if (orderBy == "")
        {
            pl.OrderBy = " postTime desc";
        }

        longyuan_TableUpDateFieldsInfo tb = new longyuan_TableUpDateFieldsInfo();
        DataSet dSet = tb.GetPageList(pl);
        if (dSet.Tables.Count > 0)
        {
            if (dSet.Tables[0].Rows.Count > 0)
            {
                ddlBindIndexHelpInfo.DataSource = dSet.Tables[0];
                ddlBindIndexHelpInfo.DataBind();
                new8517PageList.TotalPage = int.Parse(tb.PageCount.ToString());
            }
            else
            {
                new8517PageList.Visible = false;
                ddlBindIndexHelpInfo.Visible = false;
                lbInfo.Visible = true;
                lbInfo.Text = "此类别还没有帮助主题呢!!";
            }
        }
    }

    private void BindIndexHelpTitle()
    {
        if (HttpContext.Current.Application["helpInfoList"] != null)
        {
            DataSet ds3 = (DataSet)Application["helpInfoList"];
            ddlBindex.DataSource = ds3.Tables[0];
            ddlBindex.DataBind();
        }
    }
}
