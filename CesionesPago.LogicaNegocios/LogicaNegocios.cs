using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CesionesPago.Entidades;

namespace CesionesPago.LogicaNegocios
{
    public class LogicaNegocios
    {
        AccesoDatos.AccesoDatos datos;

        public LogicaNegocios()
        {
            datos = new AccesoDatos.AccesoDatos();
        }

        public List<Entidades.qcomcve1_Result> consTipCesion(string tipo)
        {
            return datos.consTipCesion(tipo);
        }
        public List<Entidades.xcuser> ListaUsuarios()
        {
            return datos.ListaUsuarios(datos.ListaUser_cve());
        }
        public string Login(string usuario, string pass)
        {
            return datos.Login(usuario, pass);
        }
        public List<WebAppPagosTipDoc_Result> ListaDocumentos(string TipoPago)
        {
            return datos.ListaDocumentos(TipoPago);
        }
        public WebAppCesionesPago_Result ProcesarPago(string ef_cve, int tipo_cesion, string tipo_pago, string tipo_doc, int num_fol, DateTime fecha, short opcion, string user)
        {
            return datos.ProcesarPago(ef_cve, tipo_cesion, tipo_pago, tipo_doc, num_fol, fecha, opcion, user);
        }
    }
}
