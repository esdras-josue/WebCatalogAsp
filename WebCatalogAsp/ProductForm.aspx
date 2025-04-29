<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="ProductForm.aspx.cs" Inherits="WebCatalogAsp.ProductForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1" />

    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtCode" class="form-label">Code</label>
                <asp:TextBox runat="server" ID="txtCode" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="txtName" class="form-label">Name</label>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
            </div>

            <div class="mb-3">
                <label for="ddlBrand" class="form-label">Brand</label>
                <asp:DropDownList runat="server" ID="ddlBrand" CssClass="form-select" />
            </div>

            <div class="mb-3">
                <label for="ddlCategory" runat="server">Category</label>
                <asp:DropDownList runat="server" ID="ddlCategory" CssClass="form-select" />
            </div>

            <div class="mb-3">
                <asp:Button runat="server" CssClass="btn btn-outline-primary" Text="Add" ID="btnAdd" OnClick="btnAdd_Click" />
                <asp:Button runat="server" CssClass="btn btn-outline-primary" Text="Modify" ID="btnModify" OnClick="btnModify_Click" />
                <a href="Home.aspx" class="btn btn-outline-primary">Cancel</a>
            </div>
        </div>

        <div class="col-6">
            <div class="mb-3">
                <label for="txtDescription" class="form-label">Description</label>
                <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtPrice" class="form-label">Price</label>
                <asp:TextBox runat="server" ID="txtPrice" CssClass="form-control" />
            </div>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImage" class="form-label">Url Image</label>
                        <asp:TextBox runat="server" ID="txtUrlImage" CssClass="form-control"
                            AutoPostBack="true" OnTextChanged="txtUrlImage_TextChanged" />
                    </div>
                    <asp:Image
                        ImageUrl="https://th.bing.com/th/id/OIP.v3_2lDKLaxi3QIOKETrd0wHaEK?w=267&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                        runat="server" ID="imgProduct" Width="50%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row">
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <asp:Button Text="Delete" ID="btnDelete" CssClass="btn btn-outline-danger" runat="server" OnClick="btnDelete_Click" />
                    </div>
                    <%if (ConfirmElimination)

                        { %>
                    <div class="mb-3">
                        <asp:CheckBox Text="Confirm Deleted" ID="chkConfirmDelete" runat="server" />
                        <asp:Button Text="Delete" ID="btnConfirmElimination" CssClass="btn btn-outline-danger" runat="server" OnClick="btnConfirmElimination_Click"/>
                    </div>
                    <%  } %>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
