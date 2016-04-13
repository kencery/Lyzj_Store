<%@ Page Title="" Language="C#" MasterPageFile="~/proscenium/MasterPage.master" AutoEventWireup="true" CodeFile="HelpList.aspx.cs" Inherits="proscenium_HelpInfo_HelpList" %>

<%@ Register src="../../admin/tool/myPagelist.ascx" tagname="myPagelist" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/foot.css" rel="stylesheet" type="text/css" />
    <link href="../../css/Logo.css" rel="stylesheet" type="text/css" />
    <link href="../../css/help.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #HelpClass
        {
            width: 216px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div><img src="../images/logo.png" alt="陇原商城" style="width: 997px; height: 111px" /></div>
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
        <div class="helprightone"><img src="../images/help_05.gif" width="751px" height="12" alt="陇原商城" /></div>
        <div class="helprighttwo">
            <div class="helptab">
                <ul>
                    <li><strong>买家帮助</strong></li>
                </ul>
            </div>
            <div class="helprighttab">
                <div class="helprighttabwz">
                    <ul>
                        <li>帮助主题</li>
                    </ul>
                </div>
                <div class="helprighttabwaz2">
                    <ul>
                        <li>最后更新时间</li>
                    </ul>
                </div>
            </div>
            <div style="margin-left:30px; line-height:33px;">
            <table style="border-style: none; border-color: inherit; border-width: 0px; margin: 5px auto auto auto;width:79%; ">
                <asp:DataList ID="ddlBindIndexHelpInfo" runat="server">
                    <ItemTemplate>
                        <tr style="background:#F1F1F1;" >
                            <td style="width:85%;"><a href="HelpInfo.aspx?helpID=<%# Eval("HelpID")%>"><%# Container.ItemIndex+1%>、<%# Eval("HelpTitle")%></a></td>
                            <td style="width:15%;"><%# Eval("PostTime","{0:D}")%></td>
                        </tr>
                    </ItemTemplate>
                </asp:DataList>
            </table></div>
            <div class="pageRow">
                <uc1:myPagelist ID="new8517PageList" runat="server" />
            </div>
            <div class="tishixinxi">
                <asp:Label ID="lbInfo" Visible="false" ForeColor="Red" Font-Size="20px" runat="server"></asp:Label>
            </div>
        </div>
        <div class="helprightthere"><img src="../images/help_31.gif" width="751px" height="9px" alt="陇原商城" /></div>
    </div>
</div>
</asp:Content>

