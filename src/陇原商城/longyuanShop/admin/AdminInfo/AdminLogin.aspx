<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AdminLogin.aspx.cs" Inherits="admin_AdminInfo_AdminLogin" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>陇原商城后台登录</title>
    <link href="../css/MainCss.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="LoginBar">
        <ul>
            <li class="LoginTop"></li>
            <li class="FormNav">
                 <dl>
					    <dt><label>用户名:</label>
                            <asp:TextBox ID="txtAmdinName" runat="server" CssClass="FormBase" onfocus="this.className='FormFocus';" onblur="this.className='FormBase';" MaxLength="20" style="width:200px"></asp:TextBox>
					        <asp:RequiredFieldValidator ID="rfvAdminName" runat="server" 
                                ControlToValidate="txtAmdinName" Display="Dynamic" ErrorMessage="用户名不能为空！">*必填项</asp:RequiredFieldValidator>
					    </dt>
					    <dt>
                            <label>密&nbsp;&nbsp; 码:</label>
                            <asp:TextBox ID="txtPwd" runat="server" CssClass="FormBase" 
                                onfocus="this.className='FormFocus';" onblur="this.className='FormBase';" 
                                MaxLength="20" style="width:200px" TextMode="Password"></asp:TextBox>
                            
					        <asp:RequiredFieldValidator ID="rfvAdminPwd" runat="server" 
                                ControlToValidate="txtPwd" Display="Dynamic" ErrorMessage="密码不能为空!">*必填项</asp:RequiredFieldValidator>
                            
					    </dt>
					    <dd><label>验证码</label>
					     <asp:TextBox ID="txtCodeNum" runat="server" CssClass="FormBase" 
                                onfocus="this.className='FormFocus';" onblur="this.className='FormBase';" 
                                MaxLength="5" style="width:130px"></asp:TextBox>
					        <img src="../../Tool/CheckInage.aspx" onclick="this.src=this.src+'?'" id="imgcode" title="点击刷新验证码" alt="点击刷新验证码" />
                            <asp:RequiredFieldValidator ID="rfvAdminCodeName" runat="server" 
                                ControlToValidate="txtCodeNum" Display="Dynamic" ErrorMessage="验证码不能为空!">*必填项</asp:RequiredFieldValidator>
					    </dd>
    					<dt>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="imbtnLogin" runat="server" 
                                ImageUrl="~/images/button.gif" onclick="imbtnLogin_Click" />
                        </dt>
				    </dl>
            </li>
            <li class="LoginBottom"></li>
        </ul>
        
    </div>
    <asp:TextBox ID="txtBackUrl" Visible="false" runat="server"></asp:TextBox>
    </form>
</body>
</html>
