<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EleganciaWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h3>La Elegancia WEB</h3>
        <p class="lead">Bienvenido a La Elegancia WEB. Sistema de control sobre inventario.</p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Facturas</h2>
            <p>
                Creación de facturas, nulación y cancelación de las mismas.
            </p>
            <p>
                <img src="Images/Facturas.PNG" class="img-circle" alt="Facturas"/>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Reportería</h2>
            <p>
                Creación e impresión de reportes.
            </p>
            <p>
                <img src="Images/Reportes.PNG" class="img-circle"/>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Boletas</h2>
            <p>
                Manejo de entradas y salidas de productos en sucursales.
            </p>
            <p>
                <img src="Images/Boletas.PNG" class="img-circle"/>
            </p>
        </div>
    </div>

</asp:Content>
