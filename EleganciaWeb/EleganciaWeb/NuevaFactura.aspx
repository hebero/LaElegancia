<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaFactura.aspx.cs" Inherits="EleganciaWeb.NuevaFactura" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 col-lg-12 col-xs-12">
                <h2>Nueva factura</h2>
            </div>
        </div>
        <div class="row">
            <asp:Label ID="lblAlerta" runat="server" Text="" Visible="false">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
            </asp:Label>
        </div>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="panel panel-default">
                    <ul class="list-group">
                        <li class="list-group-item">
                            <h4>Cliente</h4>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-md-2 control-label" for="txtNit">Nit: </label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtNit" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label" for="txtNombreCliente">Nombre: </label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtNombreCliente" runat="server" CssClass="form-control" ClientIDMode="Static"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-10">
                                        <asp:Button ID="btnCliente" runat="server" Text="Agregar" CssClass="btn btn-default" OnClick="btnCliente_Click" />
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-md-7">
                                    <h4>Factura: </h4>
                                </div>
                                <div class="form-inline">
                                    <div class="form-group">
                                        <h4>
                                            <asp:Label ID="lblNoFactura" runat="server" Text=""></asp:Label></h4>
                                    </div>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="col-md-2 control-label" for="DropDownSucursal">Sucursal: </label>
                                    <div class="col-md-10">
                                        <asp:DropDownList ID="DropDownSucursal" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="col-md-2 control-label">Fecha: </label>
                                    <div class="col-md-10">
                                        <asp:TextBox ID="txtDate" runat="server" CssClass="Date" ClientIDMode="Static" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-offset-2 col-md-10">
                                        <asp:Button ID="btnSucursal" runat="server" Text="Agregar" CssClass="btn btn-default" OnClick="btnSucursal_Click" />
                                    </div>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <h4>Agregar prouctos</h4>
                            <div class="form-inline">
                                <%--                            <div class="form-group">
                                    <label class="col-md-6 control-label" for="txtPrecioSugerido">Precio sugerido: </label>
                                    <div class="col-md-6">
                                        <asp:TextBox ID="txtPrecioSugerido" runat="server" disabled CssClass="form-control"></asp:TextBox>
                                    </div>
                                </div>--%>
                                <div class="form-group">
                                    <label for="txtSku" class="sr-only">Código del producto: </label>
                                    <asp:TextBox ID="txtSku" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Producto" OnTextChanged="txtSku_TextChanged"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtCantidad" class="sr-only">Cantidad de productos: </label>
                                    <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Cantidad"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="txtPrecio" class="sr-only">Cantidad de productos: </label>
                                    <div class="input-group">
                                        <div class="input-group-addon">Q</div>
                                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Precio"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:LinkButton ID="btnAgregarProducto" runat="server" CssClass="btn btn-default" OnClick="btnAgregarProducto_Click">
                                        <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
                                    </asp:LinkButton>
                                </div>
                            </div>
                        </li>
                        <li class="list-group-item">
                            <asp:ListBox ID="ListBox1" runat="server"></asp:ListBox>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
