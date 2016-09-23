<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductoNuevo.aspx.cs" Inherits="EleganciaWeb.ProductoNuevo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <h1>Nuevo producto</h1>
        </div>
        <div class="row">
            <div class="col-md-8 col-lg-8 col-xs-8 col-md-offset-2 col-lg-offset-2 col-xs-offset-2">
                <div class="panel panel-default">
                    <div class="panel-heading">
                        <div class="panel-title">
                            <h4>Nuevo producto</h4>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="form-horizontal">
                            <div class="form-group">
                                <label for="txtSKU" class="col-lg-2 control-label">SKU: </label>
                                <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="txtNombre" class="col-lg-2 control-label">Nombre: </label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <asp:LinkButton ID="btnCrear" runat="server" CssClass="col-lg-offset-3 btn btn-primary"><span class="glyphicon glyphicon-plus" aria-hidden="true"></span> Guardar</asp:LinkButton>
                            </div>
                        </div>

                        <asp:Label ID="lblAlerta" runat="server" Visible="false" Text=""></asp:Label>
                    </div>
                </div>
            </div>
            &nbsp;&nbsp;&nbsp;
        </div>
    </div>
</asp:Content>
