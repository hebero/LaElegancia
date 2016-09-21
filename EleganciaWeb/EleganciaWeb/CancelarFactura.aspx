<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CancelarFactura.aspx.cs" Inherits="EleganciaWeb.CancelarFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-8 col-md-offset-2">
<%--            <div class="panel panel-default">--%>
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="row">
                            <h4>Factura</h4>
                        </div>
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="ddSerie" class="col-md-4 control-label">Serie:</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddSerie" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtNumero" class="col-md-4 control-label">Serie:</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class ="form-group">
                                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="col-md-offset-3 btn btn-primary" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-search" aria-hidden="true"></span> Buscar</asp:LinkButton>
                            </div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="txtSurcursal" class="col-md-4 control-label">Sucursal: </label>
                                <asp:TextBox ID="txtSurcursal" runat="server" disabled CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </li>
                    <li class="list-group-item"></li>
                </ul>
            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
            </div>
        </div>
<%--    </div>--%>
</asp:Content>
