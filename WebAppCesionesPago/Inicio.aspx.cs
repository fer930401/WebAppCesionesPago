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
                    ddlTipoDocumento.DataSource = null;
                    ddlTipoDocumento.DataBind();
                    ddlTipoDocumento.Items.Insert(0, new ListItem("No hay documentos", "NA"));
                }
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnAutorizar_Click(object sender, EventArgs e)
        {
            try
            {
                int folio = 0;
                bool convertir = int.TryParse(txtBuscarFolio.Text, out folio);
                if (convertir)
                {
                    WebAppCesionesPago_Result resultado = logicaNegocio.Autorizar("001",1,ddlTipoDocumento.SelectedValue,folio,DateTime.Now,Session["user_cve"].ToString());
                    if (resultado.error==0)
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Pago Autorizado Correctamente');</script>");
                        txtBuscarFolio.Text = "";
                        ddlTipoDocumento.Items.Clear();
                        ddlTipoDocumento.DataSource = null;
                        ddlTipoDocumento.DataBind();
                        ddlTipoDocumento.Items.Insert(0, new ListItem("No hay documentos", "NA"));
                    }
                    else
                    {
                        Response.Write("<script type=\"text/javascript\">alert('Error: "+resultado.mensaje+"');</script>");
                    }
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('No se pudo convertir el folio');</script>");
                }
                
            }
            catch (Exception message)
            {
                Response.Write("<script type=\"text/javascript\">alert('" + message + "');</script>");
            }
        }

        protected void txtBuscarFolio_TextChanged(object sender, EventArgs e)
        {
            int folio =0;
            bool result = int.TryParse(txtBuscarFolio.Text, out folio);
            if (result)
            {
                List<WebAppConsultaPagos_Result> consulta = logicaNegocio.ConsultaPagos("001", folio);
                if (consulta.Count!=0)
                {
                    ddlTipoDocumento.Items.Clear();
                    ddlTipoDocumento.DataSource = consulta;
                    ddlTipoDocumento.DataTextField = "nombre";
                    ddlTipoDocumento.DataValueField = "tipo_doc";
                    ddlTipoDocumento.DataBind();
                }
            }
            else
            {
                ddlTipoDocumento.Items.Clear();
                ddlTipoDocumento.DataSource = null;
                ddlTipoDocumento.DataBind();
                ddlTipoDocumento.Items.Insert(0, new ListItem("No hay documentos", "NA"));
            }
        }
    }
}