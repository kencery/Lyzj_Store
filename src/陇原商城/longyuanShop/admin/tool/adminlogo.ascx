<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adminlogo.ascx.cs" Inherits="admin_tool_adminlogo" %>
<script type="text/javascript" language="javascript">
    //初始化
    var def = "1";
    function mover(object) {
        //主菜单
        var mm = document.getElementById("m_" + object);
        mm.className = "m_li_a";
        //初始主菜单先隐藏效果
        if (def != 0) {
            var mdef = document.getElementById("m_" + def);
            mdef.className = "m_li";
        }
        //子菜单
        var ss = document.getElementById("s_" + object);
        ss.style.display = "block";
        //初始子菜单先隐藏效果
        if (def != 0) {
            var sdef = document.getElementById("s_" + def);
            sdef.style.display = "none";
        }
    }

    function mout(object) {
        //主菜单
        var mm = document.getElementById("m_" + object);
        mm.className = "m_li";
        //初始主菜单还原效果
        if (def != 0) {
            var mdef = document.getElementById("m_" + def);
            mdef.className = "m_li_a";
        }
        //子菜单
        var ss = document.getElementById("s_" + object);
        ss.style.display = "none";
        //初始子菜单还原效果
        if (def != 0) {
            var sdef = document.getElementById("s_" + def);
            sdef.style.display = "block";
        }
    }
    function show() {
        var t;
        //获得系统当前时间   
        t = new Date();
        var s;
        //获得时   
        s = t.getHours() + ":";
        //获得分   
        s += t.getMinutes() < 10 ? "0" + t.getMinutes() : t.getMinutes();
        s += ":";
        s += t.getSeconds() < 10 ? "0" + t.getSeconds() : t.getSeconds();
        document.getElementById('<%= lblTime.ClientID %>').innerText = s;
        setTimeout("show()", 500)
    }   
</script>

<link href="../css/adminmain.css" rel="stylesheet" type="text/css" />
<div id="menu">
    <ul>
        <li class="m_line"><img src="../../images/line.gif" alt="" /></li>
        <li id="m_1" class="m_li_a"><a href="../../proscenium/Index.aspx" target="_blank">陇原商城首页</a></li>
        <li class="m_line"><img src="../../images/line.gif" alt=""  /></li>
        <li id="m_2" class='m_li' onmouseover='mover(2);' onmouseout='mout(2);'><a href="">管理员信息</a></li>
        <li class="m_line"><img src="../../images/line.gif" alt=""  /></li>
        <li id="m_3" class='m_li' onmouseover='mover(3);' onmouseout='mout(3);'><a href="">用户管理</a></li>
        <li class="m_line"><img src="../../images/line.gif" alt=""  /></li>
        <li id="m_4" class='m_li' onmouseover='mover(4);' onmouseout='mout(4);'><a href="">产品管理</a></li>
        <li class="m_line"><img src="../../images/line.gif" alt=""  /></li>
        <li id="m_5" class='m_li' onmouseover='mover(5);' onmouseout='mout(5);'><a href="">订单管理</a></li>
        <li class="m_line"><img src="../../images/line.gif" alt=""  /></li>
        <li id="m_6" class='m_li' onmouseover='mover(6);' onmouseout='mout(6);'><a href="">公告管理</a></li>
        <li class="m_line"><img src="../../images/line.gif" alt=""  /></li>
        <li id="m_7" class='m_li' onmouseover='mover(7);' onmouseout='mout(7);'><a href="">帮助管理</a></li>
        <li class="m_line"><img src="../../images/line.gif" alt=""  /></li>
    </ul>
</div>
<div style="height:32px; width:1000px; background-color:#F1F1F1" onload="show()"> 
    <ul class="smenu">
        <li style="padding-left:-100px; float:left;" id="s_1" class='s_li_a'>欢迎登录陇原网上商城后台，系统当前的时间是：<asp:Label ID="lblTime" runat="server" ForeColor="Red"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:LinkButton 
                ID="linkreset" runat="server" 
                OnClientClick="return confirm('您确定要返回登录页吗？')" Font-Underline="False" 
                ForeColor="Blue">返回</asp:LinkButton>
        </li>
        <li style="padding-left:110px;  float:left;" id="s_2" class="s_li" onmouseover='mover(2)' onmouseout='mout(2)'>
            <a href="../AdminInfo/ManageAdmin.aspx" >查看管理员信息</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../AdminInfo/AddAdminInfo.aspx">添加管理员</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../AdminInfo/ManageAdmin.aspx">更新管理员</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../AdminInfo/ManageAdmin.aspx" >删除管理员</a>&nbsp;&nbsp;|&nbsp;&nbsp;
       </li>
       <li style="padding-left:220px;  float:left;" id="s_3" class="s_li" onmouseover='mover(3)' onmouseout='mout(3)'>
            <a href="#">查看用户信息</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="#">删除用户</a>&nbsp;&nbsp;|&nbsp;&nbsp;
       </li>
       <li style="padding-left:120px;  float:left;" id="s_4" class="s_li" onmouseover='mover(4)' onmouseout="mout(4)">
            <a href="../Product/manageProduct.aspx">查看产品信息</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../Product/AddCategoryInfo.aspx">添加产品类别</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../Product/AddProduct.aspx">添加产品</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../Product/manageProduct.aspx">更新产品</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../Product/manageProduct.aspx">删除产品</a>&nbsp;&nbsp;|&nbsp;&nbsp;
       </li>
       <li style="padding-left:170px;  float:left;" id="s_5" class="s_li" onmouseover='mover(5)' onmouseout='mout(5)'>
            <a href="../orderlist/OrderList.aspx">未付款订单</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../orderlist/orderConsignMent.aspx">未发货订单</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../orderlist/OrderList.aspx">取消订单</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../orderlist/orderSuccendfahuo.aspx">已发货订单</a>&nbsp;&nbsp;|&nbsp;&nbsp;
       </li>
       <li style="padding-left:330px;  float:left;" id="s_6" class="s_li" onmouseover='mover(6)' onmouseout='mout(6)'> 
            <a href="../BulletinInfo/ManageBulletin.aspx">查看公告</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../BulletinInfo/AddBulletin.aspx">添加公告</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../BulletinInfo/ManageBulletin.aspx">更新公告</a>&nbsp;&nbsp;|&nbsp;&nbsp;
            <a href="../BulletinInfo/ManageBulletin.aspx">删除公告</a>&nbsp;&nbsp;|&nbsp;&nbsp;
       </li>
       <li style="padding-left:340px;  float:left;" id="s_7" class="s_li" onmouseover='mover(7)' onmouseout='mout(7)'>
             <a href="../HelpInfo/ManageHelpInfo.aspx">查看帮助</a>&nbsp;&nbsp;|&nbsp;&nbsp;
             <a href="#">帮助类别</a>&nbsp;&nbsp;|&nbsp;&nbsp;
             <a href="../HelpInfo/AddHelper.aspx" >添加帮助</a>&nbsp;&nbsp;|&nbsp;&nbsp;
             <a href="../HelpInfo/ManageHelpInfo.aspx">更新帮助</a>&nbsp;&nbsp;|&nbsp;&nbsp;
             <a href="../HelpInfo/ManageHelpInfo.aspx">删除帮助</a>&nbsp;&nbsp;|&nbsp;&nbsp;
       </li>
   </ul>
</div>

