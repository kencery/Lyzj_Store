using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Collections.ObjectModel;
using Model;
using BLL;

public partial class Tool_Logo : System.Web.UI.UserControl
{
    longyuan_CategoryInfo category = new longyuan_CategoryInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ReSetPage();
        }
    }

    public void ReSetPage()
    {
        Collection<L_CategoryInfo> categoryinfos = category.GetAllCategoryByDepth(0);
        ddlProductCategory.Items.Clear();
        ListItem item = new ListItem();
        item.Text = "关键类别";
        item.Value = "-1,0";
        ddlProductCategory.Items.Add(item);
        foreach (L_CategoryInfo info in categoryinfos)
        {
            ListItem newitem = new ListItem();
            newitem.Text = CreateItemText(info.ProductCategoryName, info.CategoryDepth);
            newitem.Value = info.CategoryDepth.ToString() + "," + info.ProductCategoryID.ToString();
            ddlProductCategory.Items.Add(newitem);
        }
    }

    public static string CreateItemText(string categoryName, int depth)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < depth; i++)
        {
            sb.Append(" ");
        }
        if (depth > 0)
        {
            sb.Append("└");
        }
        sb.Append(categoryName);
        return sb.ToString();
    }
}
