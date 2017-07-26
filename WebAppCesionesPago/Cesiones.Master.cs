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
                btnCerrarSesion.Visible = btnCerrarSesion2.Visible = true;
                btnConfirming.Visible = btnConfirming2.Visible = true;
            }
            else
            {
                btnCerrarSesion.Visible = btnCerrarSesion2.Visible = false;
                btnConfirming.Visible = btnConfirming2.Visible = false;
            }
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnConfirming_Click(object sender, EventArgs e)
        {
            WebAppCesionesConfirming_Result resultado = logica.Confirming(1, "001");
            Response.Write("<script type=\"text/javascript\">alert('" + resultado.mensaje + "');</script>");
        }
    }
}