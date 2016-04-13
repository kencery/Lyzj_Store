<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/MasterPage.master" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="proscenium_product_ProductList" %>

<%@ Register src="../../admin/tool/myPagelist.ascx" tagname="myPagelist" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/Logo.css" rel="stylesheet" type="text/css" />
    <link href="../../css/foot.css" rel="stylesheet" type="text/css" />
    <link href="../../css/product.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <img src="../images/logo123.jpg" alt="陇原商城" style="width: 999px; height: 92px" />
</div>
<div class="products">
    <div class="productsone">
        <div class="productsleft">
            <div class="produstsleftone">
                <ul>
                    <li><strong>所有类型展示</strong></li>
                </ul>
            </div>
            <div class="productslefttwo">
                <div class="productsnav">
                    <asp:GridView ID="GridView1" runat="server">
                    </asp:GridView>
                </div>
                <div class="productsnews">
                    <img src="../../images/Products_15.gif" alt="陇原商城" />
                      <ul>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				         <li>丹尼斯（20520）</li>
				     </ul>
                </div>
            </div>
            <div class="productsleftfoot">
                <img src="../../images/Productsfoot.gif" alt="陇原商城" />
            </div>
        </div> 
        <div class="productsright">
            <div class="productsrighttop">
                <img src="../images/Products_03.gif" alt="陇原商城" />
            </div>
            <div class="productsrightcont">
                <div class="productsrighttheir">
                    <img src="../images/Products_05.gif" alt="陇原商城" />
                </div>
                <div class="productsrighttheir1">
                    <ul>
                       <asp:Literal ID="liCurrClass" runat="server" EnableViewState="false"></asp:Literal> 
                    </ul>
                    <div class="produstsrightneir1r">
					   排列方式：
					   <span style=" margin:2px;">
					        <asp:DropDownList ID="ddlOrder" runat="server" AutoPostBack="True" >
                            <asp:ListItem Value="y">请选择排序方式</asp:ListItem>
                                <asp:ListItem Value="1">价格从大到小</asp:ListItem>
                                <asp:ListItem Value="0">价格从小到大</asp:ListItem>
                            </asp:DropDownList>
					   </span>
					</div>
					<div class="fclear">
                         <uc1:myPagelist ID="plList8531" runat="server" />
                    </div>
                </div>
                 <div class="productsonechanpin">
                   <asp:DataList ID="rpDataList" runat="server" EnableViewState="false" 
                         RepeatColumns="5" RepeatDirection="Horizontal" Width="753px" Height="68px">
                        <ItemTemplate>
                            <table align="center" cellpadding="0" cellspacing="0" class="style1">
                                <tr>
                                    <td colspan="2">
                                        <a href="ProductInfo.aspx?PId=<%# Eval("productID") %>" title="<%# Eval("ProductName").ToString()%>">
                                 <asp:Image ID="Image1" runat="server" Width="110px" Height="110px" ImageUrl= '<%# "~/photo/"+Eval("ProductImage").ToString()%>' AlternateText='<%# Eval("productName","{0}") %>' />
                                </a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>
                                        <%# Eval("Price")%></td>
                                    <td>
                                        <%# Eval("MenberPrice")%></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <a href="ProductInfo.aspx?PId=<%# Eval("ProductId") %>" title="<%# Eval("ProductName").ToString()%>"><%# (Eval("ProductName").ToString().Length > 10) ? Eval("ProductName").ToString().Substring(0,10): Eval("ProductName")%></a>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td><a href="tencent://message/?uin=<%# Eval("LinkQQId") %>&amp;Site=8517&amp;Menu=yes" title="<%# Eval("LinkQQName") %>" target="blank">
                                     <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Productstt_30.gif" ToolTip="分水网上超市 QQ" style=" float:left;" /></a></td>
                                    <td><img id="imgCollection" src="../Images/Productstt_32.gif" alt="分水网上超市 QQ" style=" float:right;cursor:pointer;" onclick="return addcollectionProduct(<%# Eval("ProductId") %>)"/></td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </ItemTemplate>
                   </asp:DataList>
                    </div>
                   </div>
		         <div class="produstsrightfoot">
                      <asp:Image ID="Image8" runat="server" ImageUrl="~/proscenium/images/Products_21.gif"/></div>
		         </div>
            </div>
        </div>
</asp:Content>

