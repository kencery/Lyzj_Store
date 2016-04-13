<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/AcceptAddrInfo/MasterPage.master" AutoEventWireup="true" CodeFile="OrderList.aspx.cs" Inherits="proscenium_AcceptAddrInfo_OrderList" %>

<%@ Register src="../../admin/tool/myPagelist.ascx" tagname="myPagelist" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/accept.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="#" title="等待付款订单">等待付款订单</a></li>
            <li class="now"><a href="#" title="等待发货订单">等待发货订单</a></li>
            <li class="now"><a href="#" title="已发货订单">已发货订单</a></li>
            <li class="now"><a href="#" title="备注">备注</a></li>
        </ul>
    </div>
</div>
<div class="AdminContent">
    <table cellpadding="0" cellspacing="0" class="AdminTable" style="border:1px solid red;">
        <tr>
            <td class="AdminTableTitle">等待付款订单和订单明细管理</td>
        </tr>
        <tr>
            <td class="FieldValue">
                <asp:GridView ID="gvBindOrderListInfo" AutoGenerateColumns="False" 
                    BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" 
                    CellPadding="3" CellSpacing="2" runat="server" Width="100%" onrowdatabound="gvBindOrderListInfo_RowDataBound">
                    <Columns>
                        
                        <asp:BoundField DataField="orderID" HeaderText="订单号">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="130px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PriceTotal" DataFormatString="{0:C2}" 
                            HeaderText="产品总价" HtmlEncode="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FreightTotal" DataFormatString="{0:C2}" 
                            HeaderText="邮费总价" HtmlEncode="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="订单总价">
                            <ItemTemplate>
                               <asp:Label ID="lbOrderPT" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="100px" ForeColor="Red" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="订单状态">
                            <ItemTemplate>
                                <asp:Label ID="lbOrderState" runat="server" Text="Label"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="200px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="orderTime" DataFormatString="{0:d}" 
                            HeaderText="提交时间" HtmlEncode="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Button" CommandName="pay" HeaderText="付款" ControlStyle-CssClass="OrderBtnPay">
                        <ControlStyle CssClass="OrderBtnPay" />
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="80px" HorizontalAlign="Center" />
                        </asp:ButtonField>
                        
                        <asp:HyperLinkField DataNavigateUrlFields="orderID" 
                            DataNavigateUrlFormatString="lookOrderDetails.aspx?orderID={0}" HeaderText="操作" 
                            Text="订单明细">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Font-Underline="False" HorizontalAlign="Center" Width="120px" />
                        </asp:HyperLinkField>
                    </Columns>
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <EmptyDataTemplate>
                        <div class="noinfo">没有等待付款的订单!!</div>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <RowStyle Height="30px" HorizontalAlign="Center" BackColor="#FFF7E7"  ForeColor="#8C4510" />
                </asp:GridView>
            </td>
        </tr>
    </table>
    <div class="pageRow">
        <uc1:myPagelist ID="pList8517" runat="server" />
    </div>
</div>
</asp:Content>

