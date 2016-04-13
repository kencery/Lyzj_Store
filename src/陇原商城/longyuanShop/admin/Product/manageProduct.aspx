<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="manageProduct.aspx.cs" Inherits="admin_Product_manageProduct" %>

<%@ Register src="../tool/myPagelist.ascx" tagname="myPagelist" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
        function selAll(boolValue)
        {
            var obj=document.getElementsByName("cbName");
            var cbNameLen=obj.length;
            if(cbNameLen>1) 
            { 
                for(var i=0;i<cbNameLen;i++) 
                { 
                    if(obj[i].checked)
                    {
                        obj[i].checked=false;
                    }
                    else
                    {
                        obj[i].checked=true;
                    }
                }
                
            } 
            else 
            {
                obj.checked = boolValue; 
            }
        }
        
        function clickBtnCheck()
        {
            var obj=document.getElementsByName("cbName");
            var cbNameLen=obj.length;
            var Flag=false;
            if(cbNameLen>0)
            {
                for(var i=0;i<cbNameLen;i++) 
                { 
                    if(obj[i].checked)
                    {
                        Flag=true;
                        break;
                    }
                } 
                if(Flag)
                {
                    return true;
                }
                else
                {
                    alert("请先选择要操作的记录！！");
                    return false;
                }
            }
            else
            {
                alert("现在没有记录，不能操作！！");
                return false;
            }
        }
    </script>
<div>
    <div class="AdminNav">
        <div>
            <ul>
                <li><a href="AddProduct.aspx">添加产品</a></li>
                <li><a href="manageProduct.aspx">管理产品</a></li>
                <li><a href="manageProduct.aspx">推荐产品</a></li>
                <li><a href="manageProduct.aspx">下架产品</a></li>
                <li><a href="AddCategoryInfo.aspx">产品类别</a></li>
            </ul>
        </div>
    </div>
    <div id="AdminContent">
        
        <table align="center" cellpadding="0" cellspacing="0" 
            style="width: 820px; border: 1px solid #00FFFF">
            <tr>
                <td  style="background-color: #99CCFF; font-size:28px; font-weight: bold; font-style: italic; font-variant: normal; color: #FFFFFF;" 
                    align="center" colspan="3">
                    <asp:Label ID="lblshow" runat="server" Text="添加商品"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="gvProduct" runat="server" AutoGenerateColumns="False" 
                        onrowdatabound="gvProduct_RowDataBound" BackColor="LightGoldenrodYellow" 
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
                        GridLines="None" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="&lt;input type='checkbox' id='cbAll' name='cbAll' onclick='selAll(this.checked);' /&gt;反选">
                                <ItemTemplate>
                                   <input type="checkbox" id="cbName" name="cbName" value='<%# DataBinder.Eval(Container.DataItem, "ProductID")%>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:ImageField DataImageUrlField="productImage" HeaderText="产品图片" 
                                DataImageUrlFormatString="~/photo/{0}" ReadOnly="True">
                                <ControlStyle Height="60px" Width="80px" />
                                <ItemStyle Height="60px" Width="80px" />
                            </asp:ImageField>
                            <asp:BoundField DataField="ProductName" HeaderText="产品名称" >
                            <ControlStyle Width="120px" />
                            <ItemStyle Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CategoryName" HeaderText="产品类别" />
                            <asp:BoundField DataField="CurrentPrice" DataFormatString="{0:C2}" 
                                HeaderText="市场价" />
                            <asp:BoundField DataField="MenberPrice" DataFormatString="{0:C2}" 
                                HeaderText="会员价" >
                            <ControlStyle ForeColor="Red" />
                            <ItemStyle ForeColor="Red" />
                            </asp:BoundField>
                                
                            <asp:BoundField DataField="ProductStore" HeaderText="商品库存" />
                            <asp:TemplateField HeaderText="状态">
                                <ItemTemplate>
                                    <asp:Label ID="lbState" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="推荐产品">
                                <ItemTemplate>
                                    <asp:Label ID="lbtuijian" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="有效期">
                                <ItemTemplate>
                                    <asp:Label ID="lbHowDay" runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField HeaderText="操作" Text="修改" DataNavigateUrlFields="ProductID" 
                                DataNavigateUrlFormatString="AddProduct.aspx?pID={0}" />
                        </Columns>
                        <EmptyDataRowStyle BackColor="#CADBED" ForeColor="Red"  />
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <HeaderStyle HorizontalAlign="Center" BackColor="Tan" Font-Bold="True" />
                        <RowStyle Height="30px" HorizontalAlign="Center" />
                        <FooterStyle BackColor="Tan" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                            HorizontalAlign="Center" />
                        <EmptyDataTemplate>
                                <div>您的后台数据库还没有添加商品呢？请您添加!!</div>
                        </EmptyDataTemplate>
                        <RowStyle Height="30px" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                     <asp:Button ID="btnDel" runat="server" Text="删除产品" Height="30px" 
                         onclick="btnDel_Click" OnClientClick="return confirm('您确认要删除该商品吗？')" />
                     &nbsp;&nbsp;
                     <asp:Button ID="btnIsPost" runat="server" Text="产品上架" Height="30px" 
                         onclick="btnIsPost_Click" />
                     &nbsp;
                     <asp:Button ID="btnNotIsPost" runat="server" Text="产品下架" Height="30px" 
                         onclick="btnNotIsPost_Click" />
                    &nbsp;
                    <asp:Button ID="btnIsCommend" runat="server" Text="推荐产品" Height="30px" 
                         onclick="btnIsCommend_Click" CausesValidation="False" />
               &nbsp;
                     <asp:Button ID="btnCanceltuijian" runat="server" 
                         onclick="btnCanceltuijian_Click" Height="30px" Text="取消推荐商品" 
                         CausesValidation="False" />
               &nbsp;&nbsp;
                    <asp:Button ID="lblexcel" runat="server" CausesValidation="false"  Height="30px" Text="导出Excel" 
                         onclick="lblexcel_Click" />
               &nbsp;
                     <asp:Button ID="lbldaoru" runat="server" Text="导入Excel" 
                         CausesValidation="false" Height="30px" onclick="lbldaoru_Click" />
               </td>
            </tr>
            <tr>
                <td>
                    <uc1:myPagelist ID="pList8517" runat="server" />
                </td>
            </tr>
        </table>
        
    </div>
</div>  
</asp:Content>

