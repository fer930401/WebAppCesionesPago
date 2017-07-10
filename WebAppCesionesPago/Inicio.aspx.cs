using CesionesPago.LogicaNegocios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebAppCesionesPago
{
    public partial class _Default : Page
    {
        LogicaNegocios logicaNegocio = new LogicaNegocios();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscarFolio.UniqueID;
            if (Session["user_cve"]!=null)
            {
                if (!IsPostBack)
                {
                    /*SQL: se llena el combo de Tipo de Cesión con el clave de la opcion 206 */
                    /*Develop: se llena el combo de Tipo de Cesión con el clave de la opcion 194 */
                    ddlTipCesion.DataSource = logicaNegocio.consTipCesion("206");
                    ddlTipCesion.DataTextField = "op_nom";
                    ddlTipCesion.DataValueField = "op_val";
                    ddlTipCesion.DataBind();
                    ddlTipCesion.Items.Insert(0, new ListItem("Selecciona Tipo Cesion", "NA"));

                    /*SQL: se llena el combo de Tipo Pago con el clave de la opcion 207 */
                    /*Develop: se llena el combo de Tipo Pago con el clave de la opcion 195 */
                    ddlTipPago.DataSource = logicaNegocio.consTipCesion("207");
                    ddlTipPago.DataTextField = "op_nom";
                    ddlTipPago.DataValueField = "op_val";
                    ddlTipPago.DataBind();
                    ddlTipPago.Items.Insert(0, new ListItem("Selecciona Tipo Pago", "NA"));

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
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void chkRechaza_CheckedChanged(object sender, EventArgs e)
        {
            int num_folEnc = Convert.ToInt32(logicaNegocio.ultFolio("001", "BTCEPG").ToString());
            int tipo_cesion = Convert.ToInt32(ddlTipCesion.SelectedValue);
            string tipo_pago = ddlTipPago.Text;
            string user = Session["user_cve"].ToString();
            GridViewRow row = (sender as CheckBox).Parent.Parent as GridViewRow;
            string ef_cve = row.Cells[0].Text;
            string tipo_doc = row.Cells[1].Text;
            int num_fol = Convert.ToInt32(row.Cells[2].Text);
            decimal importe = Convert.ToDecimal(row.Cells[4].Text);
            string tm = row.Cells[5].Text;
            string nombre = row.Cells[6].Text;

            CesionesPago.Entidades.sp_WebAppInsertaCtmov_Result resultado = logicaNegocio.insertCtmov(num_folEnc, DateTime.Today, tipo_cesion, tipo_pago, "001", "BTCEPG", user, ef_cve, tipo_doc, num_fol, importe, tm, nombre, 2);

            if (resultado.error == 0)
            {
                gvCP.Visible = false;
                gvCP.DataSource = null;
                gvCP.DataBind();
                btnCancelaFiltro.Visible = false;
                btnBuscarFolio.Visible = true;
                txtBuscarFolio.Enabled = true;
                txtBuscarFolio.Text = "";
                Response.Write("<script type=\"text/javascript\">alert('Rechazado Correctamente'); window.location.href = 'Inicio.aspx';</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('error: " + resultado.mensaje + "'); window.location.href = 'Inicio.aspx';</script>");
            }
            
        }

        protected void chkAutoriza_CheckedChanged(object sender, EventArgs e)
        {
            int num_folEnc = Convert.ToInt32(logicaNegocio.ultFolio("001", "BTCEPG").ToString());
            int tipo_cesion = Convert.ToInt32(ddlTipCesion.SelectedValue);
            string tipo_pago = ddlTipPago.Text;
            string user = Session["user_cve"].ToString();
            GridViewRow row = (sender as CheckBox).Parent.Parent as GridViewRow;
            string ef_cve = row.Cells[0].Text;
            string tipo_doc = row.Cells[1].Text;
            int num_fol = Convert.ToInt32(row.Cells[2].Text);
            decimal importe = Convert.ToDecimal(row.Cells[4].Text);
            string tm = row.Cells[5].Text;
            string nombre =row.Cells[6].Text;
            CesionesPago.Entidades.sp_WebAppInsertaCtmov_Result resultado = logicaNegocio.insertCtmov(num_folEnc, DateTime.Today, tipo_cesion, tipo_pago, "001", "BTCEPG", user, ef_cve, tipo_doc, num_fol, importe, tm, nombre, 1);

            if (resultado.error==0)
            {
                gvCP.Visible = false;
                gvCP.DataSource = null;
                gvCP.DataBind();
                btnCancelaFiltro.Visible = false;
                btnBuscarFolio.Visible = true;
                txtBuscarFolio.Enabled = true;
                txtBuscarFolio.Text = "";
                Response.Write("<script type=\"text/javascript\">alert('Autorizado Correctamente'); window.location.href = 'Inicio.aspx';</script>");
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('error: "+resultado.mensaje+"'); window.location.href = 'Inicio.aspx';</script>");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            variables.Num_Fol = 0;
            Response.Redirect("Login.aspx");
        }

        protected void ddlTipCesion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipCesion.SelectedValue.Equals("NA") == false && ddlTipPago.SelectedValue.Equals("NA") == false)
            {
                gvCP.Visible = true;
                gvCP.DataSource = null;
                gvCP.DataBind();
                gvCP.DataSource = logicaNegocio.ConsultaPagos("001", "BTCEPG", ddlTipPago.SelectedValue);
                gvCP.DataBind();
                btnCancelaFiltro.Visible = false;
                btnBuscarFolio.Visible = true;
                txtBuscarFolio.Enabled = true;
                txtBuscarFolio.Text = "";
            }
            else
            {
                gvCP.Visible = false;
                gvCP.DataSource = null;
                gvCP.DataBind();
            }
        }

        protected void ddlTipPago_SelectedIndexChanged(object sender, EventArgs e)
        {   //Cada que cambia el indice del combo se llena el gridview solo si los 2 combos tienen datos seleccionados
            if (ddlTipCesion.SelectedValue.Equals("NA") == false && ddlTipPago.SelectedValue.Equals("NA") == false)
            {
                gvCP.Visible = true;
                gvCP.DataSource = null;
                gvCP.DataBind();
                gvCP.DataSource = logicaNegocio.ConsultaPagos("001", "BTCEPG", ddlTipPago.SelectedValue);
                gvCP.DataBind();
                btnCancelaFiltro.Visible = false;
                btnBuscarFolio.Visible = true;
                txtBuscarFolio.Enabled = true;
                txtBuscarFolio.Text = "";
            }
            else
            {
                gvCP.Visible = false;
                gvCP.DataSource = null;
                gvCP.DataBind();
            }
        }

        protected void btnBuscarFolio_Click(object sender, EventArgs e)
        {//busca el folio solo si los combos tienen algo seleccionado, el txt es numerico y no esta vacio
            if (ddlTipCesion.SelectedValue.Equals("NA") == false && ddlTipPago.SelectedValue.Equals("NA") == false)
            {
                if (txtBuscarFolio.Text!="")
                {
                    if (Regex.IsMatch(txtBuscarFolio.Text, "^[0-9]+$"))
                    {
                        List<CesionesPago.Entidades.sp_WebAppConsultaPagos_Result> pagos = logicaNegocio.ConsultaPagos("001", "BTCEPG", ddlTipPago.SelectedValue);
                        pagos = pagos.FindAll(s => s.num_fol.Equals(Convert.ToInt32(txtBuscarFolio.Text)));
                        if (pagos.Count > 0)
                        {
                            gvCP.Visible = true;
                            gvCP.DataSource = null;
                            gvCP.DataBind();
                            gvCP.DataSource = pagos;
                            gvCP.DataBind();
                            btnCancelaFiltro.Visible = true;
                            btnBuscarFolio.Visible = false;
                            txtBuscarFolio.Enabled = false;
                        }
                        else
                        {
                            txtBuscarFolio.Text = "";
                            Response.Write("<script type=\"text/javascript\">alert('Busqueda de Folios sin resultados');</script>");
                        }
                    }
                    else
                    {
                        txtBuscarFolio.Text = "";
                        Response.Write("<script type=\"text/javascript\">alert('Formato de Folio Incorrecto');</script>");
                    }
                    
                }                
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Seleccione una opción correcta en los combos');</script>");
            }
        }

        protected void btnCancelaFiltro_Click(object sender, EventArgs e)
        {//borra el filtro del folio buscado
            btnCancelaFiltro.Visible = false;
            btnBuscarFolio.Visible = true;
            txtBuscarFolio.Text = "";
            txtBuscarFolio.Enabled = true;
            if (ddlTipCesion.SelectedValue.Equals("NA") == false && ddlTipPago.SelectedValue.Equals("NA") == false)
            {
                gvCP.Visible = true;
                gvCP.DataSource = null;
                gvCP.DataBind();
                gvCP.DataSource = logicaNegocio.ConsultaPagos("001", "BTCEPG", ddlTipPago.SelectedValue);
                gvCP.DataBind();
            }
            else
            {
                gvCP.Visible = false;
                gvCP.DataSource = null;
                gvCP.DataBind();
            }
        }
    }
}