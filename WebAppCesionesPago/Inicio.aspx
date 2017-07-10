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
                <div class="row">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-2" style="display:none;">
                                <strong><asp:Label ID="lbl1" runat="server" Text="No. Folio:"></asp:Label></strong>
                                <asp:TextBox ID="txtNumFol" runat="server" type="number" CssClass="form-control" min="1" ReadOnly="true" required="true"></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbl2" runat="server" Text="Fecha:"></asp:Label></strong>
                                <asp:TextBox ID="txtFecha" runat="server" CssClass="form-control" ReadOnly="true" ></asp:TextBox>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbl3" runat="server" Text="Tipo Cesión:"></asp:Label></strong>
                                <asp:DropDownList ID="ddlTipCesion" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipCesion_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-3">
                                <strong><asp:Label ID="lbl4" runat="server" Text="Tipo Pago:"></asp:Label></strong>
                                <asp:DropDownList ID="ddlTipPago" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlTipPago_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div> 
                            <div class="col-md-3">
                                <br />
                                <div class="input-group">
                                    <asp:TextBox ID="txtBuscarFolio" runat="server" CssClass="form-control" placeholder="Buscar Folio"></asp:TextBox>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="btnBuscarFolio" runat="server" CssClass="btn btn-info" OnClick="btnBuscarFolio_Click">
                                            <span aria-hidden="true" class="glyphicon glyphicon-search"></span>
                                        </asp:LinkButton>
                                    </span>
                                    <span class="input-group-btn">
                                        <asp:LinkButton ID="btnCancelaFiltro" runat="server" CssClass="btn btn-danger" OnClick="btnCancelaFiltro_Click" Visible="false">
                                            <span aria-hidden="true" class="glyphicon glyphicon-remove"></span>
                                        </asp:LinkButton>
                                    </span>
                                </div>
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
                <div class="table-responsive">
                <asp:GridView ID="gvCP" runat="server" AutoGenerateColumns="false" HeaderStyle-BackColor="#042644" 
                    HeaderStyle-ForeColor="White" EmptyDataText="No hay resultados" CssClass="table" Font-Size="Smaller">
                    <HeaderStyle Font-Bold="True" />
                        <Columns>
                            <asp:BoundField DataField="ef_cve" HeaderText="Entidad Financiera" />
                            <asp:BoundField DataField="tipo_doc" HeaderText="Documento" />
                            <asp:BoundField DataField="num_fol" HeaderText="Folio" />
                            <asp:BoundField DataField="cc_tipo" HeaderText="Documento" />
                            <asp:BoundField DataField="dato10" HeaderText="Importe" />
                            <asp:BoundField DataField="tm" HeaderText="Tipo de Moneda" />
                            <asp:BoundField DataField="nombre" HeaderText="Nombre" />
                            <asp:TemplateField HeaderText="Autorizar:" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkAutoriza" runat="server" 
                                        onclick="if (!confirm('Esta seguro de que quiere autorizar el pago??')) return false;" OnCheckedChanged="chkAutoriza_CheckedChanged" AutoPostBack="true"
                                        Text="Autorizar"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Rechazar:" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkRechaza" runat="server" 
                                        onclick="if (!confirm('Esta seguro de que quiere rechazar el pago??')) return false" OnCheckedChanged="chkRechaza_CheckedChanged" AutoPostBack="true"
                                        Text="Rechazar"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                </asp:GridView>
                </div>
            </div>
        </div>
        <br />
        <div class="row">
            <div class="col-md-10">
            </div>
            <div class="col-md-2">
                <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesión" CssClass="btn btn-danger" OnClick="btnLogout_Click"/>
            </div>
        </div>
    </div>
</asp:Content>
