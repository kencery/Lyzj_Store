<%@ Control Language="C#" AutoEventWireup="true" CodeFile="adminlogoleft.ascx.cs" Inherits="admin_tool_adminlogoleft" %>
    <script type="text/javascript" src="../js/jquery-1.4.2.js"></script>
    <script type="text/javascript" src="../js/adminlogoleft.js"></script>
    <link href="../css/adminmainleft.css" rel="stylesheet" type="text/css" />
<div>
    <ul>
            <li class="hmain"><asp:LinkButton ID="linkReaset" runat="server" 
                    onclick="linkReaset_Click">退出系统</asp:LinkButton></li>
        <li class="hmain"><a href="../../proscenium/Index.aspx" target="_blank">陇原网上商城首页</a></li>
        <li class="hmain"><a href="#">管理员信息</a>
            <ul>
                <li><a href="../AdminInfo/ManageAdmin.aspx">查看管理员信息</a></li>
                <li><a href="../AdminInfo/AddAdminInfo.aspx">添加管理员</a></li>
                <li><a href="../AdminInfo/ManageAdmin.aspx">更新管理员</a></li>
                <li><a href="../AdminInfo/ManageAdmin.aspx">删除管理员</a></li>
            </ul>
        </li>
        <li class="hmain"><a href="#">用户管理</a>
            <ul>
                <li><a href="#">查看用户信息</a></li>
                <li><a href="#">删除用户</a></li>
            </ul>
        </li>
        <li class="hmain"><a href="#">产品管理</a>
            <ul>
                <li><a href="../Product/manageProduct.aspx">查看产品信息</a></li>
                <li><a href="../Product/AddCategoryInfo.aspx">添加产品类别</a></li>
                <li><a href="../Product/AddProduct.aspx">添加产品</a></li>
                <li><a href="../Product/manageProduct.aspx">更新产品</a></li>
                <li><a href="../Product/manageProduct.aspx">删除产品</a></li>
            </ul>
        </li>
        <li class="hmain"><a href="#">订单管理</a> 
            <ul>
                <li><a href="../orderlist/OrderList.aspx">未付款订单</a></li>
                <li><a href="../orderlist/orderConsignMent.aspx">未发货订单</a></li>
                <li><a href="../orderlist/OrderList.aspx">取消订单</a></li>
                <li><a href="../orderlist/orderSuccendfahuo.aspx">已发货订单</a></li>
            </ul>
        </li>
        <li class="hmain"><a href="#">公告管理</a>
            <ul>
                <li><a href="../BulletinInfo/ManageBulletin.aspx">查看公告</a></li>
                <li><a href="../BulletinInfo/AddBulletin.aspx">添加公告</a></li>
                <li><a href="../BulletinInfo/ManageBulletin.aspx">更新公告</a></li>
                <li><a href="../BulletinInfo/ManageBulletin.aspx">删除公告</a></li>
            </ul>
        </li>
        <li class="hmain"><a href="#">帮助管理</a>
            <ul>
                <li><a href="../HelpInfo/ManageHelpInfo.aspx">查看帮助</a></li>
                <li><a href="../HelpInfo/AddHelper.aspx">添加帮助</a></li>
                <li><a href="../HelpInfo/ManageHelpInfo.aspx">更新帮助</a></li>
                <li><a href="../HelpInfo/ManageHelpInfo.aspx">删除帮助</a></li>
            </ul>
        </li>
        <li class="hmain"><a href="../AdminInfo/AdminLogin.aspx">返回登录页</a>
    </ul>
</div>