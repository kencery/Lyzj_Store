using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_tool_adminlogoleft : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        linkReaset.Attributes.Add("onclick", "if(Confirm('您确认是否退出本系统吗？')){ window.close();} else{return false}");

    }
    protected void linkReaset_Click(object sender, EventArgs e)
    {
        Page.RegisterStartupScript(" ", " <script   LANGUAGE=JavaScript   > " + "window.parent.opener=null;window.parent.close(); " + " </script> ");
    }
}
