<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="WebCatalogAsp.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Welcome to CatalogWebApp</h3>
    <style>
        .small-gap .col {
            padding: 0.5rem;
        }

        .card {
            height: 100%;
            display: flex;
            flex-direction: column;
        }

        .card-img-top {
            height: 150px;
            object-fit: contain;
            background-color: #f8f9fa;
        }

        .card-body {
            flex: 1;
            display: flex;
            flex-direction: column;
            justify-content: space-between;
            padding: 0.75rem;
            overflow: hidden;
        }

        .card-title {
            font-size: 1rem;
            font-weight: bold;
            white-space: nowrap;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .card-text {
            font-size: 0.85rem;
            color: #6c757d;
            max-height: 3rem;
            overflow: hidden;
            text-overflow: ellipsis;
        }

        .card-body a {
            margin-top: auto;
            margin-bottom: 0.5rem;
            font-size: 0.9rem;
            color: #0d6efd;
            text-decoration: underline;
        }

        .card-body .btn-primary {
            width: 100%;
        }
    </style>

    <div class="container-fluid">
        <div class="row row-cols-1 row-cols-md-4 small-gap">
            <asp:Repeater runat="server" ID="repeater">
                <ItemTemplate>
                    <div class="col">
                        <div class="card h-100">
                            <img src="<%#Eval("ImageUrl")%>" class="card-img-top" alt="Imagen no disponible">
                            <div class="card-body">
                                <h5 class="card-title"><%#Eval("Name")%></h5>
                                <p class="card-text"><%#Eval("Description")%></p>
                                <a href="ProductsList.aspx?id=<%#Eval("Id")%>">ver detalles</a>
                                <asp:Button Text="See Product" runat="server" CssClass="btn btn-primary" ID="btnProduct" CommandArgument='<%#Eval("Id") %>' CommandName="ProductId" OnClick="btnProduct_Click" />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

