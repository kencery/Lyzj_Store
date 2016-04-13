<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="AddAdminInfo.aspx.cs" Inherits="admin_AdminInfo_AddAdminInfo" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <script type="text/javascript" language="JavaScript">
     function GetDateTime() {
         //日期 
         var now = new Date(); //获取系统日期，即Sat Jul 29 08:24:48 UTC+0800 2006 
         var yy = now.getYear(); //截取年，即2006 
         var mm = now.getMonth(); //截取月，即07 
         var dd = now.getDay(); //截取日，即29 
         //取时间 
         var hh = now.getHours(); //截取小时，即8 
         var min = now.getMinutes(); //截取分钟，即24 
         var ss = now.getTime() % 60000; //获取时间，因为系统中时间是以毫秒计算的，所以秒要通过余60000得到。 
         ss = (ss - (ss % 1000)) / 1000; //然后，将得到的毫秒数再处理成秒 
         var clock = hh + ':'; //将得到的各个部分连接成一个日期时间 
         if (mm < 10) clock += '0'; //字符串 
         clock += mm + ':';
         if (ss < 10) clock += '0';
         clock += ss;
         document.getElementById("a").value = yy + "-" + mm + "-" + dd;
         //document.getElementById("a").value=yy+"-"+mm+"-"+dd+" "+hh+":"+min+":"+ss;
         document.getElementById("b").value = clock;
         alert(clock);
     }
</script>
    <asp:ScriptManager ID="ScriptManager2" runat="server">
    </asp:ScriptManager>
<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="AddAdminInfo.aspx" title="添加管理员信息">添加管理员</a></li>
            <li><a href="ManageAdmin.aspx" title="管理管理员信息">管理管理员</a></li>
            <li><a href="AdminUpdatePwd.aspx" title="修改管理员信息">修改密码</a></li>
       </ul>
    </div>
</div>
<div>
  <table align="left" cellpadding="0" cellspacing="0" 
        style="width: 820px; border: 1px solid #CCFF66;">
        <tr>
            <td colspan="3" align="center" 
                style="background-color: #C0C0C0; font-size: 22px; font-weight: bold;">
                添加管理员</td>
        </tr>
        <tr>
            <td style="width:15%; height:36px;" align="right">
                <span style="color:Red">*</span>用&nbsp; 户&nbsp; 名：</td>
            <td align="left" colspan="2">
                <asp:TextBox ID="txtAdminName" runat="server"
                    Width="200px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvAdminName" runat="server" 
                    ControlToValidate="txtAdminName" Display="Dynamic" ErrorMessage="用户名不能为空！">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td  align="right" style="height:36px;">
                <span style="color:Red">*</span>密&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;   码：</td>
            <td  align="left" style="height: 36px" colspan="2">
                <asp:TextBox ID="txtAdminPwd" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                <cc1:PasswordStrength ID="txtAdminPwd_PasswordStrength" runat="server" 
                    BarBorderCssClass="" BarIndicatorCssClass="" Enabled="True" 
                    PrefixText="密码强度为: " 
                    TargetControlID="txtAdminPwd" TextStrengthDescriptions="太短;弱;一般;较强;强;" 
                    CalculationWeightings="20;20;30;30" PreferredPasswordLength="20" 
                    RequiresUpperAndLowerCaseCharacters="True">
                </cc1:PasswordStrength>
                <asp:RequiredFieldValidator ID="rfvAdminPwd" runat="server" 
                    ControlToValidate="txtAdminPwd" Display="Dynamic" ErrorMessage="密码不能为空!">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td  align="right" style="height:36px;">
                <span style="color:Red">*</span>确认密码：</td>
            <td  align="left" style="height: 36px" colspan="2">
                <asp:TextBox ID="txtAdminOkPwd" runat="server" Width="200px" 
                    TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvOkAdminPwd" runat="server" 
                    ControlToValidate="txtAdminOkPwd" Display="Dynamic" ErrorMessage="确认密码不能为空">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtAdminOkPwd" ControlToValidate="txtAdminPwd" 
                    Display="Dynamic" ErrorMessage="确认密码和密码必须相同">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td align="right" style="height:36px;">
                <span style="color:Red">*</span>用户类型：</td>
            <td  align="left" colspan="2">
                <asp:DropDownList ID="ddlAdminType" runat="server" Width="100px">
                    <asp:ListItem Selected="True" Value="0">普通管理员</asp:ListItem>
                    <asp:ListItem Value="20">超级管理员</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" />
                <br />
                <asp:Button ID="btnAddAdmin" runat="server" Text="添加管理员" 
                    onclick="btnAddAdmin_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</div>
</asp:Content>

