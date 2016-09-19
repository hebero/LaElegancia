<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaSucursal.aspx.cs" Inherits="EleganciaWeb.NuevaSucursal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Nuevas sucurusales</h2>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="panel panel-default">
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="txtNombre" class="col-sm-2 control-label">Nombre: </label>
                                <div class ="col-sm-5">
                                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Campo requerido" ControlToValidate="txtNombre" CssClass="col-sm-4 alert alert-warning" ClientIDMode="Static"></asp:RequiredFieldValidator>
                            </div>
                            <div class="form-group">
                                <label class="col-sm-2 control-label" for="txtDireccion">Direccion: </label>
                                <div class ="col-sm-5">
                                    <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo requerido" CssClass="col-sm-4 alert alert-warning" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                            </div>
                            <asp:LinkButton ID="btnAgregar" runat="server" CssClass="col-sm-offset-4 col-sm-2 btn btn-success" OnClick="btnAgregar_Click">
                                Agregar <span class="glyphicon glyphicon-plus" aria-hidden="true"></span>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Label ID="lblAlert" runat="server" Text="" Visible="true" ClientIDMode="Static"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
