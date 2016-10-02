<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteBoletas.aspx.cs" Inherits="EleganciaWeb.ReporteBoletas" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=12.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <div class="row">
        <div class="col-lg-12">
            <ul class="list-group">
                <li class="list-group-item">
                    <h4>Entradas de mercadería</h4>
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="chkOpcion" class="contro-label">¿Desea filtrar por tipo de boleta?</label>
                                <asp:CheckBox ID="chkOpcion" runat="server" text="" OnCheckedChanged="chkOpcion_CheckedChanged" AutoPostBack="true"/>
                            </div>
                            <div class="form-group">
                                <label for="ddTipoBoleta" class="col-md-4 control-label">Serie:</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddTipoBoleta" runat="server" CssClass="form-control" Enabled="false">
                                        <asp:ListItem>Seleccione Tipo</asp:ListItem>
                                        <asp:ListItem Value="E">Entrada</asp:ListItem>
                                        <asp:ListItem Value="S">Salida</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtNumero" class="col-md-4 control-label">Numero de boleta:</label>
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
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="850px"></rsweb:ReportViewer>
                </li>
            </ul>
        </div>
    </div>
    <div class="row">
        <asp:Label ID="lblMensaje" runat="server" Text="" Visible="false" ClientIDMode="Static"></asp:Label>
    </div>
</asp:Content>
