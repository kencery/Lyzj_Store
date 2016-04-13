<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/AcceptAddrInfo/MasterPage.master" AutoEventWireup="true" CodeFile="ManageAcceptAddr.aspx.cs" Inherits="proscenium_AcceptAddrInfo_ManageAcceptAddr" %>

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
    <style type="text/css">
        .style2
        {
            height: 17px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="ManageAcceptAddr.aspx" title="管理收货地址">管理收货地址</a></li>
            <li class="now"><a href="AddAcceptAddr.aspx" title="添加收货地址">添加收货地址</a></li>
            <li class="now"><a href="ManageAcceptAddr.aspx" title="删除收货地址">删除收货地址</a></li>
            <li class="now"><a href="ManageAcceptAddr.aspx" title="修改收货地址">修改收货地址</a></li>
        </ul>
    </div>
</div>
<div class="AdminContent">
    <table cellpadding="0" cellspacing="0" class="AdminTable" style="border:1px solid red;">
        <tr>
            <td class="AdminTableTitle">管理收货人地址</td>
        </tr>
        <tr>
            <td class="FieldValue">
                <asp:GridView ID="gvDataListBindAccept" runat="server" BackColor="#DEBA84" 
                    BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" 
                    CellSpacing="3" Width="100%" AutoGenerateColumns="False" AllowPaging="True" 
                    onpageindexchanging="gvDataListBindAccept_PageIndexChanging" 
                    onrowdatabound="gvDataListBindAccept_RowDataBound" PageSize="8">
                    <Columns>
                        <asp:TemplateField HeaderText="&lt;input type='checkbox' id='cbAll' name='cbAll' onclick='selAll(this.checked);' /&gt;反选">
                            <ItemTemplate>
                                <input id="cbName" type="checkbox" name="cbName" value='<%# DataBinder.Eval(Container.DataItem,"ID")%>' />
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Width="60px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="realityName" HeaderText="姓名" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="100px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="详细地址">
                            <ItemTemplate>
                                <asp:Label ID="lbDetailsAddr" runat="server"></asp:Label>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="操作" Text="修改信息" DataNavigateUrlFields="id" 
                            DataNavigateUrlFormatString="AddAcceptAddr.aspx?InfoID={0}" >
                        <HeaderStyle HorizontalAlign="Center" />
                        <ItemStyle Width="120px" Font-Underline="false" HorizontalAlign="Center" />
                        </asp:HyperLinkField>
                    </Columns>
                    <PagerStyle HorizontalAlign="Center" ForeColor="#8C4510" />
                    <EmptyDataTemplate>
                        <div class="noinfo">您还没有添加收货地址呢？请您添加</div>
                    </EmptyDataTemplate>
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <RowStyle Height="30px" HorizontalAlign="Center" BackColor="#FFF7E7" ForeColor="#8C4510" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td class="style2" 
                style="font-weight: bold; color: #FF00FF; text-align: center;">收货人地址每个用户只能添加10个，请用户注意：</td>
        </tr>
        <tr>
            <td class="FieldValue" style="text-align:center">
                <asp:Button ID="btnDel" runat="server" Text="删除选中的信息" 
                    OnClientClick="return confirm('您确定要删除这些信息吗？')" onclick="btnDel_Click" 
                    Height="26px" />
            </td>
        </tr>
    </table>
</div>
</asp:Content>

