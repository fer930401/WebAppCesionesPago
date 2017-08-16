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
    public partial class SiteMaster : MasterPage
    {
        LogicaNegocios logica = new LogicaNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user_cve"] != null)
            {
                CerrarSesion.Visible = cb.Visible = ListaEf.Visible = true;
                if (!IsPostBack)
                {
                    ListaEf.DataSource = logica.EntidadesFinancieras(Session["user_cve"].ToString());
                    ListaEf.DataValueField = "ef_cve";
                    ListaEf.DataTextField = "nom1";
                    ListaEf.DataBind();
                    Session["ef"] = ListaEf.SelectedValue;
                    xuconfig consulta = logica.ConsultaConfirming(Session["ef"].ToString());
                    if (consulta.drive_bkup.Equals("1"))
                    {
                        cbConfirming.Checked = true;
                        cb1.Checked = true;
                    }
                    else
                    {
                        cbConfirming.Checked = false;
                        cb1.Checked = false;
                    }
                }
            }
            else
            {
                CerrarSesion.Visible = cb.Visible = ListaEf.Visible = false;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
        protected void cbConfirming_CheckedChanged(object sender, EventArgs e)
        {
            if (cbConfirming.Checked)
            {
                WebAppCesionesConfirming_Result resultado = logica.Confirming(1, Session["ef"].ToString());
                if (resultado.error==0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Activado');</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error: " + resultado.mensaje + "');</script>");
                }
            }
            else
            {
                WebAppCesionesConfirming_Result resultado = logica.Confirming(0, Session["ef"].ToString());
                if (resultado.error == 0)
                {
                    Response.Write("<script type=\"text/javascript\">alert('Desactivado');</script>");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Error: " + resultado.mensaje + "');</script>");
                }
            }
            
        }

        protected void ListaEf_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["ef"] = ListaEf.SelectedValue;
            xuconfig consulta = logica.ConsultaConfirming(Session["ef"].ToString());
            if (consulta.drive_bkup.Equals("1"))
            {
                cbConfirming.Checked = true;
                cb1.Checked = true;
            }
            else
            {
                cbConfirming.Checked = false;
                cb1.Checked = false;
            }
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "limpiar();", true);
        }
    }
}