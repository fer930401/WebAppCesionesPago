<%@ Page Language="C#" MasterPageFile="~/Cesiones.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="WebAppCesionesPago._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="well">
            <div class="form-inline">
                <div class="form-group">
                    <img src="Media/Imagenes/logo_skytex.png" width="50" height="50" />
                </div>
                <div class="form-group">
                    <h2>Cesiones de Pago</h2>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h5>De los listados mostrados acontinuacion selecciona la opcion del renglon</h5>
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-4">
                                <strong><asp:Label ID="lbl1" runat="server" Text="Tipo Cesión:"></asp:Label></strong>
                                <asp:DropDownList ID="ddlTipCesion" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-4">
                                <strong><asp:Label ID="lbl2" runat="server" Text="Tipo Pago:"></asp:Label></strong>
                                <asp:DropDownList ID="ddlTipPago" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <asp:GridView ID="GridView1" runat="server"></asp:GridView>
        </div>
    </div>
</asp:Content>
