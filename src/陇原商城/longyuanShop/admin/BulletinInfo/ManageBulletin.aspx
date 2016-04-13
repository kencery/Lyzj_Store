<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="ManageBulletin.aspx.cs" Inherits="admin_BulletinInfo_ManageBulletin" %>

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
            <li class="now"><a href="AddBulletin.aspx" title="添加网站公告信息">添加网站公告</a></li>
            <li><a href="ManageBulletin.aspx" title="管理网站公告信息">网站公告信息</a></li>
       </ul>
    </div>
</div>
<div>
    <table align="center" cellpadding="0" cellspacing="0" style="width: 800px; border: 1px solid #FF00FF">
        <tr>
            <td style="background-color: #99CCFF; font-size:28px; font-weight: bold; font-style: italic; font-variant: normal; color: #FFFFFF;">
                网站公告信息管理</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvBulletin" runat="server" AutoGenerateColumns="False"  
                    Width="100%" onrowdatabound="gvBulletin_RowDataBound" CellPadding="4" 
                    ForeColor="#333333" GridLines="None">
                <Columns>
                       <asp:TemplateField HeaderText="&lt;input type='checkbox' id='cbAll' name='cbAll' onclick='selAll(this.checked);' /&gt;反选">           
                        <ItemTemplate>
                              <input type="checkbox" id="cbName" name="cbName" value='<%# DataBinder.Eval(Container.DataItem, "ID")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                       <asp:BoundField DataField="bulletinTitle" HeaderText="公告主题" />
                       <asp:TemplateField HeaderText="状态">
                            <ItemTemplate>
                                <asp:Label ID="lbState" runat="server"></asp:Label>
                            </ItemTemplate>
                       </asp:TemplateField>
                       <asp:BoundField DataField="postTime" DataFormatString="{0:D}" 
                           HeaderText="发布时间" />
                       <asp:HyperLinkField DataNavigateUrlFields="ID" 
                           DataNavigateUrlFormatString="AddBulletin.aspx?ID={0}" HeaderText="操作" 
                           Text="修改" />
                </Columns>
                <Emptydatarowstyle backcolor="#CADBED" forecolor="Red"/>
                    <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle HorizontalAlign="Center" CssClass="HeaderStyle" BackColor="#1C5E55" 
                        Font-Bold="True" ForeColor="White" />
                <RowStyle Height="30px" HorizontalAlign="Center" BackColor="#E3EAEB" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <EmptyDataTemplate>
                <div>您还没有添加网站公告呢？</div>
                </EmptyDataTemplate>
                <RowStyle Height="30px" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <AlternatingRowStyle BackColor="White" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td style="height:35px">
                <uc1:myPagelist ID="pList8517" runat="server" />
            </td>
        </tr>
        <tr>
            <td style="height:35px">
                <asp:Button ID="btnDel" runat="server" Text="删除公告" OnClientClick="return confirm('您确定要删除网站公告吗')" Height="28px" 
                    onclick="btnDel_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnIsPost" runat="server" Text="显示公告" Height="28px" 
                    onclick="btnIsPost_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNotIsPost" runat="server" Text="隐藏公告" Height="28px" 
                    onclick="btnNotIsPost_Click" />
            </td>
        </tr>
    </table>
    
</div>
</asp:Content>

