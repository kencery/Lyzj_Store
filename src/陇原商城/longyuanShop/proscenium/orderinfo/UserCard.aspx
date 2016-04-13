<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/MasterPage.master" AutoEventWireup="true" CodeFile="UserCard.aspx.cs" Inherits="proscenium_orderinfo_UserCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/Logo.css" rel="stylesheet" type="text/css" />
    <link href="../../css/foot.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cart.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript" src="../../js/CartJs.js"></script>
    <div><img src="../images/logo2.png" alt="陇原商城" style="width: 1000px" /></div>
    <div class="cartcont">
        <div class="cartwenzi">
            <ul>
                <li><a href="../Index.aspx" target="_blank">首页</a>&nbsp;></li>
                <li><a href="#" target="_blank">购物车管理</a>&nbsp;></li>
                <li>我的购物车</li>
            </ul>
        </div>
        <div class="cartdh">
            <ul>
                <li><strong>购物车</strong></li>
                <li><strong>收藏夹</strong>(收藏产品)</li>
                <li><strong>订单(数量)</strong></li>
                <li><strong>积分查询</strong></li>
            </ul>
        </div>
        <div class="cartthere">
            <div class="cartthere1"><img src="../images/cart_07cici.gif" alt="加入购物车" /></div>
            <div class="cartthere2"><img src="../images/cart_08.gif" alt="" /></div>
            <div class="cartthere3"><img src="../images/cart_09.gif" alt="" /></div>
            <div class="cartthere4"><img src="../images/cart_10.gif" alt="" /></div>
            <div class="cartthere5"><img src="../images/cart_11.gif" alt="" /></div>
            <div class="cartthere6"><img src="../images/cart_12.gif" alt="" /></div>
        </div>
        <div class="cartInfo" id="CartList">
            <table style="width:100%; margin-top:5px; padding:5px; border:none;" cellpadding="0" cellspacing="0">
                <tr class="cartListTitle">
                    <td>商品名称/图片</td>
                    <td class="FieldName100">单价</td>
                    <td class="FieldName120">数量</td>
                    <td class="FieldName120">本商品合计</td>
                    <td class="FieldName80" style="width:134px;">操作</td>
                </tr>
                <asp:DataList ID="ddlBindIndexShoppingCartInfo" runat="server" 
                    RepeatDirection="Horizontal" RepeatLayout="Flow" >
                    <ItemTemplate>
                        <tr class="cartListRow">
                            <td style="text-align:left;">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/photo/"+Eval("ProSmallPath").ToString()%>' ToolTip="产品图片"/>
                                <p class="wenzi">
                                    <a href="../product/ProductInfo.aspx?PId=<%# Eval("ProductID")%>" title="<%# Eval("ProductName")%>" target="_blank"><%# (Eval("ProductName").ToString().Length>15)?Eval("ProductName").ToString().Substring(0,15):Eval("ProductName")%></a>
                                </p>
                            </td>
                            <td class="FieldName100"><%# Eval("MenberPrice","{0:C2}")%></td>
                            <td class="FieldName120">
                                <input type="text" id="txtBuyNum_<%# Eval("ProductID")%>" maxlength="5" style="width:80px;" onblur="Cart8517.ChangeBuyNum('<%# Eval("CartID")%>',<%# Eval("ProductID")%>);" value="<%# Eval("BuyNum")%>" />
                            </td>
                            <td class="FieldName120"><%# Eval("MoneyAmount", "{0:C2}")%></td>
                            <td class="FieldName80">
                               <asp:LinkButton ID="linkDelete" runat="server" CommandName="Delete" Text="删除" OnClientClick="return confirm('您确定要删除你所选择的商品吗？')" onclick="linkDelete_Click">删除</asp:LinkButton>
                               <%-- <a href="javascript:void(0);" onclick="Cart8517.DelCartProduct('<%# Eval("CartId")%>','<%# Eval("ProductId")%>');" title="删除">删除</a>--%>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:DataList>
                <tr class="cartListRow">
                    <td colspan="5" style="text-align:right; height:26px;">总价(包含邮费):<span class="red"><%=moneyTotal%></span>元</td>
                </tr>
            </table>
        </div>
        <div class="cartline">
            <div class="linetwo">
                <div class="linetwo1">
                    <a href="../product/ProductList.aspx" title="继续购物">
                        <img src="../images/cart_23.gif" alt="继续购物" style="cursor:pointer;" />
                    </a>
                </div>
                <div class="linetwo2">
                    <a href="../orderinfo/BalanceCart.aspx" title="结算"><img src="../images/cart_25.gif" alt="结算" style="cursor:pointer;" /></a>
                </div>
            </div>
        </div>
        <div class="cartbottom">
            <div class="cartbottomnav"><img src="../images/cart_30.gif" alt="推荐商品"/></div>
            <div class="cartbottomcici">
                <asp:DataList ID="ddlBindIndextuijianShopping" RepeatDirection="Horizontal" 
                    runat="server" RepeatColumns="5">
                    <ItemTemplate>
                        <div class="cartbottomcicione">
                            <a href="../product/ProductInfo.aspx?PId=<%# Eval("ProductID")%>" title="<%# Eval("ProductName")%>" target="_blank">
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# "~/photo/"+Eval("ProductImage").ToString()%>'/>
                            </a>
                            <ul>
                                <li><a href="../product/ProductInfo.aspx?PId=<%# Eval("ProductID")%>" title="<%# Eval("ProductName")%>" target="_blank"><%# (Eval("ProductName").ToString().Length>14)?Eval("ProductName").ToString().Substring(0,14):Eval("ProductName") %></a></li>
                                <li>抢购价:<%# Eval("MenberPrince", "{0:C2}")%></li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </div>
</asp:Content>

