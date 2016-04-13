<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgetPassWord.aspx.cs" Inherits="user_ForgetPassWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="Stylesheet" type="text/css" href="../css/userlogin.css" />
    <title>陇原网上商城找回密码页</title>
</head>
<body>
 <form id="form1" runat="server">
    <div class="main">
        <div class="top">
            <div class="topleft">
                <img src="../images/logoo.jpg" alt="陇原商城欢迎您" />
            </div>
            <div class="topright">
                <br />
                <br />
&nbsp;<br />
                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                    PostBackUrl="~/user/UserLogin.aspx">跳转到登录页</asp:LinkButton>
                    
                &nbsp;
                    
                <asp:LinkButton ID="linkIndex" runat="server" CausesValidation="False" 
                    PostBackUrl="~/proscenium/Index.aspx">陇原商城首页</asp:LinkButton>
&nbsp;&nbsp;
                <asp:LinkButton ID="linkHelp" runat="server" CausesValidation="False" 
                    PostBackUrl="~/proscenium/HelpInfo/HelpList.aspx">新手帮助</asp:LinkButton>
            </div>
        </div>
        <div class="logincontentdenglu">
            <div class="logincontentleft">
                <div class="loginleftbt">
                    <p style="height: 41px; font-size:32px; width: 265px; color:Gray">用户找回密码信息</p></div>
                <div class="loginleftbtneir">
                    <div class="loginlefttop"><img src="../images/logo08.gif" alt="陇原商城" /></div>
                    <div class="loginleftbtneircount">
                        <div class="logindenglu">
                            <ul>
                                <li>用 户 名：<asp:TextBox ID="txtUserName" runat="server" MaxLength="20" Width="125px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUserName" runat="server" 
                                        ErrorMessage="用户名不能为空！" ControlToValidate="txtUserName" Display="Dynamic">*</asp:RequiredFieldValidator></li>
                            </ul>
                        </div>
                        <div class="logindenglu">
                            <ul>
                                <li>您的邮箱：<asp:TextBox ID="txtEmail" 
                                        TextMode="Password" MaxLength="32" runat="server" Width="125px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvUserPwd" runat="server" 
                                        ErrorMessage="密码不能为空!" ControlToValidate="txtEmail" Display="Dynamic">*</asp:RequiredFieldValidator></li>
                            </ul>
                        </div>
                        <div class="logindenglu">
                            <ul>
                                <li>验 证 码：<asp:TextBox ID="txtCodeNum" runat="server" Width="125px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvLoginCode" runat="server" 
                                        ErrorMessage="验证码不能为空" ControlToValidate="txtCodeNum" Display="Dynamic">*</asp:RequiredFieldValidator></li>
                                <li><img src="../Tool/CheckInage.aspx" onclick="this.src=this.src+'?'" alt="陇原商城" id="imgcode" title="点击刷新验证码" style="vertical-align:middle; cursor:pointer; margin:0px; padding:0px;" /></li>
                            </ul>
                        </div>
                        <div class="logindenglu">
                            <ul>
                                <li>
                                </li>
                            </ul>
                        </div>
                       <div class="logindenglu1" align="center">
                                <asp:Button ID="btnzhaohuiPassword" runat="server" Text="找回密码" 
                                    onclick="btnzhaohuiPassword_Click" />
                       </div>
                       <div class="frientprompt">
                        <ul>
                            <li>安全登陆陇原网上商城</li>
                            <li>保护您的密码，请阅读密码安全贴士。 </li>
						    <li>防止病毒或者木马窃取您的账户信息，检查您的电脑是否安全.</li>
                        </ul>
                       </div>
                       <div class="loginline"></div>
                    </div>
                    <div class="loginlefttop"><img src="../images/logo51.gif" alt="会员注册"/></div>
                </div>
            </div>
            <div class="loginleftregister">
                <div class="loginregister"></div>
                <div class="loginreguster1">
                    <div class="loginregisteruserphoto"><img src="../images/regvip.jpg" alt="会员注册" /></div>
                    <div class="loginregisterfirend">
                        <div class="loginregisterfirendtop"><img src="../images/logo11.gif" alt="会员注册"/></div>
                        <div class="loginregisterfirendcout">
                            <div class="loginshow">
                                <ul>
                                    <li><img src="../images/logo16.gif" alt="友情提示" /><strong><span style="font-size:14px; color:#0066ff; margin-left:5px;">便宜有好货！</span><span>所有商品任你选</span></strong></li>
                                    <li><img src="../images/logo19.gif" alt="友情提示"/><strong><span style="font-size:14px; color:#0066ff; margin-left:5px;">买卖更安心！</span><span>支付宝交易更安全</span></strong></li>
                                    <li><img src="../images/logo28.gif" alt="友情提示" /><strong><span style="font-size:14px; color:#0066ff; margin-left:5px;">超人气社区！</span><span>精彩活动每一天</span></strong></li>
                                </ul>
                            </div>
                            <div class="registerphoto"><a href="UserRegister.aspx" title="会员注册"><img src="../images/logo39.gif" alt="会员注册" /></a></div>
                        </div>
                        <div><img src="../images/logofoot.gif" alt="陇原商城"  /></div>
                    </div>
                </div>
            </div>
        </div>
        <asp:ValidationSummary ID="vs验证" runat="server" ShowMessageBox="True" 
            ShowSummary="False" />
         <div class="foot">
                <div class="footindex">
                     <ul>
                          <li>免费注册 | 搜索商品 | 如何购物 |买家信息：购物车 | 我的订单 | 我的积分 |商城服务：7天无理由退款 | 积分使用 | 入驻商城 |</li>
                          <li>客服电话：13756862553   注：客服热线吧受理商品咨询! 如需购买咨询 请直接联系该商品的商家</li>
                          <li>关于陇原网上商城 | 帮助中心 | 联系我们 | 版权说明 | 各类商品 | 积分查询 | 返回首页|</li>
                          <li>20011－2022@版权所有 中国·陇原商城有限责任公司  QQ:934532778 </li>
                     </ul>
               </div>
           </div>
                            <ul>
                                <li>
                                </li>
                            </ul>
        </div>
    <asp:TextBox ID="txtbackUrl" runat="server" Visible="False"></asp:TextBox>
</form>
</body>
</html>
