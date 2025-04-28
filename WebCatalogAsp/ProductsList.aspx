<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="WebCatalogAsp.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <asp:GridView runat="server" ID="dgvProducts" CssClass="table table-striped table-bordered table-dark table-hover" 
        AutoGenerateColumns="false" dataKeyNames="id" OnSelectedIndexChanged="dgvProducts_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Code" DataField="Code" />
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Description" DataField="Description" />
            <asp:BoundField HeaderText="Brand" DataField="Brand" />
            <asp:BoundField HeaderText="Category" DataField="CategoryDescription" />
            <asp:BoundField HeaderText="Pice" DataField="Price" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="Edit✍️" />
        </Columns>
    </asp:GridView>
         <a href="ProductForm.aspx" Id="btnAddProduct" class="btn btn-outline-secondary">Add Product</a>
</asp:Content>
