using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using System.Data.SqlClient;
using System.Data;
using BLL;
using DAL;

public partial class admin_AdminInfo_ManageAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (subTool.CheckAdminLogin("20"))
        {
            if (!IsPostBack)
            {
                BindAdmin();
            }
        }
    }

    private void BindAdmin()
    {
        gvmanagerAdmin.DataKeyNames = new string[] { "adminID" };
        DataSet set = new longyuan_AdminInfo().GetBindAdmin("p_SelectAdmin");
        if (set.Tables[0].Rows.Count > 0)
        {
            gvmanagerAdmin.DataSource = set.Tables[0];
            gvmanagerAdmin.DataBind();
        }
        else
        {
            gvmanagerAdmin.DataBind();
        }
    }

    protected void gvmanagerAdmin_RowEditing(object sender, GridViewEditEventArgs e)
    {
        gvmanagerAdmin.EditIndex = e.NewEditIndex;
        BindAdmin();
    }

    protected void gvmanagerAdmin_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvmanagerAdmin.EditIndex = -1;
        BindAdmin();
    }

    protected void gvmanagerAdmin_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            if (e.Row.Cells[2].Text == "20")
            {
                e.Row.Cells[2].Text = "超级管理员";
            }
            else
            {
                e.Row.Cells[2].Text = "普通管理员";
            }
        }
    }

    protected void gvmanagerAdmin_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string AdminID = gvmanagerAdmin.DataKeys[e.RowIndex].Value.ToString(); 
        longyuan_AdminInfo admin = new longyuan_AdminInfo();
        if (admin.DeleteAdmin(AdminID) > 0)
        {
            BindAdmin();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败，请检查');</script>");
        }
    }

    protected void gvmanagerAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvmanagerAdmin.PageIndex = e.NewPageIndex;
        BindAdmin();
    }

    protected void gvmanagerAdmin_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        string AdminID = gvmanagerAdmin.DataKeys[e.RowIndex].Value.ToString();
        if (((Label)(gvmanagerAdmin.Rows[e.RowIndex].FindControl("lblEnabled"))).Text == "起用")
        {
            if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("Admin", "isEnabled=0", "and adminID in(" + AdminID + ")") > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您禁用管理员成功！"));
                
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您设置管理员权限失败，请检查！"));
            }
        }
        if (((Label)(gvmanagerAdmin.Rows[e.RowIndex].FindControl("lblEnabled"))).Text == "禁用")
        {
            if (new longyuan_TableUpDateFieldsInfo().UpdateShoping("Admin", "isEnabled=1", "and adminID in(" + AdminID + ")") > 0)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您起用管理员成功！"));
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "", WebUnitily.AlertUrl("您设置管理员权限失败，请检查！"));
            }
        }  
        BindAdmin();
    }
}
