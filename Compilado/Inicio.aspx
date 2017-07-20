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
                                <strong><asp:Label ID="Label3" runat="server" Text="Número de Folio:"></asp:Label></strong>
                            </div>
                            <div class="col-md-6">
                                <asp:TextBox ID="txtBuscarFolio" runat="server" CssClass="form-control" OnTextChanged="txtBuscarFolio_TextChanged" AutoPostBack="true"></asp:TextBox>
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
                        <div class="text-center">
                            <asp:Button ID="btnAutorizar" runat="server" Text="Autorizar" CssClass="btn btn-success btn-lg" OnClick="btnAutorizar_Click" OnClientClick="return validar()"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function validar() {
            var folio =$('#<%=txtBuscarFolio.ClientID%>').val();
            if ( folio === '') {
                alert('Completar todos los campos');
                return false;
            }
            var isNumeric = folio.match(/^\d+$/);
            if (!isNumeric) {
                alert('Formato de folio incorrecto')
                return false;
            }
            if ($('#<%=ddlTipoDocumento.ClientID%>').val() === 'NA') {
                alert('Seleccionar tipo de documento');
                return false;
            }
            return confirm('¿Desea Autorizar este pago?');
        }
    </script>
</asp:Content>
