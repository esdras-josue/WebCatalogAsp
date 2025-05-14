<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="WebCatalogAsp.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<%--    <style>
        .imgUser {
            width: 100%;
            max-width: 250px;
            border-radius: 50%;
            object-fit: cover;
            border: 3px solid #dee2e6;
        }
    </style>--%>
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
                <label for="txtName" class="form-label">Name</label>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtLastName" class="form-label">Last Name</label>
                <asp:TextBox runat="server" ID="txtLastName" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="updatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImage" class="form-label">Image</label>
                        <input type="file" runat="server" id="txtImage" class="form-control" />
                    </div>
                    <asp:Image ID="imgUser"
                        ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                        runat="server" width="50%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div class="row">
            <div class="col-md-4">
                <asp:Button Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" ID="btnSave" runat="server" />
                <a href="Home.aspx">Cancel</a>
            </div>
        </div>
    </div>
</asp:Content>
