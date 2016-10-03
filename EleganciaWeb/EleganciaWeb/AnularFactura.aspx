<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AnularFactura.aspx.cs" Inherits="EleganciaWeb.AnularFactura" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <asp:Panel ID="pnlAddClassModal" runat="server" role="dialog" ClientIDMode="Static" CssClass="modal fade">
        <asp:Panel ID="pnlInner" runat="server" CssClass="modal-dialog">
            <asp:Panel ID="pnlContent" runat="server" CssClass="modal-content">
                <asp:Panel ID="Panel1" runat="server" class="modal-header">
                    <button type="button" class="close" data-dismiss="modal">
                        <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
                     </button>
                    <h4 class="modal-title">¿Desea anular la factura?</h4>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server" CssClass="modal-footer">
                    <button type="button" class="btn btn-danger" data-dismiss="modal">No</button>
                    <asp:LinkButton ID="btnAnular" runat="server" CssClass="btn btn-success" data-dismiss="modal" OnClientClick="hacerpost();"  UseSubmitBehavior="false" ClientIDMode="Static" OnClick="btnAnular_Click">Si</asp:LinkButton>
                </asp:Panel>
            </asp:Panel>
        </asp:Panel>
    </asp:Panel>
        <div class="row">
        <div class="col-md-8 col-md-offset-2">
                <ul class="list-group">
                    <li class="list-group-item">
                        <div class="row">
                            <h4>Datos de la Factura</h4>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Solo números." ValidationExpression="^\d+$" ControlToValidate="txtNumero" CssClass="col-lg-offset-5 alert-warning"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Numero requerido." ControlToValidate="txtNumero" CssClass="alert-warning"></asp:RequiredFieldValidator>
                        </div>
                        <div class="form-inline">
                            <div class="form-group">
                                <label for="ddSerie" class="col-md-2 control-label">Serie:</label>
                                <div class="col-md-4">
                                    <asp:DropDownList ID="ddSerie" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="form-group">
                                <label for="txtNumero" class="col-md-2 control-label">Numero:</label>
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
                                <label for="lblSucursal" class="col-md-2">Sucursal: </label>
                                <asp:Label ID="lblSucursal" runat="server" Text="--" CssClass="col-md-4"></asp:Label>
                                <label for="lblFecha" class="col-md-2">Fecha: </label>
                                <asp:Label ID="lblFecha" runat="server" Text="--" CssClass="col-md-2"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="lblCliente" class="col-md-2">Cliente: </label>
                                <asp:Label ID="lblCliente" runat="server" Text="--" CssClass="col-md-4"></asp:Label>
                                <label for="lblNit" class="col-md-2">Nit: </label>
                                <asp:Label ID="lblNit" runat="server" Text="--" CssClass="col-md-2"></asp:Label>
                            </div>
                            <div class="form-group">
                                <label for="lblEstado" class="col-md-2">Estado: </label>
                                <asp:Label ID="lblEstado" runat="server" Text="--" CssClass="col-md-2"></asp:Label>
                                <asp:LinkButton ID="btnPreAnular" runat="server" data-toggle="modal" data-target="#pnlAddClassModal" Visible="false" CssClass="btn btn-primary col-lg-offset-9">
                                    <span class="glyphicon glyphicon-remove" aria-hidden="true"></span> Anular
                                </asp:LinkButton>
                            </div>
                        </div>
                    </li>
                </ul>
            <asp:Label ID="lblMensaje" runat="server" Text="" ClientIDMode="Static"></asp:Label>
            </div>
        </div>
    <script>
        function hacerpost() {
            __doPostBack('<%= btnAnular.UniqueID %>', '');
        }
    </script>
</asp:Content>
