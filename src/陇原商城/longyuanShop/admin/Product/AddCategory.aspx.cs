using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using System.Collections.ObjectModel;
using System.Text;
using DBUtility;
using BLL;

public partial class admin_addCategory : System.Web.UI.Page
{
    longyuan_CategoryInfo category = new longyuan_CategoryInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReSetPage();
        }
        if (Request.QueryString["id"] != null)
        {
            int CategoryId;
            if (Int32.TryParse(Request.QueryString["id"], out CategoryId))
            {
                if (category.GetSubCategoryByID(CategoryId).Count == 0 && !category.GetExistProduct(CategoryId))
                {
                    if (category.DeleteCategoryByID(CategoryId))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("分类删除成功！"));
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("分类删除失败！"));
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("该分类下面存在子分类或者商品，你无法删除！"));
                }
            }
            ReSetPage();
        }
    }

    private void ReSetPage()
    {
        Collection<L_CategoryInfo> categoryInfos = category.GetAllCategoryByDepth(0);
        ddlLevel.Items.Clear();
        ddldiv.Items.Clear();
        ListItem item = new ListItem();
        item.Text = "关键类别";
        item.Value = "-1,0";
        ddldiv.Items.Add(item);
        ddlLevel.Items.Add(item);
        foreach (L_CategoryInfo info in categoryInfos)
        {
            ListItem newitem = new ListItem();
            newitem.Text = CreateItemText(info.ProductCategoryName, info.CategoryDepth);
            newitem.Value = info.CategoryDepth.ToString() + "," + info.ProductCategoryID.ToString();
            ddlLevel.Items.Add(newitem);

            ListItem ddlitem = new ListItem();
            ddlitem.Text = CreateItemText(info.ProductCategoryName, info.CategoryDepth);
            ddlitem.Value = info.CategoryDepth.ToString() + "," + info.ProductCategoryID.ToString();
            ddldiv.Items.Add(ddlitem);
        }
        Repeater1.DataSource = categoryInfos;
        Repeater1.DataBind();
    }

    public static string CreateItemText(string CategoryName, int depth)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < depth; i++)
        {
            sb.Append("   ");
        }
        if (depth > 0)
        {
            sb.Append("└");
        }
        sb.Append(CategoryName);
        return sb.ToString();
    }

    protected void btnAddCategory_Click(object sender, EventArgs e)
    {
        L_CategoryInfo info = new L_CategoryInfo();
        info.ProductCategoryName = txtCategoryName.Text;
        info.CategoryDepth = Convert.ToInt32(ddlLevel.SelectedValue.Split(',')[0]) + 1;
        info.ParentID = Convert.ToInt32(ddlLevel.SelectedValue.Split(',')[1]);
        if (category.InsertCategory(info))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("添加类别成功"));
            ReSetPage();
        }
        txtCategoryName.Text = "";
    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        L_CategoryInfo info = new L_CategoryInfo();
        info.ProductCategoryID = Convert.ToInt32(Request.Form["lbdivid"].ToString());
        info.ProductCategoryName = Request.Form["tbname"].ToString();
        info.CategoryDepth = Convert.ToInt32(ddldiv.SelectedValue.Split(',')[0]) + 1;
        info.ParentID = Convert.ToInt32(ddldiv.SelectedValue.Split(',')[1]);
        int step = info.CategoryDepth - Convert.ToInt32(Request.Form["olddepth"].ToString()) - 1;
        if (category.UpdateCategoryByID(info, step))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("修改类别成功"));
            ReSetPage();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("修改类别成功"));
        }
    }
}
