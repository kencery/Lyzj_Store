<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/AcceptAddrInfo/MasterPage.master" AutoEventWireup="true" CodeFile="ManagerOrderList.aspx.cs" Inherits="proscenium_AcceptAddrInfo_ManagerOrderList" %>

<%@ Register src="../../admin/tool/myPagelist.ascx" tagname="myPagelist" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/accept.css" rel="stylesheet" type="text/css" />
      <script type="text/javascript">
        function selAll(boolValue) {
            var obj = document.getElementsByName("cbName");
            var cbNameLen = obj.length;
            if (cbNameLen > 1) {
                for (var i = 0; i < cbNameLen; i++) {
                    if (obj[i].checked) {
                        obj[i].checked = false;
                    }
                    else {
                        obj[i].checked = true;
                    }
                }
            }
            else {
                obj.checked = boolValue;
            }
        }
    </script>
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
            <td class="AdminTableTitle">已付完款订单管理</td>
        </tr>
        <tr>
           <td>
               <asp:GridView ID="gvBindDetails" runat="server" BackColor="White" 
                   BorderColor="White" BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" 
                   CellSpacing="1" GridLines="None" Width="100%" AutoGenerateColumns="False" 
                   onrowdatabound="gvBindDetails_RowDataBound">
                   <RowStyle BackColor="#DEDFDE" ForeColor="Black" />
                   <Columns>
                       <asp:TemplateField HeaderText="&lt;input type='checkbox' id='cbAll' name='cbAll' onclick='selAll(this.checked);' /&gt;反选">
                            <ItemTemplate>
                                 <input id="cbName" type="checkbox" name="cbName" value='<%# DataBinder.Eval(Container.DataItem,"orderID")%>' />
                            </ItemTemplate>
                            <ItemStyle Width="80px" HorizontalAlign="Center" />
                       </asp:TemplateField>
                       <asp:BoundField DataField="OrderId" HeaderText="订单号">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="150px" HorizontalAlign="Center" />
                       </asp:BoundField>
                       <asp:BoundField HeaderText="产品总价" DataField="PriceTotal" DataFormatString="{0:C2}" HtmlEncode="false" >
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="100px" HorizontalAlign="Center" />
                       </asp:BoundField>
                       <asp:BoundField DataField="FreightTotal" HeaderText="邮费总价" DataFormatString="{0:C2}" HtmlEncode="false">
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
                                <asp:Label ID="lbOrderState" runat="server" ForeColor="Red" Text="Label"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="200px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="orderTime" DataFormatString="{0:d}" 
                            HeaderText="提交时间" HtmlEncode="False">
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        </asp:BoundField>                        
                   </Columns>
                   <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                   <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                   <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                   <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#E7E7FF" />
               </asp:GridView>
            </td> 
        </tr>
        <tr>
            <td style="text-align:center">
                <uc1:myPagelist ID="pList8517" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="text-align:center">
                <asp:Button ID="btnDelete" runat="server" Text="删除订单信息" OnClientClick="return confirm('您确定要删除吗？')" onclick="btnDelete_Click" />
            </td>
        </tr>
        <tr>
            <td style="font-weight: bold; color: #800080; text-align: center;">货物到手后用户可以删除订单信息，如果货物没到，请用户千万不要删除订单信息</td>
        </tr>
    </table>
</div>
</asp:Content>

