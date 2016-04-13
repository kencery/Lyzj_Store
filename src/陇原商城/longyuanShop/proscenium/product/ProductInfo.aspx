<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/MasterPage.master" AutoEventWireup="true" CodeFile="ProductInfo.aspx.cs" Inherits="proscenium_product_ProductInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/Logo.css" rel="stylesheet" type="text/css" />
    <link href="../../css/foot.css" rel="stylesheet" type="text/css" />
    <link href="../../css/product.css" rel="stylesheet" type="text/css" />
    <script src="../../js/CartJs.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <div class="products">
        <div class="productsone">
            <div class="productsleft">
                <div class="productsnews">
                    <img src="../images/Products_12.gif" alt="陇原商城" />
                    <div class="tuijian">
                        <ul>
                             <asp:Repeater ID="rpIsCommendDress_001" runat="server">
                                 <ItemTemplate>
                                     <li>&nbsp;
                                         <a href="ProductInfo.aspx?Pid=<%# Eval("productID")%>" title="<%# Eval("productName")%>">
                                         <%# Container.ItemIndex+1%>、<%# (Eval("productName").ToString().Length>13)?Eval("productName").ToString().Substring(0,13):Eval("productName")%></a>
                                     </li>
                                  </ItemTemplate>
                             </asp:Repeater>
                         </ul>
                    </div>
                </div>
            </div>
            <div class="productsright">
                <div class="productsrighttop"><img src="../images/Products_03.gif" alt="陇原商城" /></div>
                <div class="productsrightcont">
                    <div class="productsdetails">
                        <asp:Literal ID="liClass" runat="server"></asp:Literal>
                    </div>
                    <div class="ProDetails">
                        <div class="ProImg">
                            <div>
                              <img src='<%="../../photo/"+pInfo.ProductImage%>' alt="<%=pInfo.ProductName%>" style="width:100%; height:100%; cursor:pointer;" alt="陇原商城" />
                            </div>
                        </div>
                        <div class="ProParameter">
                            <table cellpadding="0" cellspacing="0" style="margin:5px;">
                                <tr>
                                    <td style="height:32px; line-height:32px; font-size:14px; font-weight:bold; color:#AE0286; padding-left:5px;" colspan="4">
                                        <img src="../images/Productsgoumaizztu_06.gif" alt="指示" style="width:24px; height:18px; vertical-align:middle;"/><span><%= pInfo.ProductName%></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="name">市场价格：</td>
                                    <td class="value"><span class="red"><%=string.Format("{0:C2}",pInfo.Price)%></span>元</td>
                                    <td class="name">优惠价格：</td>
                                    <td class="value"><span class="red"><%=string.Format("{0:C2}",pInfo.MenberPrince)%></span>元</td>
                                </tr>
                                <tr>
                                    <td class="name" style="height:16px;">快递费：</td>
                                    <td class="value" style="height:16px;"><span class="red"><%=string.Format("{0:C2}",pInfo.Freight)%></span>元</td>
                                    <td class="name" style="height:16px;">马上节省：</td>
                                    <td class="value" style="height:16px;"><span class="red"><%=string.Format("{0:C2}",pInfo.Price-pInfo.MenberPrince) %></span>元</td>
                                </tr>
                                <tr>
                                    <td class="name" style="height:16px;">上架日期：</td>
                                    <td class="value" style="height:16px;"><span class="red"><%=pInfo.Addtime.ToShortDateString()%></span></td>
                                    <td class="name" style="height:16px;">有效日期：</td>
                                    <td class="value" style="height:16px;">还剩<span class="red"><%=remainDayNum %></span>天</td>
                                </tr>
                                <tr>
                                    <td class="name" style="height:16px;">已卖出：</td>
                                    <td class="value" style="height:16px;"><span class="red">10</span></td>
                                    <td class="name" style="height:16px;">点击数：</td>
                                    <td class="value" style="height:16px;"><span class="red"><%=pInfo.ClickNum %></span>&nbsp;次</td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="height:5px; overflow:hidden;"></td>
                                </tr>
                                <tr>
                                    <td style="text-align:left; height:16px; padding-left:15px;">
                                       <a href="tencent://message/?uin=934532778&amp;Site=8517&amp;Menu=yes" title="<%=pInfo.LinkQQName %>" target="blank">
				                       <asp:Image ID="Image7" runat="server" ImageUrl="~/proscenium/images/btn_QQ.gif" style=" width:77px; height:17px;" ToolTip="QQ客服" /></a>
                                    </td>
                                    <td style="height:16px;">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <a href="tencent://message/?uin= 2439184950&amp;Site=8517&amp;Menu=yes" title="<%=pInfo.LinkQQName %>" target="blank">
				                       <asp:Image ID="Image8" runat="server" ImageUrl="~/proscenium/images/btn_QQ.gif" 
                                            style=" width:77px; height:17px;" ToolTip="QQ客服" /></a>
                                    </td>
                                    <td style="height:16px;">
                                        <img src="../images/Productstt_32.gif" alt="收藏产品" style="cursor:pointer;" onclick="retutn addcollectionProduct(<%=pInfo.ProductID %>)"/>
                                        
                                    </td>
                                    <td style="height:16px;"></td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align:left; padding-left:15px;">
                                        购买数：<input type="text" id="txtBuyNum" style="width:50px; height:14px; line-height:14px;" maxlength="10" value="1" />&nbsp;&nbsp;&nbsp;&nbsp;
                                        <!--<asp:TextBox ID="txtBuyNum" runat="server" style=" width:50px; height:14px; line-height:14px;" MaxLength="10" Text ="1"></asp:TextBox>-->
                                        商品总数<span class="red"><%=pInfo.ProducStore %></span><%=pInfo.Danwei%>
                                        <input id="txtBuyBigNum" type="hidden" value="<%=pInfo.ProducStore%>" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" style="text-align:center; padding-left:15px; padding-top:8px;">
                                   <asp:ImageButton ID="imgBuyProduct" runat="server" ImageUrl="~/proscenium/images/Productsgoumai_10.gif" ToolTip="购物" onclick="imgBuyProduct_Click" />
                                    </td>
                                </tr>
                                
                            </table>
                            <div class="cartline"></div>
                        </div>
                    </div>
                    <div class="detailstwo">
                        <div class="detailstwo1"><img src="../images/Productsgoumaizz_06.gif" alt="陇原商城" /></div>
                        <div class="detailstwo2">
                            <div class="detailstwobz" style="background-color: #CCCCCC">
                                <ul>
                                    <li style="color:#0066FF;"><strong>产品详情trong></li>
                                </ul>
                            </div>
                        </div>
                        <div class="detailsfor">
                            &nbsp;&nbsp;&nbsp;<%=pInfo.ProductDesc%>
                        </div>
                    </div>
                </div>
                <div class="productsrightfoot"><img src="../images/Products_21.gif" alt="陇原商城"/></div>
            </div>
        </div>
  </div>
    <asp:TextBox ID="txtId" runat="server" Visible="false"></asp:TextBox>
    </strong>
</asp:Content>

