<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="lookOrderDetails.aspx.cs" Inherits="admin_orderlist_lookOrderDetails" %>

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
             <td style="font-size: 22px; font-weight: bold; color: #FF00FF; font-style: normal; background-color: #C0C0C0;">发货商品详细信息</td>
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
                        <asp:BoundField DataField="ProNumber" HeaderText="产品型号" ReadOnly="True" >
                        <ItemStyle Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="产品名称" DataField="productName" >
                        <ItemStyle Width="200px" />
                        </asp:BoundField>
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
                          <div>这个订单中没有任何产品!!，请您重新下订单在查看</div>
                      </EmptyDataTemplate>
                      <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                      <HeaderStyle HorizontalAlign="Center" BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                      <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                      <RowStyle Height="30px" HorizontalAlign="Center" BackColor="#FFF7E7"  ForeColor="#8C4510" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnResent" runat="server" Text="返回跳转页" 
                    onclick="btnResent_Click" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>

