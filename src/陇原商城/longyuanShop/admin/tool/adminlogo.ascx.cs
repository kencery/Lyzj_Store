using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_tool_adminlogo : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        this.lblTime.Text = DateTime.Now.ToShortDateString();
    }
}
