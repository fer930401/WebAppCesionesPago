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
        protected void Page_Load(object sender, EventArgs e)
        {
            /* se llena el combo de Tipo de Cesión con el clave de la opcion 206 */
            ddlTipCesion.DataSource = logicaNegocio.consTipCesion("206");
            ddlTipCesion.DataTextField = "op_nom";
            ddlTipCesion.DataValueField = "op_val";
            ddlTipCesion.DataBind();

            /* se llena el combo de Tipo Pago con el clave de la opcion 207 */
            ddlTipPago.DataSource = logicaNegocio.consTipCesion("207");
            ddlTipPago.DataTextField = "op_nom";
            ddlTipPago.DataValueField = "op_val";
            ddlTipPago.DataBind();
        }
    }
}