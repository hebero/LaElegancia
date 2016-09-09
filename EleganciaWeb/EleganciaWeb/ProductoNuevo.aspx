<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoNuevo.aspx.cs" Inherits="EleganciaWeb.ProductoNuevo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class ="container">
        <div class ="row">
             <h1>Productos</h1>
        </div>
        <div class ="row">
            <div class="col-md-4 col-lg-4 col-xs-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <h4>Productos existentes</h4>
                        </div>
                    </div>
                    <div class="panel-body">
                        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-4 col-lg-4 col-xs-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <h4>Modificacion de producto</h4>
                        </div>
                    </div>
                    <div class="panel-body">

                    </div>
                </div>
            </div>
            <div class="col-md-4 col-lg-4 col-xs-4">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <h4>Producto nuevo</h4>
                        </div>
                    </div>
                    <div class="panel-body">
                        <asp:GridView ID="GridView2" runat="server"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
