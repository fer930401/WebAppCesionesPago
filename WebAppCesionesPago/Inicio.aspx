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
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbl1" runat="server" Text="No. Folio:"></asp:Label></strong>
                                <asp:TextBox ID="txtNumFol" runat="server" type="number" CssClass="form-control" min="1" ReadOnly="true" required></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbl2" runat="server" Text="Fecha:"></asp:Label></strong>
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbl3" runat="server" Text="Tipo Cesión:"></asp:Label></strong>
                                <asp:DropDownList ID="ddlTipCesion" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbl4" runat="server" Text="Tipo Pago:"></asp:Label></strong>
                                <asp:DropDownList ID="ddlTipPago" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>                            
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <br />
                                <asp:Button ID="btnGenerar" runat="server" Text="Generar" CssClass="btn btn-success" OnClick="btnGenerar_Click"/>
                            </div>
                        </div>
                        <br />
                        <br />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:GridView ID="gvCP" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#042644" 
                    HeaderStyle-ForeColor="White" EmptyDataText="No hay resultados">
                    <HeaderStyle Font-Bold="True" />
                        <Columns>
                            <asp:BoundField DataField="num_reng" HeaderText="No.:" />
                            <asp:BoundField DataField="importe" HeaderText="Importe:" />
                            <asp:BoundField DataField="docp_nom" HeaderText="Documento Referenciado:" />
                            <asp:BoundField DataField="num_folp" HeaderText="Folio:" />
                            <asp:BoundField DataField="nom_benefi" HeaderText="Proveedor:" />
                            <asp:TemplateField HeaderText="Autorizar:" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAutoriza" runat="server" 
                                        Checked='<%# Convert.ToBoolean(Convert.ToInt32(Eval("num_folad").ToString())) %>' 
                                        onclick="if (!confirm('Esta seguro de que quiere autorizar el pago??')) return false;" OnCheckedChanged="chkAutoriza_CheckedChanged" AutoPostBack="true"
                                        Text="Autorizar"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rechazar:" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRechaza" runat="server" 
                                        Checked='<%# Convert.ToBoolean(Convert.ToInt32(Math.Ceiling(float.Parse(Eval("dato4").ToString())))) %>'
                                        onclick="if (!confirm('Esta seguro de que quiere rechazar el pago??')) return false;" OnCheckedChanged="chkRechaza_CheckedChanged" AutoPostBack="true"
                                        Text="Rechazar"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
