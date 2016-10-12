<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteFactura.aspx.cs" Inherits="EleganciaWeb.ListadoFacturas" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
        <div class="col-md-10 col-md-offset-1">
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="row">
                            <h4>Datos de la Factura</h4>
                        </div>
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="ddSerie" class="col-md-4 control-label">Serie:</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddSerie" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtNumero" class="col-md-4 control-label">Numero de factuar:</label>
                                <div class="col-md-4">
                                    <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class ="form-group">
                                <asp:LinkButton ID="btnBuscar" runat="server" CssClass="col-md-offset-3 btn btn-primary" OnClick="btnBuscar_Click"><span class="glyphicon glyphicon-file" aria-hidden="true"></span> Crear factura</asp:LinkButton>
                            </div>
                        </div>
                    </li>
                    <li class="list-group-item">
                        <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width ="900px" CssClass="table "></rsweb:ReportViewer>
                    </li>
                </ul>
            <asp:Label ID="lblMensaje" runat="server" Text="" ClientIDMode="Static"></asp:Label>
            </div>
        </div>
</asp:Content>
