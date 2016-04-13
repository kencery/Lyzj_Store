using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DBUtility;
using BLL;
using Model;

public partial class proscenium_BulletinInfo_BulletinInfoContent : System.Web.UI.Page
{
    protected L_BulletionInfo bInfo;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            Int32 Id = WebUnitily.CheckInt(Request["Id"]);
            if (Id == 0)
            {
                Response.Write(WebUnitily.AlertUrl("请选择产品", "/"));
                Response.End();
            }
            bindDataInfo(Id);
        }
    }

    private void bindDataInfo(Int32 Id)
    {
        bInfo = new longyuan_BulletionInfo().GetBulletinInfo(Id, 0);
        if (bInfo != null)
        {

        }
        else
        {
            Response.Write(WebUnitily.AlertUrl("请选择产品", "/"));
            Response.End();
        }

    }
}
