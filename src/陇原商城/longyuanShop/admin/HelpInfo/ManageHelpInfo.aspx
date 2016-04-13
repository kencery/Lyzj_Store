<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="ManageHelpInfo.aspx.cs" Inherits="admin_HelpInfo_ManageHelpInfo"%>

<%@ Register src="../tool/myPagelist.ascx" tagname="myPagelist" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        function selAll(boolValue)
        {
            var obj=document.getElementsByName("cbName");
            var cbNameLen=obj.length;
            if(cbNameLen>1) 
            { 
                for(var i=0;i<cbNameLen;i++) 
                { 
                    if(obj[i].checked)
                    {
                        obj[i].checked=false;
                    }
                    else
                    {
                        obj[i].checked=true;
                    }
                }
                
            } 
            else 
            {
                obj.checked = boolValue; 
            }
        }
        
        function clickBtnCheck()
        {
            var obj=document.getElementsByName("cbName");
            var cbNameLen=obj.length;
            var Flag=false;
            if(cbNameLen>0)
            {
                for(var i=0;i<cbNameLen;i++) 
                { 
                    if(obj[i].checked)
                    {
                        Flag=true;
                        break;
                    }
                } 
                if(Flag)
                {
                    return true;
                }
                else
                {
                    alert("请先选择要操作的记录！！");
                    return false;
                }
            }
            else
            {
                alert("现在没有记录，不能操作！！");
                return false;
            }
        }
    </script>

<div class="AdminNav">
    <div>
        <ul>
            <li class="now"><a href="AddHelper.aspx" title="添加网站帮助信息">添加网站帮助</a></li>
            <li><a href="ManageHelpInfo.aspx" title="管理网站帮助信息">管理网站帮助</a></li>
       </ul>
    </div>
</div>
<div>
<div>
   <table align="center" cellpadding="0" cellspacing="0" style="width: 820px; border: 1px solid #FF00FF">
        <tr>
           <td style="background-color: #99CCFF; font-size:28px; font-weight: bold; font-style: italic; font-variant: normal; color: #FFFFFF;"  colspan="2">
                            网站帮助管理</td>
        </tr>
        <tr>
            <td>
               <asp:GridView ID="gvHelpInfo" runat="server" AutoGenerateColumns="False" 
                            Width="100%" BackColor="White" BorderColor="White" 
                    BorderStyle="Ridge" BorderWidth="2px" CellPadding="3" CellSpacing="1" 
                    GridLines="None" onrowdatabound="gvHelpInfo_RowDataBound">
                <Columns>
                    <asp:TemplateField HeaderText="&lt;input type='checkbox' id='cbAll' name='cbAll' onclick='selAll(this.checked);' /&gt;反选">
                          <ItemTemplate>
                               <input type="checkbox" id="cbName" name="cbName" value='<%# DataBinder.Eval(Container.DataItem, "HelpID")%>' />
                          </ItemTemplate>
                     </asp:TemplateField>
                    <asp:BoundField DataField="helpTitle" HeaderText="帮助标题" />
                    <asp:BoundField DataField="className" HeaderText="帮助类别" />
                    <asp:TemplateField HeaderText="状态">
                        <ItemTemplate>
                             <asp:Label ID="lbState" runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="postTime" DataFormatString="{0:d}" 
                        HeaderText="发布时间" />
                    <asp:HyperLinkField DataNavigateUrlFields="helpID" 
                        DataNavigateUrlFormatString="AddHelper.aspx?helpID={0}" HeaderText="操作" 
                        Text="修改" />
                </Columns>
                <Emptydatarowstyle backcolor="#CADBED" forecolor="Red"/>
                   <SelectedRowStyle BackColor="#9471DE" Font-Bold="True" ForeColor="White" />
                <HeaderStyle HorizontalAlign="Center" BackColor="#4A3C8C" 
                       Font-Bold="True" ForeColor="#E7E7FF" />
                <RowStyle Height="30px" HorizontalAlign="Center" BackColor="#DEDFDE" 
                       ForeColor="Black" />
                   <FooterStyle BackColor="#C6C3C6" ForeColor="Black" />
                   <PagerStyle BackColor="#C6C3C6" ForeColor="Black" HorizontalAlign="Right" />
                <EmptyDataTemplate>
                <div>还没有网站帮助呢？请您检查！</div>
                </EmptyDataTemplate>
                <RowStyle Height="30px" />
              </asp:GridView>
          </td>
        </tr>
      <tr>
        <td>
             <uc1:myPagelist ID="pList8517" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnDeleteHelp" runat="server" Text="删除帮助" OnClientClick="return confirm('您确定要删除此帮助吗？')"
                            onclick="btnDeleteHelp_Click" />
&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnShowHelp" runat="server" Text="显示帮助" 
                            onclick="btnShowHelp_Click" />
&nbsp;&nbsp;
                        <asp:Button ID="btnCoverHelp" runat="server" Text="隐藏帮助" 
                            onclick="btnCoverHelp_Click" />
                    </td>
                </tr>
            </table>
</div>
</asp:Content>

