<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="WebCatalogAsp.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <asp:Label Text="Search" runat="server" />
                <asp:TextBox runat="server" ID="filter" CssClass="form-control" AutoPostBack="true" OnTextChanged="filter_TextChanged" />
            </div>
        </div>
    </div>

    <asp:GridView runat="server" ID="dgvProducts" CssClass="table table-striped table-bordered table-dark table-hover"
        AutoGenerateColumns="false" DataKeyNames="Id" OnSelectedIndexChanged="dgvProducts_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Code" DataField="Code" />
            <asp:BoundField HeaderText="Name" DataField="Name" />
            <asp:BoundField HeaderText="Description" DataField="Description" />
            <asp:BoundField HeaderText="Brand" DataField="Brand" />
            <asp:BoundField HeaderText="Category" DataField="Category" />
            <asp:BoundField HeaderText="Pice" DataField="Price" />
            <asp:CommandField HeaderText="Accion" ShowSelectButton="true" SelectText="✍️" />
        </Columns>
    </asp:GridView>
    <a href="ProductForm.aspx" id="btnAddProduct" class="btn btn-outline-secondary">Add Product</a>
</asp:Content>
