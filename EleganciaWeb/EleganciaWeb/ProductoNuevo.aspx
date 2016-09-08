<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoNuevo.aspx.cs" Inherits="EleganciaWeb.ProductoNuevo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="container">
        <div class ="row">
            <div class ="col-md-2 col-lg-2 col-xs-2"></div>
            <div class ="col-md-6 col-lg-6 col-xs-6">
                <div class="jumbotron">
                    <h3>Nuevos productos</h3>
                </div>
            </div>
            <div class ="col-md-2 col-lg-2 col-xs-2"></div>
        </div>
        <div class ="row">
            <div class="col-md-2 col-lg-2 col-xs-2"></div>
            <div class="col-md-6 col-lg-6 col-xs-6">
                <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </div>
            <div class="col-md-2 col-lg-2 col-xs-2"></div>
        </div>
    </div>
</asp:Content>
