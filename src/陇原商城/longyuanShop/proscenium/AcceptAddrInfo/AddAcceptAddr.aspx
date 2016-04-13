<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/AcceptAddrInfo/MasterPage.master" AutoEventWireup="true" CodeFile="AddAcceptAddr.aspx.cs" Inherits="proscenium_AcceptAddrInfo_AddAcceptAddr" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/accept.css" rel="stylesheet" type="text/css" />
    <script src="../../js/JScript1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="ManageAcceptAddr.aspx" title="管理收货地址">管理收货地址</a></li>
            <li class="now"><a href="AddAcceptAddr.aspx" title="添加收货地址">添加收货地址</a></li>
            <li class="now"><a href="ManageAcceptAddr.aspx" title="删除收货地址">删除收货地址</a></li>
            <li class="now"><a href="ManageAcceptAddr.aspx" title="修改收货地址">修改收货地址</a></li>
        </ul>
    </div>
</div>
<div class="AdminContent">
    <table cellpadding="0" cellspacing="0" class="AdminTable" style="border:1px solid red;">
        <tr>
            <td class="AdminTableTitle" colspan="2">
                <asp:Label ID="lblAddAcceptAddr" runat="server" Text="添加收货地址"></asp:Label></td>
        </tr>
        <tr>
            <td class="FieldName" style="vertical-align:top; height:24px;"><span class="red">*</span>所属省：</td>
            <td class="FieldValue" style="height:24px;">
                <asp:TextBox ID="txtProvince" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtProvince" runat="server" 
                    ControlToValidate="txtProvince" Display="Dynamic" 
                    ErrorMessage="所属省份不能为空,请你注意填写">*</asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td class="FieldName" style="vertical-align:top; height:24px;"><span class="red">*</span>所属市：</td>
            <td class="FieldValue" style="height:24px;">
                <asp:TextBox ID="txtcity" runat="server"  Width="200px" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtCity" runat="server" 
                    ControlToValidate="txtcity" Display="Dynamic" ErrorMessage="所属市区不能为空,请您注意填写">*</asp:RequiredFieldValidator>
            </td>
        </tr>
         <tr>
            <td class="FieldName" style="vertical-align:top; height:24px;"><span class="red">*</span>所属县：</td>
            <td class="FieldValue" style="height:24px;">
                <asp:TextBox ID="txtCountry" runat="server"  Width="200px" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtcountry" runat="server" 
                    ControlToValidate="txtCountry" Display="Dynamic" ErrorMessage="所属县份不能为空，请你注意填写">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="FieldName"><span class="red">*</span>街道地址：</td>
            <td class="FieldValue">
                <asp:TextBox ID="txtRowAddr" Width="400" MaxLength="400" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtAddr" runat="server" 
                    ControlToValidate="txtRowAddr" Display="Dynamic" ErrorMessage="街道地址不能为空">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="FieldName" style="height:24px;"><span class="red">*</span>收货人姓名：</td>
            <td class="FieldValue" style="height:24px;">
            <asp:TextBox ID="txtRealityName" Width="200px" MaxLength="20" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvRealityName" runat="server" 
                    ControlToValidate="txtRealityName" Display="Dynamic" ErrorMessage="收货人姓名不能为空">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="FieldName"><span class="red">*</span>手机号码：</td>
            <td class="FieldValue">
                <asp:TextBox ID="txtHandset" Width="200px" MaxLength="20" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvHandset" runat="server" 
                    ControlToValidate="txtHandset" Display="Dynamic" ErrorMessage="手机号码不能为空">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revtxthandset" runat="server" 
                    ControlToValidate="txtHandset" Display="Dynamic" ErrorMessage="请输入正确的手机号码验证" 
                    ValidationExpression="((\d{11})|^((\d{7,8})|(\d{4}|\d{3})-(\d{7,8})|(\d{4}|\d{3})-(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1})|(\d{7,8})-(\d{4}|\d{3}|\d{2}|\d{1}))$)">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="FieldName">电话号码：</td>
            <td class="FieldValue">
                <asp:TextBox ID="txtDel" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldName"><span class="red">*</span>邮政编码：</td>
            <td>
                <asp:TextBox ID="txtZipCode" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxtzipcode" runat="server" 
                    ControlToValidate="txtZipCode" Display="Dynamic" ErrorMessage="邮政编码不能为空!">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revZipCode" runat="server" 
                    ControlToValidate="txtZipCode" Display="Dynamic" ErrorMessage="请输入正确的邮政编码格式" 
                    ValidationExpression="\d{6}">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="FieldName">QQ账号：</td>
            <td class="FieldValue">
                <asp:TextBox ID="txtQQMath" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="FieldName"></td>
            <td class="FieldValue">
                <asp:Button ID="btnAdd" runat="server" Text="添加收货地址" onclick="btnAdd_Click" 
                    style="height: 26px" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUpdate" runat="server" Text="修改收货地址" style="height: 26px" 
                    onclick="btnUpdate_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReset" runat="server" Text="跳到收货地址管理页面" 
                    CausesValidation="False" onclick="btnReset_Click" />
&nbsp;<asp:ValidationSummary ID="ValidationSummary1" runat="server" 
                    ShowMessageBox="True" ShowSummary="False" />
            </td>
        </tr>
    </table>
</div>
    <asp:TextBox ID="txtInfoId" runat="server" Visible="false"></asp:TextBox>
</asp:Content>

