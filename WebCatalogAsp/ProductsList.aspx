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

    <div class="col-6" style="display: flex; flex-direction: column; justify-content: flex-end;">
        <div class="mb-3">
            <asp:CheckBox Text="Get Filtered Product"
                CssClass="" ID="chkFilteredProduct" runat="server"
                AutoPostBack="true"
                OnCheckedChanged="chkFilteredProduct_CheckedChanged" />
        </div>
    </div>

    <%if (chkFilteredProduct.Checked)
        { %>
    <div class="row">
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Field" ID="lblField" runat="server" />
                <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlField" CssClass="form-control" OnSelectedIndexChanged="ddlField_SelectedIndexChanged">
                    <asp:ListItem Text="Precio" />
                    <asp:ListItem Text="Nombre" />
                    <asp:ListItem Text="Descripcion" />
                </asp:DropDownList>
            </div>
        </div>

        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="SearchBy" runat="server" />
                <asp:DropDownList runat="server" ID="ddlSearchBy" CssClass="form-control"></asp:DropDownList>
            </div>
        </div>
        <div class="col-3">
            <div class="mb-3">
                <asp:Label Text="Filtro" runat="server" />
                <asp:TextBox runat="server" ID="txtGetFilteredProduct" CssClass="form-control" />
            </div>
        </div>

        <div class="row">
            <div class="col-3">
                <div class="mb-3">
                    <asp:Button Text="Search" runat="server" CssClass="btn btn-primary" ID="btnSearch" OnClick="btnSearch_Click" />
                </div>
            </div>
        </div>
        <%} %>
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
