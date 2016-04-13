<%@ Page Language="C#" AutoEventWireup="true" CodeFile="addCategory.aspx.cs" Inherits="admin_addCategory" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jquery-1.4.2.js" type="text/javascript"></script>
      <script type="text/javascript">
      function calculateOffsetTop(field) {
          return calculateOffset(field, "offsetTop");
      }

      function calculateOffset(field, attr) {
          var offset = 0;
          while (field) {
              offset += field[attr];
              field = field.offsetParent;
          }
          return offset;
      }
      function showEditDiv(edit) {
          var row = edit.parentElement.parentElement;
          document.getElementById("lbdivid").value = row.cells(1).id;
          var arr = row.cells(0).id.split(",");
          document.getElementById("tbname").value = arr[0];

          var ddl = document.getElementById("ddldiv");
          for (i = 0; i < ddl.options.length; i++) {
              var arrddl = ddl.options[i].value.split(",");
              if (arrddl[1] == arr[1]) {
                  ddl.selectedIndex = i;
                  document.getElementById("olddepth").value = arrddl[0];
              }
          }

          var end = row.offsetWidth;
          var top = calculateOffsetTop(row);
          var v = document.getElementById("editDiv");
          v.style.border = "black 1px solid";
          v.style.left = end + 40 + "px";
          v.style.top = top + "px";
          v.style.display = "";
      }
      function close() {
          var div = document.getElementById("editDiv");
          div.style.display = "none";
      }
     </script>
</head>
<body  id="lbid">
    <form id="form1" runat="server">
    <div id="Div1" style="margin-left:20px; margin-top:20px;" runat="server">
        <div style="height: 127px; width:360px;">
            <table align="left" cellpadding="0" cellspacing="0" 
                style="width:340px; border: 1px solid #99FFCC">
                <tr>
                    <td align="right" style="width:35%; height:40px;">
                        分类名称：</td>
                    <td align="left" >
                        <asp:TextBox ID="txtCategoryName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfvCategoryName" runat="server" 
                            ControlToValidate="txtCategoryName" ErrorMessage="*必填项">*必填项</asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="height:40px;" >
                        所属分类：</td>
                    <td align="left">
                        <asp:DropDownList ID="ddlLevel" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" >
                        <asp:Button ID="btnAddCategory" runat="server" Text="添加分类" 
                            onclick="btnAddCategory_Click" />
                    </td>
                </tr>
            </table>
        </div> 
                <div style="width: 214px; float:left">
                <table>
                    <asp:Repeater ID="Repeater1" runat="server">
                        <HeaderTemplate>
                            <tr style="background-color:Gray">
                                <td>
                                    类别名称</td>
                                <td>
                                    管理</td>
                            </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td id="<%# Eval("productCategoryName") %>,<%# Eval("ParentId") %>">
<%# CreateItemText(Convert.ToString(Eval("productCategoryName")), Convert.ToInt32(Eval("CategoryDepth")))%></a>
                                </td>
                                <td id="<%# Eval("productCategoryId")%>">
                                    <span onclick="showEditDiv(this)" style="cursor: pointer;">编辑</span>&nbsp;&nbsp;
                                    <a href="AddCategory.aspx?id=<%# Eval("productCategoryId")%>" onclick="return confirm('您确认删除该管理员吗？')"> 删除</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
            <div id="editDiv" style="position: absolute; width: 214px; height: 152px; padding: 5px;
                display: none;">
                <asp:Label ID="Label5" runat="server" Text="ID" Width="40px"></asp:Label>&nbsp;
                <input id="lbdivid" runat="server" style="width: 111px" type="text" readonly="readonly" />&nbsp;&nbsp;
                <a href="javaScript:close()" style="cursor: pointer"><font color="fuchsia">关闭</font></a><br />
                <br />
                <asp:Label ID="Label1" runat="server" Text="名称" Width="40px"></asp:Label>&nbsp;
                <input id="tbname" runat="server" type="text" style="width: 113px" />
                <br />
                <br />
                <asp:Label ID="Label4" runat="server" Text="所属分类"></asp:Label>
                <asp:DropDownList ID="ddldiv" runat="server">
                </asp:DropDownList><br />
                <br />
                <asp:Button ID="btnedit" runat="server" Text="修改" Width="68px" 
                    onclick="btnedit_Click" CausesValidation="False"/>
                <input id="olddepth" runat="server" style="width: 24px" type="hidden" /></div>         
        </div>
  
    </form>
</body>
</html>
