using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using DBUtility;

public partial class admin_BulletinInfo_AddBulletin : System.Web.UI.Page
{
    private int bulletinID = 0;  //变量赋值
    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null && Request.QueryString["ID"] != "")
                {
                    bulletinID = Int32.Parse(Request.QueryString["ID"]);
                    lblShow.Text = "修改网站公告信息";
                    btnAddBulletion.Visible = false;
                    btnUpdate.Visible = true;
                    BindUpdateBulletin();
                }
                else
                {
                    btnAddBulletion.Visible =true;
                    btnUpdate.Visible =  false;
                    lblShow.Text = "添加网站公告信息";
                }
            }
        }
    }

    private void BindUpdateBulletin()
    {
        L_BulletionInfo bulletion = new longyuan_BulletionInfo().GetBulletinInfo(bulletinID, 0);
        if (bulletion == null)
        {
            Response.Write(WebUnitily.AlertUrl("信息不存在，请您重新选择"));
            Response.End();
        }
        txtTitle.Text = bulletion.BulletinTitle;
        txtContent.Text = bulletion.BulletinContent;
    }

    protected void btnAddBulletion_Click(object sender, EventArgs e)
    {
        L_BulletionInfo bulletionInfo = new L_BulletionInfo();
        bulletionInfo.BulletinTitle = txtTitle.Text.Trim();
        bulletionInfo.BulletinContent = txtContent.Text.Trim();
        bulletionInfo.IsPost = 1;
        bulletionInfo.OrderNum = 0;
        bulletionInfo.PostTime = Convert.ToDateTime(DateTime.Now.ToString());
        if (new longyuan_BulletionInfo().AddBulletion(bulletionInfo) == 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("网站公告添加成功"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("网站公告添加失败，请您检查！"));
        }
        txtTitle.Text = "";
        txtContent.Text = "";
    }

    protected void btnregiest_Click(object sender, EventArgs e)
    {
        txtTitle.Text = "";
        txtContent.Text = "";
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        L_BulletionInfo bulletin = new L_BulletionInfo();
        bulletin.ID = Int32.Parse(Request.QueryString["ID"]);
        bulletin.BulletinTitle = txtTitle.Text.Trim();
        bulletin.BulletinContent = txtContent.Text.Trim();
        bulletin.IsPost = 1;
        bulletin.OrderNum = 0;
        bulletin.PostTime = Convert.ToDateTime(DateTime.Now.ToString());
        if (new longyuan_BulletionInfo().updateBulletion(bulletin) == 1)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("网站公告修改成功成功", "ManageBulletin.aspx"));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("网站公告修改失败，请您检查！", "ManageBulletin.aspx"));
        }
        txtTitle.Text = "";
        txtContent.Text = "";
    }
}