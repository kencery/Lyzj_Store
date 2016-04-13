<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="ManageAdmin.aspx.cs" Inherits="admin_AdminInfo_ManageAdmin" %>

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

    <table align="right" cellpadding="0" cellspacing="0" 
        style="width: 820px; border: 1px solid #CCFF99">
        <tr>
            <td align="center"
                style="background-color: #C0C0C0; font-size: 22px; font-weight: bold;">
                管理管理员信息</td>
        </tr>
        <tr>
            <td >
               <asp:GridView ID="gvmanagerAdmin" runat="server" BackColor="#DEBA84" 
                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    CellSpacing="2" AutoGenerateColumns="False" AllowPaging="True" 
                    onpageindexchanging="gvmanagerAdmin_PageIndexChanging" 
                    onrowcancelingedit="gvmanagerAdmin_RowCancelingEdit" 
                    onrowdatabound="gvmanagerAdmin_RowDataBound" 
                    onrowdeleting="gvmanagerAdmin_RowDeleting" 
                    onrowediting="gvmanagerAdmin_RowEditing" PageSize="5" 
                    onrowupdating="gvmanagerAdmin_RowUpdating" >
                   <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                   <Columns>
                       <asp:BoundField DataField="AdminID" HeaderText="用户ID" ReadOnly="True" />
                       <asp:BoundField DataField="AdminName" HeaderText="管理员名" />
                       <asp:BoundField DataField="adminType" HeaderText="管理员类型" />
                         <asp:TemplateField HeaderText="管理员状态">
                            <ItemTemplate>
                                <asp:Label runat="server" ID="lblEnabled" Text='<%#(System.Int16) DataBinder.Eval(Container.DataItem,"IsEnabled")==1?"起用":"禁用" %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"AdminID") %>'>'</asp:Label>                         
                            </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="LastLoginTime" HeaderText="注册时间" ReadOnly="True" />
                       <asp:TemplateField HeaderText="删除">
                           <ItemTemplate>
                               <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Delete" OnClientClick="return confirm('您确认删除该管理员吗？')" CausesValidation="False" >删除</asp:LinkButton></ItemTemplate></asp:TemplateField><asp:TemplateField HeaderText="管理员管理">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtnSetRole" runat="server" CommandName="Update" Text='<%#(System.Int16) DataBinder.Eval(Container.DataItem,"IsEnabled")==1?"禁用管理员":"起用管理员" %>' CommandArgument='<%# DataBinder.Eval(Container.DataItem,"AdminID") %>'>'</asp:LinkButton></ItemTemplate>
                            <ControlStyle ForeColor="Red" />
                            <ItemStyle ForeColor="Red" />
                       </asp:TemplateField></Columns><FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                   <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                   <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                   <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td style="color: #000080; font-weight: bold; font-size: 14px;" >
                <br />
                注意：系统内置管理员登录名：admin,密码：admin&nbsp; 请慎重管理管理员</td>
        </tr>
    </table>

</div>
</asp:Content>

