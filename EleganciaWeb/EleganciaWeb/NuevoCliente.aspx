﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevoCliente.aspx.cs" Inherits="EleganciaWeb.NuevoCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h2>Nuevo cliente</h2>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-8 col-lg-offset-2">
            <ul class="list-group">
                <li class="list-group-item">
                    <div class="form-horizontal">
                        <h5>Nombres</h5>
                        <div class="form-group">
                            <label for="txtNombre1" class="col-sm-2 control-label control-label">Primer nombre: </label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ejemplo: Gustavo"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" CssClass="alert-warning" runat="server" ErrorMessage="Campo requerido." ControlToValidate="txtNombre"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtNombre2" class="col-sm-2 control-label control-label">Segundo nombre: </label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtNombre2" runat="server" CssClass="form-control" placeholder="Ejemplo: Donis"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="alert-warning" runat="server" ErrorMessage="Campo requerido." ControlToValidate="txtNombre2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <h5>Apellidos</h5>
                        <div class="form-group">
                            <label for="txtApellido" class="col-sm-2 control-label control-label">Apellido: </label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtApellido1" runat="server" CssClass="form-control" placeholder="Ejemplo: Hernández"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="alert-warning" runat="server" ErrorMessage="Campo requerido." ControlToValidate="txtApellido1"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group">
                            <label for="txtApellido2" class="col-sm-2 control-label control-label">Apellido: </label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtApellido2" runat="server" CssClass="form-control" placeholder="Ejemplo: Peláez"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" CssClass="alert-warning" runat="server" ErrorMessage="Campo requerido." ControlToValidate="txtApellido2"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <h5>Número de Nit</h5>
                        <div class="form-group">
                            <label for="txtNit" class="col-sm-2 control-label control-label">Nit: </label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtNit" runat="server" CssClass="form-control" placeholder="Ejemplo: 123456789-9"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="alert-warning" runat="server" ErrorMessage="Campo requerido." ControlToValidate="txtNit"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                </li>
                <li class="list-group-item">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="ddDepartamento">Departamento: </label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddDepartamento" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddDepartamento_SelectedIndexChanged" AutoPostBack="True" onchange="hacerpost();"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="ddMunicipio">Municipio: </label>
                            <div class="col-sm-8">
                                <asp:DropDownList ID="ddMunicipio" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddMunicipio_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-2 control-label" for="txtDireccion">Direccion: </label>
                            <div class="col-sm-8">
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-lg-2">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" CssClass="alert-warning" runat="server" ErrorMessage="Campo requerido." ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>
                            </div>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Campo requerido" CssClass="col-sm-4 alert alert-warning" ControlToValidate="txtDireccion"></asp:RequiredFieldValidator>--%>
                        </div>
                        <div class="form-group">
                            <asp:LinkButton ID="btnAgregar" runat="server" CssClass="col-sm-offset-4 col-sm-4 btn btn-success" OnClick="btnAgregar_Click">
                                    <span class="glyphicon glyphicon-plus" aria-hidden="true"></span> Crear usuario
                            </asp:LinkButton>
                        </div>
                    </div>
                </li>
            </ul>
        </div>
        <div class="col-lg-2">
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <asp:Label ID="lblMensaje" runat="server" Text="" Visible="true" ClientIDMode="Static"></asp:Label>
        </div>
    </div>
    <script>
        function hacerpost() {
            __doPostBack('<%= ddDepartamento.UniqueID %>', '');
        }
    </script>
</asp:Content>
