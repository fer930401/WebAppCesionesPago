using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CesionesPago.LogicaNegocios;
using CesionesPago.Entidades;

namespace WebAppCesionesPago
{
    public partial class Inicio : System.Web.UI.Page
    {
        LogicaNegocios logicaNegocio = new LogicaNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_cve"] != null)
            {
                if (!IsPostBack)
                {
                        ddlTipCesion.DataSource = logicaNegocio.consTipCesion("206");
                        ddlTipCesion.DataTextField = "op_nom";
                        ddlTipCesion.DataValueField = "op_val";
                        ddlTipCesion.DataBind();
                        ddlTipCesion.Items.Insert(0, new ListItem("Selecciona Tipo de Cesion", "NA"));

                        ddlTipoPago.DataSource = logicaNegocio.consTipCesion("207");
                        ddlTipoPago.DataTextField = "op_nom";
                        ddlTipoPago.DataValueField = "op_val";
                        ddlTipoPago.DataBind();
                        ddlTipoPago.Items.Insert(0, new ListItem("Selecciona Tipo de Pago", "NA"));
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ddlTipoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlTipoDocumento.DataSource = logicaNegocio.ListaDocumentos(ddlTipoPago.SelectedValue);
            ddlTipoDocumento.DataTextField = "nombre";
            ddlTipoDocumento.DataValueField = "tipdoc_cve";
            ddlTipoDocumento.DataBind();
            ddlTipoDocumento.Items.Insert(0, new ListItem("Selecciona Tipo de Documento", "NA"));

        }

        protected void btnAutorizar_Click(object sender, EventArgs e)
        {
            if (ddlTipCesion.SelectedValue!="NA" && ddlTipoDocumento.SelectedValue!="NA" && ddlTipoPago.SelectedValue!="NA" && txtBuscarFolio.Text!="")
            {
                int cesion = Convert.ToInt32(ddlTipCesion.SelectedValue);
                string pago = (ddlTipoPago.SelectedValue).Replace(" ", "");
                string tip_doc = (ddlTipoDocumento.SelectedValue).Replace(" ","");
                int num_fol = Convert.ToInt32(txtBuscarFolio.Text);
                string user = Session["user_cve"].ToString();
                try
                {
                    WebAppCesionesPago_Result procesar = logicaNegocio.ProcesarPago("001", cesion, pago, tip_doc, num_fol, DateTime.Now, 1, user);
                    if (procesar.error == 0)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Pago Autorizado Correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Error: " + procesar.mensaje + "');</script>");
                    }
                }
                catch (Exception msg)
                {
                    Response.Write("<script type=\"text/javascript\">alert('" + msg + "');</script>");
                }
                ddlTipCesion.SelectedIndex = ddlTipoPago.SelectedIndex = ddlTipoPago.SelectedIndex = 0;
                txtBuscarFolio.Text = "";
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Completar todos los campos');</script>");
            }
        }

        protected void btnRechazar_Click(object sender, EventArgs e)
        {
            if (ddlTipCesion.SelectedValue != "NA" && ddlTipoDocumento.SelectedValue != "NA" && ddlTipoPago.SelectedValue != "NA" && txtBuscarFolio.Text != "")
            {
                int cesion = Convert.ToInt32(ddlTipCesion.SelectedValue);
                string pago = (ddlTipoPago.SelectedValue).Replace(" ", "");
                string tip_doc = (ddlTipoDocumento.SelectedValue).Replace(" ", "");
                int num_fol = Convert.ToInt32(txtBuscarFolio.Text);
                string user = Session["user_cve"].ToString();
                try
                {
                    WebAppCesionesPago_Result procesar = logicaNegocio.ProcesarPago("001", cesion, pago, tip_doc, num_fol, DateTime.Now, 2, user);
                    if (procesar.error == 0)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Pago Rechazado Correctamente');</script>");
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Error: " + procesar.mensaje + "');</script>");
                    }
                }
                catch (Exception msg)
                {
                    Response.Write("<script type=\"text/javascript\">alert('" + msg + "');</script>");
                }
                ddlTipCesion.SelectedIndex = ddlTipoPago.SelectedIndex = ddlTipoPago.SelectedIndex = 0;
                txtBuscarFolio.Text = "";
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Completar todos los campos');</script>");
            }
        }
    }
}