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
                    <div style="width: 200px; height: 200px; overflow: hidden; border: 1px solid #ccc; display: flex; align-items: center; justify-content: center;">
                        <asp:Image ID="imgUser"
                            ImageUrl="https://www.palomacornejo.com/wp-content/uploads/2021/08/no-image.jpg"
                            runat="server"
                            Style="max-width: 100%; max-height: 100%;" />
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <div class="row mt-4">
        <div class="col-md-4">
            <asp:Button Text="Save" CssClass="btn btn-primary" OnClick="btnSave_Click" ID="btnSave" runat="server" />
            <a Class="btn btn-primary" href="Home.aspx">Cancel</a>
        </div>
    </div>
</asp:Content>
