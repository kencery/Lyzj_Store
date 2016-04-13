<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/MasterPage.master" AutoEventWireup="true" CodeFile="HelpInfo.aspx.cs" Inherits="proscenium_HelpInfo_HelpInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/Logo.css" rel="stylesheet" type="text/css" />
    <link href="../../css/foot.css" rel="stylesheet" type="text/css" />
    <link href="../../css/help.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div><img src="../images/logo.png" style="width: 996px; height: 100px" /></div>
<div class="help">
    <ul>
        <li><a href="../Index.aspx">网站首页</a>&nbsp;＞</li>
        <li><a href="HelpList.aspx">帮助首页</a>&nbsp;＞</li>
        <li>帮助中心</li>
    </ul>
</div>
<div class="helpconter">
    <div class="helpleft">
        <div class="helpleftone"><img src="../images/help_04.gif" width="247px" height="8px" alt="陇原商城" /></div>
        <div class="helplefttwo"><img style="margin:auto auto auto 5px;" src="../images/help_07.gif" alt="客户服务" width="236px" height="92px" />
            <div class="helpsousuo">
                <div><input type="text" id="txtHelpKeyWord" 
                        style="width:140px; height:13px; margin-top:5px; margin-left:5px; line-height:16px;" 
                        name="" /></div>
                <div><img src="../images/help_16.gif" style="width:62px; vertical-align:middle; border:none; display:block; cursor:pointer;" alt="搜索" onclick="HelpSearch();"/></div>
            </div>
            <div class="fclear"></div>
        <div id="HelpClass">
         <asp:GridView ID="ddlBindex" runat="server" AutoGenerateColumns="False" 
                BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
                CellPadding="2" ForeColor="Black" GridLines="None" Width="221px" 
                Height="116px">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="V" 
                        DataNavigateUrlFormatString="HelpList.aspx?ClassID={0}" DataTextField="n" 
                        HeaderText="陇原网站帮助">
                    <ControlStyle Font-Underline="False" />
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                    </asp:HyperLinkField>
                </Columns>
                <FooterStyle BackColor="Tan" />
                <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                    HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                <HeaderStyle BackColor="Tan" Font-Bold="True" />
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
            </asp:GridView>
             </div>
        </div>
        <div class="helpleftthere"><img src="../images/help_33.gif" width="247px" height="10px" alt="陇原商城"/></div>
    </div>
    <div class="helpright">
        <div class="helprightone"><img src="../images/help_05.gif" alt="陇原商城" width="751px" height="12px"/></div>
        <div class="helprighttwo">
            <div class="helpline">
                <ul>
                    <li><%=hInfo.HelpTitle%></li>
                </ul>
            <div class="helprightwz">
                <ul>
                    <li>
                        <%=hInfo.HelpCntent%>
                    </li>
                </ul>
            </div>
        </div>
        <div class="helprightthere"><img src="../images/help_31.gif" width="751" height="9" /></div>
    </div>
</asp:Content>

