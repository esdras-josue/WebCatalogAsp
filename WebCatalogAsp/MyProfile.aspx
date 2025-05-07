<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="WebCatalogAsp.MyProfile" %>

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
                <label for="txtName" class="form-label">Name</label>
                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtLastName" class="form-label">Last Name</label>
                <asp:TextBox runat="server" ID="txtDescription" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtEmail" class="form-label">Email</label>
                <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" />
            </div>
        </div>
        <div class="col-6">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <div class="mb-3">
                        <label for="txtImage" class="form-label">Url Image</label>
                        <asp:TextBox runat="server" ID="txtUrlImage" CssClass="form-control"
                            AutoPostBack="true" />
                    </div>
                    <asp:Image
                        ImageUrl="https://th.bing.com/th/id/OIP.v3_2lDKLaxi3QIOKETrd0wHaEK?w=267&h=180&c=7&r=0&o=5&dpr=1.3&pid=1.7"
                        runat="server" ID="imgProduct" Width="50%" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
