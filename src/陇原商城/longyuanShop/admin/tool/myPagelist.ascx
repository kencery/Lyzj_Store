<%@ Control Language="C#" AutoEventWireup="true" CodeFile="myPagelist.ascx.cs" Inherits="admin_tool_myPagelist" %>
第<asp:Label ID="CurPageLabel" runat="server"></asp:Label>页 &nbsp;共<asp:Label ID="PageCountLabel" runat="server"></asp:Label>页&nbsp;
<asp:HyperLink ID="IndexPage" runat="server" ><<</asp:HyperLink>
<asp:HyperLink ID="PrevPage" runat="server" ><</asp:HyperLink>
<asp:Literal ID="NumberPage" runat="server"></asp:Literal>
<asp:HyperLink ID="NextPage" runat="server">></asp:HyperLink>
<asp:HyperLink ID="LastPage" runat="server">>></asp:HyperLink>