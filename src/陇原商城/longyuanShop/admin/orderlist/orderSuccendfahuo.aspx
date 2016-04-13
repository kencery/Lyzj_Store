<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="orderSuccendfahuo.aspx.cs" Inherits="admin_orderlist_orderSuccendfahuo" %>

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
             <td style="font-size: 22px; font-weight: bold; color: #FF00FF; font-style: normal; background-color: #C0C0C0;">
                 查看已发货订单</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvBindyifahuo" runat="server" AutoGenerateColumns="False"  
                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px"
                            CellPadding="3" CellSpacing="2" Width="100%" 
                    onrowdatabound="gvBindyifahuo_RowDataBound" >
                    <Columns>
                        <asp:BoundField DataField="orderID" HeaderText="订单号">
                        <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="priceTotal" DataFormatString="{0:C2}" 
                            HeaderText="产品总价" HtmlEncode="False">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="freightTotal" DataFormatString="{0:C2}" 
                            HeaderText="邮费总价" HtmlEncode="False">
                        <ItemStyle Width="100px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="订单总价">
                            <ItemTemplate>
                                <asp:Label ID="lbOrderPT" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" ForeColor="Red" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="AcceptName" HeaderText="收货人" />
                        <asp:BoundField DataField="ZipCode" HeaderText="邮编" />
                        <asp:BoundField DataField="OrderTime" HeaderText="下单时间" 
                            DataFormatString="{0:d}" HtmlEncode="false" />
                        <asp:TemplateField HeaderText="订单状态">
                            <ItemTemplate>
                                 <asp:Label ID="lbOrderState" runat="server"></asp:Label>
                            </ItemTemplate>
                            <ItemStyle Width="100px" ForeColor="Red" />
                       </asp:TemplateField>
                    </Columns>
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                       <div>没有发货订单!!</div>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                </asp:GridView>
            </td>
        </tr>
         <tr>
            <td>
                <uc1:myPagelist ID="plist8571" runat="server" />
             </td>
        </tr>
         <tr>
            <td style="color: #000080">注:管理员发货详细订单</td>
        </tr>
    </table>
</div>
</asp:Content>

