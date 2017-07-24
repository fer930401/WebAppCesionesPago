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
    public partial class Login : System.Web.UI.Page
    {
        LogicaNegocios logicanegocio = new LogicaNegocios();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["validacion"] != null)
            {
                Session.Clear();
                Session.RemoveAll();
                Session.Abandon();
            }
            if (!IsPostBack)
            {
                ddlUsuarios.DataSource = logicanegocio.ListaUsuarios();
                ddlUsuarios.DataTextField = "nombre";
                ddlUsuarios.DataValueField = "user_cve";
                ddlUsuarios.DataBind();
                ddlUsuarios.Items.Insert(0, new ListItem("< Selecciona un usuario >", "NA"));
            }
        }

        protected void Inicio_Click(object sender, EventArgs e)
        {
            if (ddlUsuarios.SelectedValue!="NA" && txtPassword.Text!="")
            {
                string usuario = logicanegocio.Login(ddlUsuarios.SelectedValue, txtPassword.Text);
                if (usuario!=null)
                {
                    Session["user_cve"] = usuario;
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    Response.Write("<script type=\"text/javascript\">alert('Datos Incorrectos'); window.location.href = 'Login.aspx';</script>");
                }
            }
            else
            {
                Response.Write("<script type=\"text/javascript\">alert('Completar todos los campos'); window.location.href = 'Login.aspx';</script>");
            }
        }
    }
}