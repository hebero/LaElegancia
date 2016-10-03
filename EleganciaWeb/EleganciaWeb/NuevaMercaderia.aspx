<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaMercaderia.aspx.cs" Inherits="EleganciaWeb.NuevaMercaderia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-12 col-lg-12 col-xs-12">
            <h2>Nueva mercadería</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12 col-md-offset-0">
            <div class="panel panel-default">
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="row">
                            <div class="col-md-7 col-md-offset-2">
                                <h4>Boleta: </h4>
                            </div>
                            <div class="form-inline">
                                <div class="form-group">
                                    <h4>
                                        <asp:Label ID="lblBoleta" runat="server" Text=""></asp:Label></h4>
                                </div>
                            </div>
                        </div>
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label class="col-md-1 control-label" for="DropDownSucursal">Sucursal: </label>
                                <div class="col-md-10">
                                    <asp:DropDownList ID="DropDownSucursal" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-1 control-label" for="txtDate">Fecha: </label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtDate" runat="server" CssClass="Date txtDate" ClientIDMode="Static" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <label class="col-md-1 control-label" for="txtDescripcion">Descripción: </label>
                                <div class="col-md-10">
                                    <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" ClientIDMode="Static" TextMode="MultiLine" Font-Bold="False" Rows="4"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-9 col-md-2">
                                    <asp:Button ID="btnSucursal" runat="server" Text="Agregar" CssClass="btn btn-primary" OnClick="btnSucursal_Click" />
                                </div>
                            </div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <h4>Agregar prouctos</h4>
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="txtSku" class="sr-only">Código del producto: </label>
                                <asp:TextBox ID="txtSku" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="SKU"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtCantidad" class="sr-only">Cantidad de productos: </label>
                                <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Cantidad"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtDaniado" class="sr-only">Cantidad de productos: </label>
                                <asp:TextBox ID="txtDaniado" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Producto dañado" Text=""></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtPrecio" class="sr-only">Cantidad de productos: </label>
                                <div class="input-group">
                                    <div class="input-group-addon">Q.</div>
                                    <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" ClientIDMode="Static" placeholder="Precio de referencia"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                    <asp:TextBox ID="txtVencimiento" runat="server" CssClass="txtDate" ClientIDMode="Static" ReadOnly="True"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="btnAgregarProducto" runat="server" CssClass="btn btn-default" OnClick="btnAgregarProducto_Click" data-toggle="tooltip" title="Agregar mercadería." data-placement="top">
                                        <span class="glyphicon glyphicon-ok" aria-hidden="true"></span>
                                </asp:LinkButton>
                            </div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <asp:GridView ID="gvProductos" runat="server" BorderStyle="None" CssClass="table table-hover" GridLines="None" ShowHeader="False"></asp:GridView>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-10 col-md-offset-2">
            <asp:Label ID="lblMensaje" runat="server" Text="" Visible="false" ClientIDMode="Static"></asp:Label>
        </div>
    </div>
</asp:Content>
