<%@ Page Title="" Language="C#" MasterPageFile="~/Register.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebCatalogAsp.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
        <div class="border p-4 rounded shadow-sm" style="width: 350px;">
            <div class="mb3">
                <h4 class="text-center mb-4">Login</h4>
                <label class="form-label">Email</label>
                <asp:TextBox runat="server" CssClass="form-control" ID="txtEmail" />
            </div>
            <div class="mb-3">
                <label class="form-label">Password</label>
                <asp:TextBox runat="server" CssClass="form-control" Type="password" ID="txtPassord" />
            </div>
            <div class="mb-3 text-center">
                <asp:Button runat="server" Text="Login" CssClass="btn btn-primary me-2" ID="btnLogin" OnClick="btnLogin_Click" />
                <a class="btn btn-outline-primary" CssClass="btn btn-primary me-2" href="Home.aspx">Cancel</a>
            </div>
            <div class="mb-3">
                <p>¿Don't have an account?</p><a href="SignUp.aspx" class="btn btn-outline-primary">SignUp</a>
            </div>
        </div>
    </div>
</asp:Content>
