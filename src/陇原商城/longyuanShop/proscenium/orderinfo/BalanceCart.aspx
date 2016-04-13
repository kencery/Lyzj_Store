<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/MasterPage.master" AutoEventWireup="true" CodeFile="BalanceCart.aspx.cs" Inherits="proscenium_orderinfo_BalanceCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/foot.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Logo.css" rel="stylesheet" type="text/css" />
    <link href="../../css/cart.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function jsCheck() {
            var obj, Flag = true;
            obj = document.getElementsByName("<%=rbListAddr.UniqueID%>");
            if (obj != null) {
                var objLen = obj.length;
                if (objLen == 0) {
                    alert("请先添加收货地址！");
                    return false;
                }
                for (var i = 0; i < objLen; i++) {
                    if (obj[i].checked) {
                        Flag = false;
                        break;
                    }
                }
            }
            if (Flag) {
                alert("请选择收货地址！");
                return false;
            }
            if(confirm("确定要提交"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div><img src="../images/logo1.png" style="width: 995px; height: 101px" /></div>
<div class="cartcont">
    <div class="cartwenzi">
        <ul>
            <li><a href="../Index.aspx" target="_blank">首页</a>&nbsp;></li>
            <li><a href="#" target="_blank">购物车管理</a>&nbsp;></li>
            <li><a href="#" target="_blank">我的购物车</a></li>
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
            <div class="cartthere1"><img src="../images/cart_07.gif" alt="加入购物车" /></div>
            <div class="cartthere2"><img src="../images/cart_08.gif" alt="" /></div>
            <div class="cartthere3"><img src="../images/cart_09cici.gif"  alt=""/></div>
            <div class="cartthere4"><img src="../images/cart_10.gif" alt="" /></div>
            <div class="cartthere5"><img src="../images/cart_11.gif" alt="" /></div>
            <div class="cartthere6"><img src="../images/cart_12.gif" alt="" /></div>
    </div>
    <div class="AcceptAddr">
        <div style="font-size:14px; font-weight:bold; margin:5px;">收货人信息</div>
        <div>
            <asp:RadioButtonList ID="rbListAddr" runat="server">
            </asp:RadioButtonList>
        </div>
        <div style="margin-top:5px;">
            <asp:Label ID="lblInfo" runat="server"></asp:Label>
        </div>
    </div>
    <div class="cartInfo" id="CartList">
            <table style="width:100%; margin-top:5px; padding:5px; border:none;" cellpadding="0" cellspacing="0">
                <tr class="cartListTitle">
                    <td>商品名称/图片</td>
                    <td class="FieldName100">单价</td>
                    <td class="FieldName120">数量</td>
                    <td class="FieldName120">本商品合计</td>
                    <td class="FieldName100">运费</td>
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
                            <td class="FieldName120"><%# Eval("BuyNum")%><%# Eval("danWei")%></td>
                            <td class="FieldName120"><%# Eval("MoneyAmount", "{0:C2}")%></td>
                            <td class="FieldName100">快递：<%#Eval("Freight","{0:C2}")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:DataList>
                <tr class="cartListRow">
                    <td colspan="5" style="text-align:right; height:26px;">总价(包含邮费):<span class="red"><%=moneyTotal %></span>元</td>
                </tr>
            </table>
        </div>
        <div class="cartline">
            <div class="linetwo">
                <div class="linetwo2" style="float:right">
                    <asp:ImageButton ID="btnAdd" ImageUrl="~/proscenium/images/cart_25.gif" 
                        runat="server" onclick="btnAdd_Click" />
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
 <asp:TextBox ID="txtMoneyTotal" runat="server" Visible="false"></asp:TextBox>
</asp:Content>

