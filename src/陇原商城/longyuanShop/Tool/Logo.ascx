<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Logo.ascx.cs" Inherits="Tool_Logo" %>

<link href="../css/Logo.css" rel="stylesheet" type="text/css" />
<script type="text/javascript">
    pc.BindClassRoot("selectprompt");
</script>
<div id="main">
    <div id="top">
        <div id="tophone">
            <div id="topleft"></div>
            <div id="topright">
                <ul>
                    <li id="headerwelcome" class="fonts">欢迎光临陇原网上商城</li>
                </ul>
                <div class="register">
                    <ul>
                        <li id="registerlogin">
                            <asp:LinkButton ID="lnkRegister" runat="server" Height="15px" PostBackUrl="~/user/UserRegister.aspx" ToolTip="会员注册">会员注册</asp:LinkButton>  
                        </li>
                    </ul>
                </div>
                <div class="enroll">
                    <ul>
                        <li id="enrollLogin">
                            <asp:LinkButton ID="lnkenroll" runat="server" Height="15px" PostBackUrl="~/user/UserLogin.aspx" ToolTip="会员登录">会员登录</asp:LinkButton> 
                        </li>
                    </ul>
                </div>
                <div class="shopping">
                    <div class="photo">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/line.gif"/>
                    </div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton1" runat="server" Height="15px" PostBackUrl="~/proscenium/AcceptAddrInfo/AddAcceptAddr.aspx" ToolTip="个人信息">个人信息</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="photo">
                        <asp:Image ID="Image2" runat="server" ImageUrl="~/images/line.gif" />
                    </div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton2" runat="server" Height="15px" PostBackUrl="~/proscenium/HelpInfo/HelpList.aspx" ToolTip="帮助中心" >帮助中心</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="photo">
                       <asp:Image ID="Image3" runat="server" ImageUrl="~/images/line.gif" />
                    </div>
                    <ul>
                        <li>
                            <asp:HyperLink ID="HyperLink1" runat="server" Height="15px" ToolTip="联系我们" NavigateUrl="mailto:934532778@qq.com">联系我们</asp:HyperLink>
    <%--                        <asp:LinkButton ID="LinkButton3" runat="server" Height="15px" PostBackUrl="#" ToolTip="联系我们">联系我们</asp:LinkButton>--%>
                        </li>
                    </ul>
                    <div class="photo">
                        <asp:Image ID="Image4" runat="server" ImageUrl="~/images/line.gif" />
                    </div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton4" runat="server" Height="15px" OnClientClick="this.style.behavior='url(#default#homepage)';this.sethomepage('http://www.longyuan.com')" ToolTip="设为首页">设为首页</asp:LinkButton>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="topbus">
            <marquee style="width: 551px" scrolldelay="140"><asp:Image ID="Image8" runat="server" ImageUrl="~/images/png-2088.png" Width="25px" Height="25px" /><font size="5" color="red">你们的支持将是我们最大的帮助</font></marquee>
            </div>
        </div>
        <div class="navigation">
            <div class="navigationone">
                <div class="navigationtwo">
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton5" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">品牌</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton6" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">促销</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton7" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">女装</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton8" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">男装</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton9" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">运动</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton10" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">美容</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton11" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">手机</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton12" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">数码</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton13" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">家居生活</asp:LinkButton>
                        </li>
                    </ul>
                    <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton14" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">母婴</asp:LinkButton>
                        </li>
                    </ul>
                       <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton15" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">食品保健</asp:LinkButton>
                        </li>
                    </ul>
                       <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton16" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">图书音像</asp:LinkButton>
                        </li>
                    </ul>
                       <div class="navigationline"></div>
                    <ul>
                        <li>
                            <asp:LinkButton ID="LinkButton17" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">鞋包配饰</asp:LinkButton>
                        </li>
                    </ul>
                       <div class="navigationline"></div>
                </div>
            </div>
            <div class="navigationlinecenter">
                <div class="index">
                    <asp:LinkButton ID="LinkButton18" runat="server" PostBackUrl="~/proscenium/Index.aspx" ToolTip="陇原网上商城">
                        <asp:Image ID="Image5" runat="server" ImageUrl="~/images/shopping.gif" />
                    </asp:LinkButton>
                </div>
                <div class="navigationlinecentertwo">
                    <div class="navigationlinecentertwoindex">
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton19" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">服装</asp:LinkButton>
                            </li>
                        </ul>
                        <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton20" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">护肤</asp:LinkButton> 
                            </li>
                        </ul>
                        <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton21" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">相机</asp:LinkButton> 
                            </li>
                        </ul>
                        <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton22" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">减肥</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton23" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">童装</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton24" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">书籍</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton25" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">笔记本</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton26" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">秋冬装</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton27" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">特价手机</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton28" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">运动户外</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton29" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">新款靴子</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton30" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">保暖内衣</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton31" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">床品一折</asp:LinkButton> 
                            </li>
                        </ul>
                          <div class="mennavline"></div>
                        <ul>
                            <li>
                                <asp:LinkButton ID="LinkButton32" runat="server" PostBackUrl="~/proscenium/product/ProductList.aspx">珠宝首饰</asp:LinkButton> 
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="sousuo">
                    <div class="sousuoleft">
                        <div class="prompt">
                            <asp:DropDownList ID="ddlProductCategory" runat="server" Height="23px" 
                                Width="82px">
                            </asp:DropDownList>
                        </div>
                        <div class="promptkuan">
                            <input id="txtKeyWord"  name="txtKeyWord" type="text" maxlength="20" 
                                style="width: 117px"/>
                        </div>
                        <div class="gaojisousuo">
                            <asp:ImageButton ID="Image6" runat="server" ImageUrl="~/images/sousuo.gif" 
                                Width="128px" Height="21px" />
                        </div></div>
                        <div class="sousuoright">
                            <div class="sousuotwo">
                                <ul>
                                    <li>
                                        <asp:LinkButton ID="LinkButton33" runat="server" PostBackUrl="#">购物车有<span class="yanse">&nbsp;<strong><% %></strong>&nbsp;</span>种商品</asp:LinkButton>
                                    </li>
                                </ul>
                                <div class="sousuorightline"></div>
                                <ul>
                                    <li>
                                        <a href="#" title="">收藏夹</a>
                                    </li>
                                </ul>
                                 <div class="sousuorightline"></div>
                                <ul>
                                    <li>
                                        <a href="#" title="">我的订单</a>
                                    </li>
                                </ul>
                                 <div class="sousuorightline"></div>
                                <ul>
                                    <li>
                                        <a href="#" title="">积分</a>
                                    </li>
                                </ul>
                                 <div class="sousuorightline"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</div>