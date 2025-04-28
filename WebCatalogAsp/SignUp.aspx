<%@ Page Title="" Language="C#" MasterPageFile="~/Register.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="WebCatalogAsp.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contenedor centrado vertical y horizontalmente -->
    <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
        <div class="border p-4 rounded shadow-sm" style="width: 350px;">
            <h4 class="text-center mb-4">Create Account</h4>

            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control form-control-sm" placeholder="Enter email" />
            </div>

            <div class="mb-3">
                <label for="txtName" class="form-label">Name</label>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control form-control-sm" placeholder="Enter name" />
            </div>

            <div class="mb-3">
                <label for="txtPassword" class="form-label">Password</label>
                <asp:TextBox runat="server" ID="txtPassword" CssClass="form-control form-control-sm" TextMode="Password" placeholder="Enter password" />
            </div>

            <asp:Button runat="server" ID="btnSignIn" Text="Sign In" CssClass="btn btn-primary w-100 btn-sm" />
            <p>Already have an account?</p><a href="Login.aspx" class="btn btn-outline-primary"> Login here</a>
            <a href="Home.aspx" class="btn btn-outline-primary"> Cancel</a>
        </div>
    </div>
</asp:Content>
