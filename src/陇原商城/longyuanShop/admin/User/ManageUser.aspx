<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="ManageUser.aspx.cs" Inherits="admin_User_ManageUser" %>

<%@ Register src="../tool/myPagelist.ascx" tagname="myPagelist" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="ManageUser.aspx"title="添加管理员信息">管理用户信息</a></li>
       </ul>
    </div>
</div>
<div>
    
    <table align="center" cellpadding="0" cellspacing="0" 
        style="width: 820px; border: 1px solid #FF00FF">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                    Width="100%">
                    <Columns>
                        <asp:BoundField DataField="nickName" HeaderText="用户名" />
                        <asp:BoundField DataField="Sex" HeaderText="性别" />
                        <asp:BoundField DataField="Age" HeaderText="年龄" />
                        <asp:BoundField DataField="country" HeaderText="国家" />
                        <asp:BoundField DataField="province" HeaderText="省份" />
                        <asp:BoundField DataField="EMail" HeaderText="E_Mail" />
                        <asp:BoundField DataField="QQ" HeaderText="QQ" />
                        <asp:BoundField />
                        <asp:BoundField />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:myPagelist ID="myPagelist1" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Button" />
            </td>
        </tr>
    </table>
    
</div>
</asp:Content>

