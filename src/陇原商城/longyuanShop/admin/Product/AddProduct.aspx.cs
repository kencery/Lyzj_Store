using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using System.Data;
using Model;
using System.Collections.ObjectModel;
using BLL;
using System.Text;

public partial class admin_Product_AddProduct : System.Web.UI.Page
{
    private int productID = 0;
    longyuan_CategoryInfo category = new longyuan_CategoryInfo();
    longyuan_productinfo productinfo = new longyuan_productinfo();

    int isReviewEnable;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            if (!IsPostBack)
            {
                BindDDlDanwei();
                ReSetPage();
                if (Request.QueryString["pID"] != null && Request.QueryString["pID"] != "")
                {
                    productID = Int32.Parse(Request.QueryString["pID"]);
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    txtProNumber.ReadOnly = true;
                    txtProNumber.Enabled = false;

                    SkipProduct();

                    lblshow.Text = "修改产品";
                }
                else
                {
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    lblshow.Text = "添加产品";
                    ViewState["photo"] = "noimage.gif";
                }
            }
        }
    }

    public void SkipProduct()
    {
        L_ProductInfo pinfo = new longyuan_productinfo().GetProduct(productID);
        txtProNumber.Text = pinfo.Pronumber;
        txtProductName.Text = pinfo.ProductName;
        ddlLeavl.SelectedIndex = pinfo.ProductCategoryID;
        imgPhoto.ImageUrl = "~/photo/" + pinfo.ProductImage;
        txtPrice.Text = pinfo.Price.ToString().Replace(".0000", "");
        txtCurrentPrince.Text = pinfo.CurrentPrice.ToString().Replace(".0000", "");
        txtMenberPrince.Text = pinfo.MenberPrince.ToString().Replace(".0000", "");
        txtPoductStore.Text = pinfo.ProducStore.ToString();
        this.ddlDanWei.ClearSelection();
        ddlDanWei.Items.FindByValue(pinfo.Danwei).Selected = true;
        this.ddlFreightType.ClearSelection();
        ddlFreightType.Items.FindByValue(pinfo.FreightType).Selected = true;
        txtFreight.Text = pinfo.Freight.ToString().Replace(".0000", "");
        ddlQQList.Items.FindByValue("934532778").Selected = true;
        if (pinfo.Iscommend == 0)
        {
            rbDesc.Checked = false;
            rbDesc2.Checked=true;
        }
        else
        {
            rbDesc.Checked = true;
            rbDesc2.Checked = false;
        }
        ddlRemainDay.Items.FindByValue(pinfo.RemainDay.ToString()).Selected = true;
        txtContent.Text = pinfo.ProductDesc;
        ViewState["photo"] = "noimage.gif";
    }

    public void ReSetPage()
    {
        Collection<L_CategoryInfo> categoryinfos = category.GetAllCategoryByDepth(0);
        ddlLeavl.Items.Clear();
        ListItem item = new ListItem();
        item.Text = "关键类别";
        item.Value = "-1,0";
        ddlLeavl.Items.Add(item);
        foreach (L_CategoryInfo info in categoryinfos)
        {
            ListItem newitem = new ListItem();
            newitem.Text = CreateItemText(info.ProductCategoryName, info.CategoryDepth);
            newitem.Value = info.CategoryDepth.ToString() + "," + info.ProductCategoryID.ToString();
            ddlLeavl.Items.Add(newitem);
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

    private void BindDDlDanwei()
    {
        if (HttpContext.Current.Application["shopDanWeiList"] != null)
        {
            DataSet ds1 = (DataSet)Application["shopDanWeiList"];
            ddlDanWei.Items.Clear();
            ddlDanWei.DataSource = ds1.Tables[0];
            ddlDanWei.DataTextField = "n";
            ddlDanWei.DataValueField = "v";
            ddlDanWei.DataBind();
        }

        if (HttpContext.Current.Application["shopQQList"] != null)
        {
            DataSet ds2 = (DataSet)Application["shopQQList"];
            ddlQQList.Items.Clear();
            ddlQQList.DataSource = ds2.Tables[0];
            ddlQQList.DataTextField = "n";
            ddlQQList.DataValueField = "v";
            ddlQQList.DataBind();
        }
    }

    protected void lbtnUp_Click(object sender, EventArgs e)
    {
        if (fuProductPhoto.HasFile)
        {
            if (fuProductPhoto.PostedFile.ContentLength > 100 * 1024)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("照片大小不能超过100K，请重新选择"));
            }
            else
            {
                if (fuProductPhoto.PostedFile.ContentType == "image/gif" || fuProductPhoto.PostedFile.ContentType == "image/x-png" || fuProductPhoto.PostedFile.ContentType == "image/pjpeg" || fuProductPhoto.PostedFile.ContentType == "image/bmp")
                {
                    string strNewName = WebUnitily.GetName() + System.IO.Path.GetExtension(fuProductPhoto.FileName);
                    string strPath = Server.MapPath("~/photo/" + strNewName);
                    fuProductPhoto.PostedFile.SaveAs(strPath);
                    imgPhoto.ImageUrl = "~/photo/" + strNewName;
                    ViewState["photo"] = strNewName;
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请上传常用格式的图片"));
                }

            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择照片后再上传？"));
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        L_ProductInfo pInfo = new L_ProductInfo();
        pInfo.Pronumber = txtProNumber.Text.Trim();
        pInfo.ProductName = txtProductName.Text.Trim();
        pInfo.Keyword = "";

        string categoryDetail = this.ddlLeavl.SelectedItem.Value;
        string categoryDetail1 = this.ddlLeavl.SelectedItem.Value;
        string categoryID = categoryDetail.Split(',')[1];
        pInfo.ProductCategoryID = Convert.ToInt32(categoryID);
        pInfo.ParentNameRoute = categoryDetail1.ToString();
        pInfo.CategoryName = this.ddlLeavl.Items[ddlLeavl.SelectedIndex].Text;

        pInfo.ProductImage = ViewState["photo"].ToString();
        pInfo.Price = Convert.ToDecimal(txtPrice.Text.Trim());
        pInfo.CurrentPrice = Convert.ToDecimal(txtCurrentPrince.Text.Trim());
        pInfo.MenberPrince = Convert.ToDecimal(txtMenberPrince.Text.Trim());

        pInfo.ProducStore = Convert.ToInt32(txtPoductStore.Text.Trim());
        pInfo.Danwei = ddlDanWei.SelectedValue;
        pInfo.FreightType = ddlFreightType.SelectedValue;
        pInfo.Freight = Convert.ToDecimal(txtFreight.Text.Trim());

        pInfo.LinkQQID = ddlQQList.SelectedIndex.ToString();
        pInfo.LinkQQName = ddlQQList.Items[ddlQQList.SelectedIndex].Text;
        pInfo.Ispost = 1;
        if (rbDesc.Checked)
        {
            isReviewEnable = 1;
        }
        else
        {
            isReviewEnable = 0;
        }
        pInfo.Isreviewenable = isReviewEnable;
        //出错误处
        pInfo.RemainDay = Int32.Parse(ddlRemainDay.SelectedValue);
        pInfo.ProductDesc = this.txtContent.Text;
        pInfo.Addtime = DateTime.Now;

        if (productinfo.InsertProduct(pInfo) == 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品发布成功！"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品发布失败，请您检查一下！！"));
        }
        txtContent.Text = "";
        txtCurrentPrince.Text = "";
        txtFreight.Text = "";
        txtMenberPrince.Text = "";
        txtPoductStore.Text = "";
        txtPrice.Text = "";
        txtProductName.Text = "";
        txtProNumber.Text = "";
    }

    protected void btnReste_Click(object sender, EventArgs e)
    {
        txtContent.Text = "";
        txtCurrentPrince.Text = "";
        txtFreight.Text = "";
        txtMenberPrince.Text = "";
        txtPoductStore.Text = "";
        txtPrice.Text = "";
        txtProductName.Text = "";
        txtProNumber.Text = "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        L_ProductInfo pInfo = new L_ProductInfo();
        pInfo.Pronumber = txtProNumber.Text.Trim();
        pInfo.ProductName = txtProductName.Text.Trim();
        pInfo.Keyword = "";

        string categoryDetail = this.ddlLeavl.SelectedItem.Value;
        string categoryDetail1 = this.ddlLeavl.SelectedItem.Value;
        string categoryID = categoryDetail.Split(',')[1];
        pInfo.ProductCategoryID = Convert.ToInt32(categoryID);
        pInfo.ParentNameRoute = categoryDetail1.ToString();
        pInfo.CategoryName = this.ddlLeavl.Items[ddlLeavl.SelectedIndex].Text;

        pInfo.ProductImage = ViewState["photo"].ToString();
        pInfo.Price = Convert.ToDecimal(txtPrice.Text.Trim());
        pInfo.CurrentPrice = Convert.ToDecimal(txtCurrentPrince.Text.Trim());
        pInfo.MenberPrince = Convert.ToDecimal(txtMenberPrince.Text.Trim());

        pInfo.ProducStore = Convert.ToInt32(txtPoductStore.Text.Trim());
        pInfo.Danwei = ddlDanWei.SelectedValue;
        pInfo.FreightType = ddlFreightType.SelectedValue;
        pInfo.Freight = Convert.ToDecimal(txtFreight.Text.Trim());

        pInfo.LinkQQID = ddlQQList.SelectedIndex.ToString();
        pInfo.LinkQQName = ddlQQList.Items[ddlQQList.SelectedIndex].Text;
        pInfo.Ispost = 1;
        if (rbDesc.Checked)
        {
            isReviewEnable = 1;
        }
        else
        {
            isReviewEnable = 0;
        }
        pInfo.Isreviewenable = isReviewEnable;
        //出错误处
        pInfo.RemainDay = Int32.Parse(ddlRemainDay.SelectedValue);
        pInfo.ProductDesc = this.txtContent.Text;
        pInfo.Addtime = DateTime.Now;

        pInfo.ProductID = Int32.Parse(Request.QueryString["pID"]);

        int result = productinfo.updateProduct(pInfo);
        switch (result)
        { 
            case 1:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品修改成功！", "manageProduct.aspx"));
                break;
            case -2:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("修改产品的信息不存在，请您检查！"));
                break;
            default:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("产品修改不成功！", "manageProduct.aspx"));
                break;
        }
    }
}
