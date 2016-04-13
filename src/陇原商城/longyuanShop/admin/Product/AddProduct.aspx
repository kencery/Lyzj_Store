<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="AddProduct.aspx.cs" Inherits="admin_Product_AddProduct" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <div class="AdminNav">
        <div>
            <ul>
                <li><a href="AddProduct.aspx">添加产品</a></li>
                <li><a href="manageProduct.aspx">管理产品</a></li>
                <li><a href="manageProduct.aspx">推荐产品</a></li>
                <li><a href="manageProduct.aspx">下架产品</a></li>
                <li><a href="AddCategoryInfo.aspx">产品类别管理</a></li>
            </ul>
        </div>
    </div>
    <div>
        <table align="center" cellpadding="0" cellspacing="0" style="width: 820px; border:1px solid red">
            <tr>
                <td  style="background-color: #99CCFF; font-size:28px; font-weight: bold; font-style: italic; font-variant: normal; color: #FFFFFF;" 
                    align="center" colspan="3">
                    <asp:Label ID="lblshow" runat="server" Text="添加商品"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width:20%; height:29px" align="right">
                    产品型号：</td>
                <td style="width:50%" align="left">
                    <asp:TextBox ID="txtProNumber" runat="server" Width="150px"></asp:TextBox>
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    产品名称：</td>
                <td align="left">
                    <asp:TextBox ID="txtProductName" runat="server" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvProductName" runat="server" 
                        ControlToValidate="txtProductName" Display="Dynamic" ErrorMessage="请填写你的商品名称">*</asp:RequiredFieldValidator>
                </td>
                <td align="center" rowspan="8">
                    <asp:Image ID="imgPhoto" runat="server" ImageUrl="~/photo/noimage.gif" 
                        Height="150px" Width="150px" />
                </td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    商品类别：</td>
                <td align="left">
                    <asp:DropDownList ID="ddlLeavl" runat="server" Width="100px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    产品图片：</td>
                <td align="left">
                            <asp:FileUpload ID="fuProductPhoto" runat="server" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:LinkButton ID="lbtnUp" runat="server" CausesValidation="False" 
                        Font-Underline="false" 
    onclick="lbtnUp_Click">上传图片</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    商品原价：</td>
                <td align="left">
                    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtPrice" runat="server" 
                        ControlToValidate="txtPrice" Display="Dynamic" ErrorMessage="请填写你的商品价格">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvPrice" runat="server" ControlToValidate="txtPrice" 
                        Display="Dynamic" ErrorMessage="请填写正确的形式" Type="Currency" 
                        Operator="DataTypeCheck">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    商品现价：</td>
                <td align="left">
                    <asp:TextBox ID="txtCurrentPrince" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    会员现价：</td>
                <td align="left">
                    <asp:TextBox ID="txtMenberPrince" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvtxtMember" runat="server" 
                        ControlToValidate="txtMenberPrince" ErrorMessage="会员价不能为空!">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvMember" runat="server" 
                        ControlToValidate="txtMenberPrince" Display="Dynamic" 
                        ErrorMessage="请输入正确的会员价格!" Type="Currency" Operator="DataTypeCheck">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    供应总数：</td>
                <td align="left">
                    <asp:TextBox ID="txtPoductStore" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvProductStore" runat="server" 
                        ControlToValidate="txtPoductStore" Display="Dynamic" 
                        ErrorMessage="请填写你此产品的库存的总共数目">*</asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="cvProductStore" runat="server" 
                        ControlToValidate="txtPoductStore" Display="Dynamic" 
                        ErrorMessage="请填写正确的产品库存总数" Type="Currency" Operator="DataTypeCheck">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    单&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 位：</td>
                <td align="left" style="height: 5px">
                    <asp:DropDownList ID="ddlDanWei" runat="server">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    邮&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 费：</td>
                <td align="left">
                    <asp:DropDownList ID="ddlFreightType" runat="server">
                    <asp:ListItem Value="1" Selected="True">快递</asp:ListItem>
                        <asp:ListItem Value="2">EMS</asp:ListItem>
                    </asp:DropDownList>
                    <asp:TextBox ID="txtFreight" runat="server" Width="100px" MaxLength="10" Text="10"></asp:TextBox><span>元<asp:RequiredFieldValidator 
                        ID="rfvfregintType" runat="server" ControlToValidate="txtFreight" 
                        ErrorMessage="邮费不能为空，可以输入0">*</asp:RequiredFieldValidator>
                    </span></td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    &nbsp;Q Q客服：</td>
                <td align="left">
                    <asp:DropDownList ID="ddlQQList" runat="server">
                    </asp:DropDownList>
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    允许品论：</td>
                <td align="left" style="height: 18px" width="300">
                     <asp:RadioButton ID="rbDesc" runat="server" GroupName="isreviewenable" Text="是" 
                         Checked="True" />
                     <asp:RadioButton ID="rbDesc2" runat="server" GroupName="isreviewenable" 
                         Text="否" /></td>
                <td align="left" style="height: 18px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right" style="height:29px">
                    有&nbsp; 效&nbsp; 期：</td>
                <td align="left">
                    <asp:DropDownList ID="ddlRemainDay" runat="server" Height="21px" Width="100px">
                        <asp:ListItem Value="15">半个月</asp:ListItem>
                        <asp:ListItem Value="30">一个月</asp:ListItem>
                        <asp:ListItem Value="60">两个月</asp:ListItem>
                        <asp:ListItem Value="90">三个月</asp:ListItem>
                        <asp:ListItem Value="120">四个月</asp:ListItem>
                        <asp:ListItem Value="150">五个月</asp:ListItem>
                        <asp:ListItem Value="360">一年</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp;</td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td align="right">
                   <p>产品描述：</p> 
                      <p>·换行请按<FONT color="ff6600">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br/>
                          Shift+Enter&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </FONT><BR>
                            ·另起一段请按&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <br>
                        <FONT color="#ff6600">Enter&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </FONT></p></td>   
                </td>
                <td align="left">
                    <asp:TextBox ID="txtContent" runat="server" style="display:none;"></asp:TextBox>
                    <iframe id="eWebEditor1" src="../Edit/ewebeditor.htm?id=txtContent&style=coolblue" frameborder="0" scrolling="no" style=" width:400px; height:250px;"></iframe></td>
                <td align="left">
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td align="center" style="height:49px">
                    <asp:Button ID="btnAdd" runat="server" Text="添加商品" onclick="btnAdd_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="btnUpdate" runat="server" 
                        onclick="btnUpdate_Click" style="height: 26px" Text="修改商品" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnReste" runat="server" Text="重置" CausesValidation="False" 
                        onclick="btnReste_Click" />
                    <asp:ValidationSummary ID="vsProduct" runat="server" ShowMessageBox="True" 
                        ShowSummary="False" />
                </td>
                <td align="left">
                    &nbsp;</td>
            </tr>
        </table>
        
    </div>
</div>
</asp:Content>

