<%@ Page Title="" Language="C#" MasterPageFile="~/Cesiones.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAppCesionesPago.Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="panel panel-default">
                    <div class="panel-heading text-center">
                        <div class="form-inline">
                            <div class="form-group">
                                <img src="Media/Imagenes/logo_skytex.png" width="50" height="50" />
                            </div>
                            <div class="form-group">
                                <h2>Cesiones de Pago</h2>
                            </div>
                        </div>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-2">
                                <strong><asp:Label ID="lbl3" runat="server" Text="Tipo de Cesión:"></asp:Label></strong>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlTipCesion" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-2">
                                <strong><asp:Label ID="Label1" runat="server" Text="Tipo de Pago:"></asp:Label></strong>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlTipoPago" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipoPago_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-2">
                                <strong><asp:Label ID="Label2" runat="server" Text="Tipo de Documento:"></asp:Label></strong>
                            </div>
                            <div class="col-md-6">
                                <asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-2"></div>
                            <div class="col-md-2">
                                <strong><asp:Label ID="Label3" runat="server" Text="Número de Folio:"></asp:Label></strong>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtBuscarFolio" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-2 text-center">
                                <asp:Button ID="btnAutorizar" runat="server" Text="Autorizar" CssClass="btn btn-success btn-lg" OnClick="btnAutorizar_Click" OnClientClick="return validar('Autorizar')"/>
                            </div>
                            <div class="col-md-2 text-center">
                                <asp:Button ID="btnRechazar" runat="server" Text="Rechazar"  CssClass="btn btn-danger btn-lg" OnClick="btnRechazar_Click" OnClientClick="return validar('Rechazar')"/>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validar(boton) {
            if ($('#<%=ddlTipCesion.ClientID%>').val().trim() === 'NA') 
            {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=ddlTipoPago.ClientID%>').val().trim() === 'NA') {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=ddlTipoDocumento.ClientID%>').val().trim() === 'NA') {
                alert('Completar todos los campos');
                return false;
            } else if ($('#<%=txtBuscarFolio.ClientID%>').val() === '') {
                alert('Completar todos los campos');
                return false;
            } else {
                return confirm('¿Desea '+boton+' este pago?')
            }
        }
    </script>
</asp:Content>
