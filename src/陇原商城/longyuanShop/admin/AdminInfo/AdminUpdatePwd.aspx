<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="AdminUpdatePwd.aspx.cs" Inherits="admin_AdminInfo_AdminUpdatePwd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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

    <table align="center" cellpadding="0" cellspacing="0" 
        style="width: 820px; border: 1px solid #FF00FF; margin-left: 0px;">
        <tr>
           <td colspan="2" align="center" style="background-color: #C0C0C0; font-size: 22px; font-weight: bold;">
                修改管理员密码
           </td>
        </tr>
        <tr>
            <td style="width:20%" align="right">
                &nbsp;原始密码：&nbsp;</td>
            <td align="left">
                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:20%; height:30px" align="right">
                新&nbsp; 密&nbsp;码 ：</td>
            <td align="left">
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width:20%; height:30px" align="right">
                确认密码：</td>
            <td align="left">
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ErrorMessage="CompareValidator"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td style="width:20%; height:30px" align="right">
                &nbsp;</td>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button1" runat="server" Text="Button" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="Button2" runat="server" Text="Button" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;</td>
            <td align="left">
                &nbsp;</td>
        </tr>
    </table>

</div>
</asp:Content>

