using CesionesPago.LogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCesionesPago
{
    public partial class _Default : Page
    {
        LogicaNegocios logicaNegocio = new LogicaNegocios();
        string mensaje = "";
        short? error = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /* se llena el combo de Tipo de Cesión con el clave de la opcion 206 */
                ddlTipCesion.DataSource = logicaNegocio.consTipCesion("194");
                ddlTipCesion.DataTextField = "op_nom";
                ddlTipCesion.DataValueField = "op_val";
                ddlTipCesion.DataBind();
                ddlTipCesion.Items.Insert(0, new ListItem("Selecciona Tipo Cesion", "NA"));

                /* se llena el combo de Tipo Pago con el clave de la opcion 207 */
                ddlTipPago.DataSource = logicaNegocio.consTipCesion("195");
                ddlTipPago.DataTextField = "op_nom";
                ddlTipPago.DataValueField = "op_val";
                ddlTipPago.DataBind();
                ddlTipPago.Items.Insert(0, new ListItem("Selecciona Tipo Pago", "NA"));
                gvCP.DataSource = logicaNegocio.consCtmov("001", "BTCEPG", null, 64);
                gvCP.DataBind();
                if (variables.Num_Fol == 0 || string.IsNullOrEmpty(variables.TipCesionPago) == true || string.IsNullOrEmpty(variables.TipPago) == true)
                {
                    txtNumFol.Text = logicaNegocio.ultFolio("001", "BTCEPG").ToString();
                    txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                else
                {
                    txtNumFol.Text = variables.Num_Fol.ToString();
                    txtFecha.Text = variables.FecGenerado.ToString("dd/MM/yyyy");
                    ddlTipCesion.SelectedValue = variables.TipCesionPago;
                    ddlTipPago.SelectedValue = variables.TipPago;

                    /* llena de la tabla con los detalles del ctdmov */
                    gvCP.DataSource = logicaNegocio.consCtmov("001", "BTCEPG", null, variables.Num_Fol);
                    gvCP.DataBind();
                }
            }
        }

        protected void btnGenerar_Click(object sender, EventArgs e)
        {
            if (ddlTipCesion.SelectedValue.Equals("NA") == false || ddlTipPago.SelectedValue.Equals("NA") == false)
            {
                variables.Num_Fol = Int32.Parse(txtNumFol.Text);
                variables.TipCesionPago = ddlTipCesion.SelectedValue;
                variables.TipPago = ddlTipPago.SelectedValue;
                variables.FecGenerado = DateTime.Parse(txtFecha.Text);
                CesionesPago.Entidades.sp_WebAppInsertaCtmov_Result insertCtmov = logicaNegocio.insertCtmov(variables.Num_Fol, variables.FecGenerado, Int32.Parse(variables.TipCesionPago), variables.TipPago, "001", "BTCEPG");
                if (insertCtmov != null)
                {
                    error = insertCtmov.error;
                    mensaje = insertCtmov.mensaje;
                    if (Convert.ToInt32(error) == 0)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Generado Correctamente'); window.location.href = 'Inicio.aspx';</script>");
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Ocurrio un error, intente mas tarde'); window.location.href = 'Inicio.aspx';</script>");
                    }
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Seleccione una opcion corresta en los combos');</script>");
            }            
        }

        protected void chkRechaza_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("<script type=\"text/javascript\">alert('Rechazado Correctamente'); window.location.href = 'Inicio.aspx';</script>");
        }

        protected void chkAutoriza_CheckedChanged(object sender, EventArgs e)
        {
            Response.Write("<script type=\"text/javascript\">alert('Autorizado Correctamente'); window.location.href = 'Inicio.aspx';</script>");
        }
    }
}