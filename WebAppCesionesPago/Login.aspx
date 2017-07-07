<%@ Page Title="" Language="C#" MasterPageFile="~/Cesiones.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebAppCesionesPago.Login" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row ">
            <div class="col-md-3">
            </div>
            <div class="col-md-6 text-center"><br />
                <h1>Iniciar Sesión</h1><br />
                <div class="panel panel-default">
                    <div class="panel-body text-center">
                        <asp:DropDownList ID="ddlUsuarios" runat="server" CssClass="form-control"></asp:DropDownList>
                        <br />
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
                        <br />
                        <asp:Button ID="Inicio" runat="server" Text="Iniciar Sesión" CssClass="btn btn-success" OnClick="Inicio_Click"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
