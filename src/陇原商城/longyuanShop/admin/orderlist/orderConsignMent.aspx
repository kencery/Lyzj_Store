<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="orderConsignMent.aspx.cs" Inherits="admin_orderlist_orderConsignMent" %>

<%@ Register src="../tool/myPagelist.ascx" tagname="myPagelist" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="#" title="等待付款订单">等待付款订单</a></li>&nbsp;
            <li ><a href="#" title="等待发货订单">等待发货订单</a></li>
            <li ><a href="#" title="成交订单">成交订单</a></li>
            <li ><a href="#" title="取消订单">取消订单</a></li>
        </ul>
    </div>
</div>
<div>
    <table align="center" cellpadding="0" cellspacing="0" 
        style="width: 820px; border: 1px solid #FF00FF">
        <tr>
             <td style="font-size: 22px; font-weight: bold; color: #FF00FF; font-style: normal; background-color: #C0C0C0;">等待发货订单</td>
        </tr>
        <tr>
            <td>
               <asp:GridView ID="gvBindAdminOrderList" runat="server" 
                    AutoGenerateColumns="False" BackColor="#DEBA84" BorderColor="#DEBA84" 
                    BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" 
                    Width="100%" onrowdatabound="gvBindAdminOrderList_RowDataBound" 
                    onrowcommand="gvBindAdminOrderList_RowCommand" >
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="订单号" >
                        <ItemStyle Width="50px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="订单总价">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderPT" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="80px" ForeColor="Red" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="订单状态">
                            <ItemTemplate>
                                <asp:Label ID="lblOrderState" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="acceptName" HeaderText="收货人" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="acceptAddr" HeaderText="收货地址" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="handset" HeaderText="手机号" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="zipCode" HeaderText="邮编" />
                        <asp:ButtonField ButtonType="Button" CommandName="post" Text="发货" 
                            HeaderText="发货">
                        <ItemStyle Width="80px" />
                        </asp:ButtonField>
                        <asp:HyperLinkField DataNavigateUrlFields="orderID" 
                            DataNavigateUrlFormatString="lookOrderDetails.aspx?orderID={0}" HeaderText="查看" 
                            Text="查看">
                        <ControlStyle Font-Underline="True" ForeColor="Red" />
                        <HeaderStyle ForeColor="Red" />
                        <ItemStyle Width="60px" ForeColor="Red" Font-Underline="True" />
                        </asp:HyperLinkField>
                    </Columns>
                     <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                     <EmptyDataTemplate>
                     <div>没有等待发货的订单!!</div>
                     </EmptyDataTemplate>
                     <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                     <HeaderStyle HorizontalAlign="Center"  />
                     <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                     <RowStyle Height="30px" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>     
                <uc1:myPagelist ID="plList8531" runat="server" />
            </td>
        </tr>
          <tr>
            <td style="color: #000080">注:请管理员仔细核对信息后发货</td>
        </tr>
    </table>
</div>

</asp:Content>

