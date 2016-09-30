<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ArticulosPorBodega.aspx.cs" Inherits="EleganciaWeb.ArticulosPorBodega" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral,

PublicKeyToken=89845dcd8080cc91"

Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-10">
            <ul class="list-group">
                <li class="list-group-item">
                    <h4>Listado de productos en existencia por sucursal</h4>
                    <div class="form-inline">
                        <label for="ddSucursal" class="control-label">Sucursales</label>
                        <asp:DropDownList ID="ddSucursales" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddSucursales_SelectedIndexChanged"></asp:DropDownList>
                        <input id="Button1" type="button" value="button" onclick="hacerpost();" />
                    </div>
                </li>
                <li class="list-group-item">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server"></rsweb:ReportViewer>
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <asp:Label ID="lblMensaje" runat="server" Text="" Visible="false"></asp:Label>
    </div>
    <script>
                function hacerpost() {
            __doPostBack('<%= ddSucursales.UniqueID %>', '');
        }
    </script>
</asp:Content>
