<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaBoleta.aspx.cs" Inherits="EleganciaWeb.NuevaBoleta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <h2>Entrada de mercadería</h2>
                <asp:Label ID="lblAlert" runat="server" Text="" Visible="false"></asp:Label>
            </div>
        </div>
        <div class="row">
            <div class="col-md-8 col-md-offset-2">
                <div class="panel panel-default">
                    <ul class="list-group">
                        <li class="list-group-item">
                            <div class="row">
                                <div class="col-sm-4">
                                    <h4>Crear boleta</h4>
                                </div>
                                <div class="col-sm-4">
                                    <asp:Label ID="lblBoleta" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label for="ddSucursal" class="col-sm-2 control-label">Sucursal: </label>
                                    <div class="col-sm-10">
                                        <asp:DropDownList ID="ddSucursal" runat="server" CssClass="form-control"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtDate" class="col-sm-2 control-label">Fecha: </label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtDate" runat="server" class="txtDate" ReadOnly="true"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="txtDescripcion" class="col-sm-2 control-label">Descripcion: </label>
                                    <div class="col-sm-10">
                                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:LinkButton ID="btnCrearBoleta" runat="server" CssClass="col-sm-2 col-sm-offset-4 btn btn-primary" OnClick="btnCrearBoleta_Click">
                                            <span class="glyphicon glyphicon-saved" aria-hidden="true"></span> Crear
                                    </asp:LinkButton>
                                </div>

                            </div>
                        </li>
                        <li class="list-group-item"></li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
