<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/AcceptAddrInfo/MasterPage.master" AutoEventWireup="true" CodeFile="lookOrderDetails.aspx.cs" Inherits="proscenium_AcceptAddrInfo_lookOrderDetails" %>

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
            <td class="AdminTableTitle">订单明细记录</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvMinuterOrderList" runat="server" BackColor="#DEBA84" BorderColor="#DEBA84"
                         BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" 
                    Width="100%"  AutoGenerateColumns="False" 
                    onrowdatabound="gvMinuterOrderList_RowDataBound">
                    <Columns>
                        <asp:TemplateField HeaderText="产品图片">
                            <ItemTemplate>
                                <asp:Image ID="imgSmall" runat="server" Width="80px" Height="60px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="产品名称" DataField="productName" />
                        <asp:BoundField HeaderText="订单号" DataField="orderID" >
                        <ItemStyle Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="产品单价" DataField="memberPrice" 
                            DataFormatString="{0:C2}" HtmlEncode="False" >
                        <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="购买数量" DataField="bugNum" HtmlEncode="False" >
                        <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="快递费" DataField="Freign" DataFormatString="{0:C2}" >
                        <ItemStyle Width="120px" />
                        </asp:BoundField>
                    </Columns>
                      <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                      <EmptyDataTemplate>
                          <div class="NoInfo">这个订单中没有产品!!，请您重新下订单</div>
                      </EmptyDataTemplate>
                      <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                      <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                      <RowStyle Height="30px" HorizontalAlign="Center" BackColor="#FFF7E7"  ForeColor="#8C4510" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="text-align:center">
                <br />
                <asp:Button ID="btnReset" runat="server" Text="返回到订单管理" 
                    onclick="btnReset_Click" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>

