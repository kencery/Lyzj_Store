<%@ Page Title="网站公告信息" Language="C#" MasterPageFile="~/proscenium/MasterPage.master" AutoEventWireup="true" CodeFile="BulletinInfoContent.aspx.cs" Inherits="proscenium_BulletinInfo_BulletinInfoContent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../css/Logo.css" rel="stylesheet" type="text/css" />
    <link href="../../css/foot.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  
  <div style="margin-left:10px;" >
        <%=bInfo.BulletinContent %>
  </div>
</asp:Content>

