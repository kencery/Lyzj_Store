<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="AddHelper.aspx.cs" Inherits="admin_HelpInfo_AddHelper" ValidateRequest="false"  %>

<%@ Register assembly="FreeTextBox" namespace="FreeTextBoxControls" tagprefix="FTB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="AddHelper.aspx" title="添加网站帮助信息">添加网站帮助信息</a></li>
            <li><a href="ManageHelpInfo.aspx" title="管理网站帮助信息">管理网站帮助信息</a></li>
       </ul>
    </div>
</div>
<div>
    
    <table align="center" cellpadding="0" cellspacing="0" 
        style="width: 820px; border: 1px solid #FF00FF">
        <tr>
           <td style="background-color: #99CCFF; font-size:28px; font-weight: bold; font-style: italic; font-variant: normal; color: #FFFFFF;"  colspan="2">
                        <asp:Label ID="lblShow" runat="server" Text="添加网站帮助信息"></asp:Label>
           </td>
        </tr>
        <tr>
            <td style="width:20%" align="right">
                帮主标题：</td>
            <td align="left">
                <asp:TextBox ID="txtHelpTitle" runat="server" MaxLength="50" Width="367px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvtxthelpTitle" runat="server" 
                    ControlToValidate="txtHelpTitle" Display="Dynamic" ErrorMessage="*必填项"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td align="right">
                帮助类别：</td>
            <td align="left">
                <asp:DropDownList ID="ddlhelpClassName" runat="server" Height="25px" 
                    Width="187px">
                    <asp:ListItem Value="0">关于陇原网上商城</asp:ListItem>
                    <asp:ListItem Value="1">陇原网上超市积分规则</asp:ListItem>
                    <asp:ListItem Value="2">陇原网上交易流程</asp:ListItem>
                    <asp:ListItem Value="3">联系客服</asp:ListItem>
                    <asp:ListItem Value="4">搜索商品 </asp:ListItem>
                    <asp:ListItem Value="5">注册登录 </asp:ListItem>
                    <asp:ListItem Value="6">积分</asp:ListItem>
                    <asp:ListItem Value="7">订单 </asp:ListItem>
                    <asp:ListItem Value="8">测试小类</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td align="right">
                帮助内容：</td>
            <td align="left">
            <asp:TextBox ID="txtContent" runat="server" style="display:none"></asp:TextBox>
            <iframe id="eWebEditor1" src="../Edit/ewebeditor.htm?id=txtContent&style=coolblue" 
                    frameborder="0" scrolling="no" style="height: 317px; width: 449px"></iframe></td>
        </tr>
        <tr>
            <td align="right">
                提交信息：</td>
            <td align="left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;<asp:Button ID="btnAddHelp" runat="server" Text="添加帮助" 
                    onclick="btnAddHelp_Click" Height="26px" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnUpdateHelp" runat="server" Text="修改帮助" 
                    onclick="btnUpdateHelp_Click" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegest" runat="server" Text="重置" onclick="btnRegest_Click" />
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

