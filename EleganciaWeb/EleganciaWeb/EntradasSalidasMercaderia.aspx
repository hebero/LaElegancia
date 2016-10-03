<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EntradasSalidasMercaderia.aspx.cs" Inherits="EleganciaWeb.EntradasMercaderia" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <ul class="list-group">
                <li class="list-group-item">
                    <h4>Entradas de mercadería</h4>
                    <div class="form-inline">
                        <div class="form-group">
                            <label for="ddSucursal" class="control-label">Sucursales</label>
                            <asp:DropDownList ID="ddSucursales" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddSucursales_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label for="txtFechaIni" class="control-label">Fecha inicio:</label>
                            <asp:TextBox ID="txtFechaIni" runat="server" CssClass="txtFecha" ClientIDMode="Static" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label for="txtFechaFin" class="control-label">Fecha final:</label>
                            <asp:TextBox ID="txtFechaFin" runat="server" CssClass="txtFecha" ClientIDMode="Static" ></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:LinkButton ID="btnCrear" runat="server" CssClass="btn btn-primary" OnClick="btnCrear_Click">Crear reporte <span class="glyphicon glyphicon-file" aria-hidden="true"></span></asp:LinkButton>
                        </div>
                    </div>
                </li>
                <li class="list-group-item">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="900px"></rsweb:ReportViewer>
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <asp:Label ID="lblMensaje" runat="server" Text="" Visible="false"></asp:Label>
    </div>
</asp:Content>
