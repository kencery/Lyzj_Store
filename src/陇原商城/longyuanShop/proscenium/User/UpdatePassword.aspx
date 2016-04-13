<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/AcceptAddrInfo/MasterPage.master" AutoEventWireup="true" CodeFile="UpdatePassword.aspx.cs" Inherits="proscenium_User_UpdatePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/accept.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="UpdatePassword.aspx" title="修改密码">修改密码</a></li>
            <li class="now"><a href="#" title="修改用户信息">修改用户信息</a></li>
            
        </ul>
    </div>
</div>
<div class="AdminContent">
    <table cellpadding="0" cellspacing="0" class="AdminTable" style="border:1px solid red;">
        <tr>
            <td class="AdminTableTitle" colspan="2">用户修改密码</td>
        </tr>
        <tr>
            <td style="width: 25%;" align="right" >用户名：</td>
            <td><asp:Label ID="lblUserName" runat="server" Text=""></asp:Label></td>
        </tr>
         <tr>
            <td align="right">原密码：</td>
            <td>
                <asp:TextBox ID="txtOldPwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvOldPwd" runat="server" ControlToValidate="txtOldPwd" Display="Dynamic" ErrorMessage="原密码不能为空">*</asp:RequiredFieldValidator></td>
        </tr>
         <tr>
            <td align="right">新密码：</td>
            <td>
                <asp:TextBox ID="txtNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewPwd" runat="server" ControlToValidate="txtNewPwd" Display="Dynamic" ErrorMessage="新密码不能为空">*</asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="right">确认新密码</td>
            <td>
                <asp:TextBox ID="txtReNewPwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReNewPwd" runat="server" ControlToValidate="txtReNewPwd" Display="Dynamic" ErrorMessage="确认新密码不能为空">*</asp:RequiredFieldValidator>
                <asp:CompareValidator ID="cpvNewRePwd" runat="server" ControlToCompare="txtNewPwd" ControlToValidate="txtReNewPwd" Display="Dynamic" ErrorMessage="确认新密码和新密码不一致，请确认后重新输入">*</asp:CompareValidator></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnOK" runat="server" Text="确定" onclick="btnOK_Click" />
                <asp:ValidationSummary ID="vsUpdatePwd" runat="server" ShowMessageBox="True" ShowSummary="False" /></td>
        </tr>
    </table>
</div>
</asp:Content>

