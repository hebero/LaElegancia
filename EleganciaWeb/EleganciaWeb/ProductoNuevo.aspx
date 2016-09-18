<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoNuevo.aspx.cs" Inherits="EleganciaWeb.ProductoNuevo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h1>Productos</h1>
        </div>
        <div class="row">
            <div class="col-md-6 col-lg-6 col-xs-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <h4>Productos existentes</h4>
                        </div>
                    </div>
                    <div class="panel-body">
                        <asp:SqlDataSource ID="SqlDataSource" runat="server"></asp:SqlDataSource>
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-condensed" BorderStyle="None" GridLines="None"></asp:GridView>
                    </div>
                </div>
            </div>
            <div class="col-md-6 col-lg-6 col-xs-6">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <h4>Modificacion de producto</h4>
                        </div>
                    </div>
                    <div class="panel-body">
                        <label>Modo edición
                            <asp:CheckBox ID="chkEditar" runat="server" OnCheckedChanged="chkEditar_CheckedChanged" Visible="True" /></label>
                        <br />
                        <asp:Label ID="lblIdProducto" runat="server" Text="IdProducto: " Visible="True"></asp:Label>
                        <asp:TextBox ID="txtIdProducto" runat="server" Visible="True" CssClass="form-control"></asp:TextBox>
                        <br />
                        <label>SKU:
                            <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control"></asp:TextBox></label>
                        <label>Nombre:
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox></label>
                        <asp:Button ID="btnGuardar" runat="server" CssClass="btn btn-primary" Text="Guardar" OnClick="btnGuardar_Click" />
                        <asp:Label ID="lblAlerta" runat="server" Visible="false" Text=""></asp:Label>
                        <asp:Button ID="Button1" runat="server" Text="Button" CssClass="btn btn-primary" ClientIDMode="Static"/>
                    </div>
                </div>
            </div>
            &nbsp;&nbsp;&nbsp;
        </div>
    </div>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#Button1").click(function () {
                alert("Alerta");
            });
        });
    </script>
</asp:Content>
