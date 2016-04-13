<%@ Page Title="" Language="C#" MasterPageFile="~/admin/adminPageMaster.master" AutoEventWireup="true" CodeFile="AddCategoryInfo.aspx.cs" Inherits="admin_Product_AddCategoryInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <div class="AdminNav">
        <div>
            <ul>
                <li><a href="AddProduct.aspx">添加产品</a></li>
                <li><a href="manageProduct.aspx">管理产品</a></li>
                <li><a href="manageProduct.aspx">推荐产品</a></li>
                <li><a href="manageProduct.aspx">下架产品</a></li>
                <li><a href="AddCategoryInfo.aspx">产品类别</a></li>
            </ul>
        </div>
    </div>
    <table align="center" cellpadding="0" cellspacing="0" 
        style="width: 820px;">
        <tr>
              <td colspan="3" align="center" 
                style="background-color: #C0C0C0; font-size: 22px; font-weight: bold;">
                管理商品分类信息</td>
        </tr>
        <tr>
            <td>
                <iframe   id="category" name="category" src="AddCategory.aspx" width="420px" height="700px" frameborder="0" scrolling="no">  
                </iframe>
            </td>
        </tr>
    </table>

</div>
</asp:Content>

