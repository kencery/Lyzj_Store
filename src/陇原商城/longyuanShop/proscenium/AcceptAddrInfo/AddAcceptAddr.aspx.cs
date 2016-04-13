using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using Model;
using BLL;

public partial class proscenium_AcceptAddrInfo_AddAcceptAddr : System.Web.UI.Page
{
    private int userID;

    longyuan_AcceptAddrInfo accept = new longyuan_AcceptAddrInfo();

    private int InfoID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckUserLogin("-1"))
        {
            userID = WebUnitily.CheckInt(mycookie.getCookiesValue("shop8517User", "userID"));
            if (!IsPostBack)
            {
                if (Request.QueryString["InfoID"] != null && Request.QueryString["InfoID"] != "")
                {
                    InfoID = Int32.Parse(Request.QueryString["InfoID"]);
                    txtInfoId.Text = InfoID.ToString();
                    btnAdd.Visible = false;
                    btnUpdate.Visible = true;
                    lblAddAcceptAddr.Text = "修改收货人地址";
                    BindUpdateAcceptAddr(InfoID);
                }
                else
                {
                    btnAdd.Visible = true;
                    btnUpdate.Visible = false;
                    lblAddAcceptAddr.Text = "添加收货人地址";
                }
            }
        }
    }

    private void BindUpdateAcceptAddr(int InfoID)
    {
        L_AcceptAddrInfo addrInfo = accept.GetBindUpdateAcceptAddr(InfoID, userID);
        if (addrInfo != null)
        {
            txtRowAddr.Text = addrInfo.RowAddr;
            txtRealityName.Text = addrInfo.RealityName;
            txtDel.Text = addrInfo.Tel;
            txtHandset.Text = addrInfo.HandSet;
            txtZipCode.Text = addrInfo.zipCode;
            txtQQMath.Text = addrInfo.QQNum;
            txtProvince.Text = addrInfo.Province;
            txtcity.Text = addrInfo.City;
            txtCountry.Text = addrInfo.Country;

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("请您选择你所要修改的记录"));
        }
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        L_AcceptAddrInfo acceptinfo = new L_AcceptAddrInfo();
        acceptinfo.ProvinceID = WebUnitily.CheckInt(Request.Form["ProvinceId"]);
        acceptinfo.Province = WebUnitily.CheckStr(txtProvince.Text.Trim());
        acceptinfo.CityID=WebUnitily.CheckInt(Request.Form["CityId"]);
        acceptinfo.City = WebUnitily.CheckStr(txtcity.Text.Trim());
        acceptinfo.CountryID=WebUnitily.CheckInt(Request.Form["CountyId"]);
        acceptinfo.Country = WebUnitily.CheckStr(txtCountry.Text.Trim());

        acceptinfo.RowAddr = WebUnitily.CheckStr(txtRowAddr.Text.Trim());
        acceptinfo.RealityName = WebUnitily.CheckStr(txtRealityName.Text.Trim());
        acceptinfo.HandSet = WebUnitily.CheckStr(txtHandset.Text.Trim());
        acceptinfo.Tel = WebUnitily.CheckStr(txtDel.Text.Trim());
        acceptinfo.zipCode = WebUnitily.CheckStr(txtZipCode.Text.Trim());
        acceptinfo.QQNum = WebUnitily.CheckStr(txtQQMath.Text.Trim());

        acceptinfo.UserID = userID;
        acceptinfo.PostTime = DateTime.Now;

        int exeResult = accept.InsertAcceptAddr(acceptinfo);
        switch (exeResult)
        {
            case 1:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("收货地址添加成功！"));
                break;
            case 0:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("收货地址最多只能添加10个，请您检查！"));
                break;
            default:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("收货地址添加失败，请您检查！"));
                break;
        }
        txtcity.Text = "";
        txtCountry.Text = "";
        txtDel.Text = "";
        txtHandset.Text = "";
        txtProvince.Text = "";
        txtQQMath.Text = "";
        txtRealityName.Text = "";
        txtRowAddr.Text = "";
        txtZipCode.Text = "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        L_AcceptAddrInfo acceptinfo = new L_AcceptAddrInfo();
        acceptinfo.ProvinceID = WebUnitily.CheckInt(Request.Form["ProvinceId"]);
        acceptinfo.Province = WebUnitily.CheckStr(txtProvince.Text.Trim());
        acceptinfo.CityID = WebUnitily.CheckInt(Request.Form["CityId"]);
        acceptinfo.City = WebUnitily.CheckStr(txtcity.Text.Trim());
        acceptinfo.CountryID = WebUnitily.CheckInt(Request.Form["CountyId"]);
        acceptinfo.Country = WebUnitily.CheckStr(txtCountry.Text.Trim());

        acceptinfo.RowAddr = WebUnitily.CheckStr(txtRowAddr.Text.Trim());
        acceptinfo.RealityName = WebUnitily.CheckStr(txtRealityName.Text.Trim());
        acceptinfo.HandSet = WebUnitily.CheckStr(txtHandset.Text.Trim());
        acceptinfo.Tel = WebUnitily.CheckStr(txtDel.Text.Trim());
        acceptinfo.zipCode = WebUnitily.CheckStr(txtZipCode.Text.Trim());
        acceptinfo.QQNum = WebUnitily.CheckStr(txtQQMath.Text.Trim());

        acceptinfo.UserID = userID;
        acceptinfo.PostTime = DateTime.Now;

        acceptinfo.ID = WebUnitily.CheckInt(txtInfoId.Text);

        int exresult = accept.UpdateAcceptAddr(acceptinfo);
        switch (exresult)
        {
            case 1:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("收货地址修改成功！", "ManageAcceptAddr.aspx"));
                break;
            case 0:
                break;
            default:
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("收货地址修改失败，请您检查！"));
                break;
        }
    }
    protected void btnReset_Click(object sender, EventArgs e)
    {
        Response.Redirect("ManageAcceptAddr.aspx", true);
    }
}
