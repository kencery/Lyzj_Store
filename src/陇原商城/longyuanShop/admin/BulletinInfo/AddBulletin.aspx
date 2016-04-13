<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="AddBulletin.aspx.cs" Inherits="admin_BulletinInfo_AddBulletin" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="AddBulletin.aspx" title="添加网站公告信息">添加网站公告</a></li>
            <li><a href="ManageBulletin.aspx" title="管理网站公告信息">网站公告信息</a></li>
       </ul>
    </div>
</div>
<div>
     <table align="center" cellpadding="0" cellspacing="0" style="width: 820px; border: 1px solid #FF00FF">
                <tr>
                    <td style="background-color: #99CCFF; font-size:28px; font-weight: bold; font-style: italic; font-variant: normal; color: #FFFFFF;"  colspan="2">
                        <asp:Label ID="lblShow" runat="server" Text="添加网站公告信息"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="width:20%; height:40px;" align="right">
                        公告标题：</td>
                    <td align="left">
                        <asp:TextBox ID="txtTitle" runat="server" MaxLength="300" Width="400px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvtxtTitle" runat="server" 
                            ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="*必填项">*必填项</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        公告内容：</td>
                    <td align="left">
                         <asp:TextBox ID="txtContent" runat="server" style="display:none"></asp:TextBox>
                         <iframe id="eWebEditor1" 
                             src="../Edit/ewebeditor.htm?id=txtContent&style=coolblue" frameborder="0" 
                             scrolling="no" style="width:488px; height:352px"></iframe>
                         </td>
                </tr>
                <tr>
                    <td style="height:40px;" align="right">
                        提交：</td>
                    <td align="left">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAddBulletion" runat="server" Text="添加网站公告" 
                            onclick="btnAddBulletion_Click" />&nbsp;&nbsp;&nbsp;<asp:Button 
                            ID="btnUpdate" runat="server" onclick="btnUpdate_Click" Text="修改网站公告" />
&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnregiest" runat="server" CausesValidation="False" 
                            onclick="btnregiest_Click" Text="重置" />
                    </td>
                </tr>
            </table>
</div>
</asp:Content>

