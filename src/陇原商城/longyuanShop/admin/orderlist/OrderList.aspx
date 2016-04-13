<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="admin_orderlist_OrderList" %>

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
            <td style="font-size: 22px; font-weight: bold; color: #FF00FF; font-style: normal; background-color: #C0C0C0;">等待付款订单</td>
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
                        <asp:BoundField DataField="orderTime" DataFormatString="{0:d}" 
                            HeaderText="下单时间" HtmlEncode="False" >
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Button" CommandName="del" Text="取消订单" 
                            HeaderText="取消订单">
                        <ItemStyle Width="80px" />
                        </asp:ButtonField>
                    </Columns>
                     <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                     <EmptyDataTemplate>
                     <div>没有等待付款订单!!</div>
                     </EmptyDataTemplate>
                     <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                     <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" />
                     <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                     <RowStyle Height="30px" HorizontalAlign="Center" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <uc1:myPagelist ID="pList8517" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="color: #000080">注:这些信息非常重要，请管理员妥善保管</td>
        </tr>
    </table>
 
</div>
</asp:Content>

